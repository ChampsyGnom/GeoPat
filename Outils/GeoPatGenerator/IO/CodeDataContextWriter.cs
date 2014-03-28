using Emash.GeoPat.Generator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPat.Generator.IO
{
    public class CodeDataContextWriter
    {
        public Project Project { get; private set; }

        private StreamWriter Writer { get;  set; }
        private int IndentLevel { get; set; }
        public CodeDataContextWriter(Project project)
        {
            this.Project = project;
          
     
        }

        public void Write()
        {
            
            String appPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            DirectoryInfo directory = new DirectoryInfo(appPath);
            DirectoryInfo directoryCode = directory;
            while (!directoryCode.Name.Equals("GeoPat"))
            {directoryCode = directoryCode.Parent; }
            String directoryLayer = Path.Combine(directoryCode.FullName, "Layers");
            String directoryLayerData = Path.Combine(directoryLayer, "Data");
         
  
            
            String fileName = Path.Combine(directoryLayerData, "DataContext.cs");
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream,System.Text.Encoding.Unicode ))
                {
                    this.Writer = writer;

                 
                    this.WriteLine("using System;");
                    this.WriteLine("using System.Data.Entity;");
                    this.WriteLine("using System.Data;");
                    this.WriteLine("using System.Data.Common;");
                    this.WriteLine("using Emash.GeoPat.Data.Models;");
                    this.WriteLine("namespace Emash.GeoPat.Data");
                    this.WriteBracketOpen();


                      
                    this.WriteLine("public partial class DataContext : DbContext");
                    this.WriteBracketOpen();
                    this.WriteLine("public DataContext(DbConnection connection) : base(connection,false)");
                    this.WriteBracketOpen();
                    this.WriteBracketClose();
                   
                    foreach (DbSchema schema in this.Project.Schemas)
                    {
                        foreach (DbTable table in schema.Tables)
                        {
                            String schemaCamelCase = schema.Name.ToCamelCase("_");
                            String className = schemaCamelCase + table.Name.ToCamelCase("_");
                            if (className.EndsWith(schemaCamelCase))
                            { className = className.Substring(0, className.Length - schemaCamelCase.Length); }
                            this.WriteLine("");
                            this.WriteLine("public DbSet<" + className + "> " + className + "s { get; set; }");
                        }

                    }
                    this.WriteLine("");
                    this.WriteLine("protected override void OnModelCreating(DbModelBuilder modelBuilder)");
                    this.WriteBracketOpen();
                    foreach (DbSchema schema in this.Project.Schemas)
                    {

                        String schemaCamelCase = schema.Name.ToCamelCase("_");
                        //
                        foreach (DbTable table in schema.Tables)
                        {
                            String className = schemaCamelCase + table.Name.ToCamelCase("_");
                            if (className.EndsWith(schemaCamelCase))
                            { className = className.Substring(0, className.Length - schemaCamelCase.Length); }

                            // Parent
                            List<DbKeyForeign> fkChilds = (from fk in schema.ForeignKeys where fk.TableIdChild.Equals(table.Id) select fk).ToList();

                            // Collection
                            List<DbKeyForeign> fkParents = (from fk in schema.ForeignKeys where fk.TableIdParent.Equals(table.Id) select fk).ToList();

                            foreach (DbKeyForeign fkChild in fkChilds)
                            {
                                DbTable parentTable = (from t in schema.Tables where t.Id.Equals(fkChild.TableIdParent) select t).FirstOrDefault();
                                String parentClassName = schemaCamelCase + parentTable.Name.ToCamelCase("_");
                                if (parentClassName.EndsWith(schemaCamelCase))
                                { parentClassName = parentClassName.Substring(0, parentClassName.Length - schemaCamelCase.Length); }
                                //.HasForeignKey(u => new { u.MainCityUserID, u.MainCityID),

                                List<String> keys = new List<string>();
                                Boolean isOptional = true;
                                foreach (DbKeyForeignJoin j in fkChild.Joins)
                                {
                                    DbColumn childColumn = (from c in table.Columns where c.Id.Equals (j.ColumnIdChild ) select c).FirstOrDefault();
                                    if (!childColumn.AllowNull)
                                    { isOptional = false; }
                                    String propertyNameChild = childColumn.Name;
                                    if (propertyNameChild.StartsWith(table.Name+"__"))
                                    { propertyNameChild = propertyNameChild.Substring(table .Name.Length+2); }
                                    propertyNameChild = propertyNameChild.ToCamelCase("_");


                                    keys.Add(propertyNameChild);
                                }
                                /*
                                if (fkChild.DeleteOnCascade)
                                {
                                    if (isOptional)
                                    {
                                        this.WriteLine("modelBuilder.Entity<" + className + ">().HasOptional<" + parentClassName + ">(c => c." + parentClassName + ").WithMany(t => t." + className + "s).HasForeignKey(u => new { " + String.Join(",", (from k in keys select "u." + k)) + " }).WillCascadeOnDelete(true);"); 
                                    }
                                    else
                                    { this.WriteLine("modelBuilder.Entity<" + className + ">().HasRequired<" + parentClassName + ">(c => c." + parentClassName + ").WithMany(t => t." + className + "s).HasForeignKey(u => new { " + String.Join(",", (from k in keys select "u." + k)) + " }).WillCascadeOnDelete(true);"); }
                                    
                                }
                                else
                                {
                                    if (isOptional)
                                    {
                                        this.WriteLine("modelBuilder.Entity<" + className + ">().HasOptional<" + parentClassName + ">(c => c." + parentClassName + ").WithMany(t => t." + className + "s).HasForeignKey(u => new { " + String.Join(",", (from k in keys select "u." + k)) + " }).WillCascadeOnDelete(false);"); 
                                    } 
                                    else
                                    { this.WriteLine("modelBuilder.Entity<" + className + ">().HasRequired<" + parentClassName + ">(c => c." + parentClassName + ").WithMany(t => t." + className + "s).HasForeignKey(u => new { " + String.Join(",", (from k in keys select "u." + k)) + " }).WillCascadeOnDelete(false);"); }
                                }
                                    */
                                //
                               
                            }
                         
                            foreach (DbKeyForeign fkParent in fkParents)
                            {
                                bool isOptional = true;
                                DbTable childTable = (from t in schema.Tables where t.Id.Equals(fkParent.TableIdChild) select t).FirstOrDefault();
                                String childClassName = schemaCamelCase + childTable.Name.ToCamelCase("_");
                                if (childClassName.EndsWith(schemaCamelCase))
                                { childClassName = childClassName.Substring(0, childClassName.Length - schemaCamelCase.Length); }
                                List<String> keys = new List<string>();
                                foreach (DbKeyForeignJoin j in fkParent.Joins)
                                {
                                    

                                    DbColumn parentColumn = (from c in table.Columns where c.Id.Equals(j.ColumnIdParent) select c).FirstOrDefault();
                                    DbColumn childColumn = (from c in childTable.Columns where c.Id.Equals(j.ColumnIdChild) select c).FirstOrDefault();
                                   
                                    if (!childColumn.AllowNull)
                                    { isOptional = false; }

                                    String propertyNameParent = parentColumn.Name;
                                    if (propertyNameParent.StartsWith(table.Name+"__"))
                                    { propertyNameParent = propertyNameParent.Substring(table.Name.Length+2); }

                                    String propertyNameChild = childColumn.Name;
                                    if (propertyNameChild.StartsWith(childTable.Name + "__"))
                                    { propertyNameChild = propertyNameChild.Substring(childTable.Name.Length + 2); }
                                    propertyNameChild = propertyNameChild.ToCamelCase("_");


                                    propertyNameParent = propertyNameParent.ToCamelCase("_");
                                    keys.Add(propertyNameChild);
                                }
                                // cas geometri bsn
                                /*
                                if (fkParent.DeleteOnCascade)
                                {
                                    if (isOptional)
                                    { this.WriteLine("modelBuilder.Entity<" + className + ">().HasMany<" + childClassName + ">(c => c." + childClassName + "s).WithOptional(t => t." + className + ").HasForeignKey(u => new { " + String.Join(",", (from k in keys select "u." + k)) + " }).WillCascadeOnDelete(true);"); }
                                    else
                                    { this.WriteLine("modelBuilder.Entity<" + className + ">().HasMany<" + childClassName + ">(c => c." + childClassName + "s).WithRequired(t => t." + className + ").HasForeignKey(u => new { " + String.Join(",", (from k in keys select "u." + k)) + " }).WillCascadeOnDelete(true);"); }
                                }
                                else
                                {
                                    if (isOptional)
                                    { this.WriteLine("modelBuilder.Entity<" + className + ">().HasMany<" + childClassName + ">(c => c." + childClassName + "s).WithOptional(t => t." + className + ").HasForeignKey(u => new { " + String.Join(",", (from k in keys select "u." + k)) + " }).WillCascadeOnDelete(false);"); }
                                    else
                                    { this.WriteLine("modelBuilder.Entity<" + className + ">().HasMany<" + childClassName + ">(c => c." + childClassName + "s).WithRequired(t => t." + className + ").HasForeignKey(u => new { " + String.Join(",", (from k in keys select "u." + k)) + " }).WillCascadeOnDelete(false);"); }
                                }
                                */
                            }

                          
                          
                            DbKeyPrimary pk = (from k in schema.PrimaryKeys where k.TableId.Equals(table.Id) select k).FirstOrDefault();
                            if (pk != null)
                            {
                                List<String> keyStrings = new List<string>();
                                List<DbColumn> columnPks = (from c in table.Columns where pk.ColumnIds.Contains (c.Id ) select c).ToList();
                                foreach (DbColumn columnPk in columnPks)
                                {
                                    String propertyName = columnPk.Name;
                                    if (propertyName.StartsWith(table.Name))
                                    { propertyName = propertyName.Substring(table.Name.Length); }
                                    propertyName = propertyName.ToCamelCase("_");
                                    keyStrings.Add(propertyName);

                                }
                                this.WriteLine("modelBuilder.Entity<"+className+">().ToTable(\""+table.Name+"\",\""+schema.Name+"\");");
                                this.WriteLine("modelBuilder.Entity<"+className+">().HasKey(item => new {"+  String.Join (",",  (from s in keyStrings select "item."+s))+" });");
                                foreach (DbColumn column in table.Columns)
                                {
                                    String propertyName = column.Name;
                                    if (propertyName.StartsWith(table.Name))
                                    { propertyName = propertyName.Substring(table.Name.Length); }
                                    propertyName = propertyName.ToCamelCase("_");
                                    if (!column.AllowNull)
                                    {
                                        this.WriteLine("modelBuilder.Entity<" + className + ">().Property(item => item." + propertyName + ").IsRequired();");
                                    }
                                    if (column.Length.HasValue && column.DataType.StartsWith ("VARCHAR"))
                                    {
                                        this.WriteLine("modelBuilder.Entity<" + className + ">().Property(item => item." + propertyName + ").HasMaxLength(" + column.Length .Value + ");");
                                    }
                                    String columnName = column.Name;
                                    if (columnName.StartsWith(table.Name + "__"))
                                    { columnName = columnName.Substring(table.Name.Length + 2); }
                                    this.WriteLine("modelBuilder.Entity<" + className + ">().Property(item => item." + propertyName + ").HasColumnName(\"" + columnName + "\");");
                                }
                            }
                        }
                    
                    }
                    //
                    this.WriteBracketClose();



                    this.WriteBracketClose();
                    this.WriteBracketClose();
                }
            }
           
            
       
        }

        private void WriteBracketClose()
        {
            this.IndentLevel--;
            this.WriteLine("}");
  
        }

        private void WriteBracketOpen()
        {
            this.WriteLine("{");
            this.IndentLevel++;
        }

        private void WriteLine(string content)
        {
           this.Writer.WriteLine (new String(" ".ToCharArray ()[0],IndentLevel *4)+content );
        }
    }
}

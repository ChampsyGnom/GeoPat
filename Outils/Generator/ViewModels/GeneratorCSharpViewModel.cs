using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using Emash.GeoPatNet.Generator.Models;
using Emash.GeoPatNet.Generator.Views;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.ServiceLocation;
using System.IO;
using Emash.GeoPatNet.Generator.Utils;
using Emash.GeoPatNet.Generator.IO;
using System.Diagnostics;


namespace Emash.GeoPatNet.Generator.ViewModels
{
    public class GeneratorCSharpViewModel : ViewModelBase
    {
        private Project _model;
        public String DataNamespace { get; set; }
        public String DataPath { get; set; }
  


        public String DataInfraNamespace { get; set; }
        public String DataInfraPath { get; set; }
   
        public DelegateCommand ChangeDataInfraPathCommand { get; set; }
 
        public DelegateCommand ChangeDataPathCommand { get; set; }
   
        public DelegateCommand GenerateCommand { get; set; }

        

        public GeneratorCSharpViewModel(Project model)
        {
            this._model = model;
            this.DataNamespace = model.DataNamespace;
            this.DataPath = model.DataPath;
          
            this.DataInfraPath = model.DataInfraPath;
            this.DataInfraNamespace = model.DataInfraNamespace;
    

            this.ChangeDataPathCommand = new DelegateCommand(ChangeDataPathExecute);
            this.ChangeDataInfraPathCommand = new DelegateCommand(ChangeDataInfraPathExecute);

            this.GenerateCommand = new DelegateCommand(GenerateExecute);
        }

        private void GenerateExecute()
        {
            this._model.DataNamespace = this.DataNamespace;
            this._model.DataPath = this.DataPath;        
            
            this._model.DataInfraPath = this.DataInfraPath;
            this._model.DataInfraNamespace = this.DataInfraNamespace;
           
            ServiceLocator.Current.GetInstance<MainViewModel>().SaveProjectExecute();

            this.GenerateDataInfra();
            this.GenerateData();
            this.GenerateDataContext();
           
        }
       
        private void GenerateDataContext()
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            String resourcesPath = Path.Combine(appStartPath, "Resources");
            string templatesPath = Path.Combine(resourcesPath, "Templates");
            string templateFileName = Path.Combine(templatesPath, "EntityDataContext.tpl");
           
            String fileName = Path.Combine(this.DataPath, "DataContext.cs");
            TemplateFileWriter writer = new TemplateFileWriter(fileName, templateFileName);
            writer.ReplaceTag("@NameSpaceInfrastructure", this.DataInfraNamespace);
          
            writer.ReplaceTag("@NameSpace", this.DataNamespace);
            foreach (DbSchema schema in this._model.Schemas)
            {
                foreach (DbTable table in schema.Tables)
                { 
                    String className = NameConverter.TableNameToEntityName(table.Name)+"";
                    writer.AddProperty("public DbSet<" + className + "> ", className + "s");

                   
                    
                        //
                    //public InfAccident CreateInfAccident()  
                   // 
                    foreach (DbForeignKey fk in table.ForeignKeys)
                    {
                        DbTable parentTable = (from t in schema.Tables where t.Id.Equals (fk.ParentTableId ) select t).FirstOrDefault();
                        String parentEntityName = NameConverter.TableNameToEntityName(parentTable.Name);
                        writer.ModelBuilders.Add("modelBuilder.Entity<" + className + ">().HasRequired<" + parentEntityName + ">(c => c." + parentEntityName + ").WithMany(t => t." + className + "s);");
                    }

                    //  
                    writer.ModelBuilders.Add("modelBuilder.Entity<"+className+">().ToTable(\""+table.Name.ToLower ()+"\", \""+schema.Name.ToLower ()+"\");");
                    foreach (DbColumn column in table.Columns)
                    {

                        if (column.Name.StartsWith (table.Name +"__"))
                        {
                            String propertyName = NameConverter.ColumnNameToPropertyName(column.Name.Substring(column.Name.IndexOf("__")));
                            writer.ModelBuilders.Add("modelBuilder.Entity<" + className + ">().Property(t => t." + propertyName + ") .HasColumnName(\"" + column.Name.ToLower () + "\");");
                            if (!column.AllowNull)
                            { writer.ModelBuilders.Add("modelBuilder.Entity<" + className + ">().Property(t => t." + propertyName + ").IsRequired();"); }

                            if (column.DataType.StartsWith("VARCHAR"))
                            {
                                writer.ModelBuilders.Add("modelBuilder.Entity<" + className + ">().Property(t => t." + propertyName + ").HasMaxLength(" + column.Length + ");");
                            }
                        }
                        else
                        {
                            String propertyName = NameConverter.ColumnNameToPropertyName(column.Name);
                            writer.ModelBuilders.Add("modelBuilder.Entity<" + className + ">().Property(t => t." + propertyName + ") .HasColumnName(\"" + column.Name.ToLower() + "\");");
                            if (!column.AllowNull)
                            { writer.ModelBuilders.Add("modelBuilder.Entity<" + className + ">().Property(t => t." + propertyName + ").IsRequired();"); }
                            if (column.DataType.StartsWith("VARCHAR"))
                            {
                                writer.ModelBuilders.Add("modelBuilder.Entity<" + className + ">().Property(t => t." + propertyName + ").HasMaxLength("+column.Length+");");
                            }
                        }
                        
                        
                       
                    }
                    if (table.PrimaryKey.ColumnIds.Count == 1)
                    {
                        DbColumn pkColumn = (from c in table.Columns where c.Id.Equals (table.PrimaryKey.ColumnIds.First ()) select c).FirstOrDefault();
                        String propertyName = NameConverter.ColumnNameToPropertyName(pkColumn.Name.Substring(table.Name.Length));
                        writer.ModelBuilders.Add("modelBuilder.Entity<" + className + ">().HasKey(t => t." + propertyName + ");");
                        writer.ModelBuilders.Add("modelBuilder.Entity<" + className + ">().Property(t => t." + propertyName + ").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);");
                        //
                    }
                    
                
                    //modelBuilder.Entity<InfAccident>().HasKey(t => t.Id);
                }
            }

           
            writer.WriteContent();
        }
        private void GenerateData()
        {
            string modelPath = Path.Combine(this.DataPath, "Models");
            String[] files = Directory.GetFiles(modelPath);
            foreach (String file in files)
            { File.Delete(file); }
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            String resourcesPath = Path.Combine(appStartPath, "Resources");
            string templatesPath = Path.Combine(resourcesPath, "Templates");
            string templateFileName = Path.Combine(templatesPath, "EntityImplementation.tpl");

            foreach (DbSchema schema in this._model.Schemas)
            {
                List<DbForeignKey> allFks = new List<DbForeignKey>();
                foreach (DbTable table in schema.Tables)
                {
                    foreach (DbForeignKey fk in table.ForeignKeys)
                    {
                        allFks.Add(fk);
                    }
                }
                allFks = (from fk in allFks select fk).Distinct().ToList();
                foreach (DbTable table in schema.Tables)
                {
                    String className = NameConverter.TableNameToEntityName(table.Name)+"";
                    String modelFileName = Path.Combine(modelPath, className + ".cs");
                    TemplateFileWriter writer = new TemplateFileWriter(modelFileName, templateFileName);
                    writer.ClassAttributes.Add("[TableName(\"" + table.Name + "\")]");
                    writer.ClassAttributes.Add("[SchemaName(\"" + schema.Name + "\")]");
                    List<DbForeignKey> childFks = (from fk in allFks where fk.ParentTableId.Equals(table.Id) select fk).ToList();

                    foreach (DbForeignKey childFk in childFks)
                    {
                        DbTable childTable = (from t in schema.Tables where t.Id.Equals(childFk.ChildTableId) select t).FirstOrDefault();
                        String childEntityName = NameConverter.TableNameToEntityName(childTable.Name);
                        TemplateProperty prop = writer.AddProperty("public virtual ICollection<" + childEntityName + ">", childEntityName + "s");
                        prop.Attributes.Add("[DisplayName(\"" + childTable.DisplayName + "s\")]");

                    }

                    List<DbForeignKey> parentFks = (from fk in allFks where fk.ChildTableId.Equals(table.Id) select fk).ToList();

                    foreach (DbForeignKey parentFk in parentFks)
                    {
                        DbTable parentTable = (from t in schema.Tables where t.Id.Equals(parentFk.ParentTableId) select t).FirstOrDefault();
                        String parentEntityName = NameConverter.TableNameToEntityName(parentTable.Name);
                        DbColumn childColumn = (from c in table.Columns where (from j in  parentFk.Joins  select j.ChildColumnId ).Contains (c.Id ) select c).FirstOrDefault();
                        TemplateProperty prop = writer.AddProperty("public virtual " + parentEntityName, parentEntityName);
                        prop.Attributes.Add("[DisplayName(\"" + parentTable.DisplayName + "\")]");
                        prop.Attributes.Add("[ColumnName(\"" + childColumn.Name + "\")]");
                        if (childColumn.AllowNull)
                        { prop.Attributes.Add("[AllowNull(true)]"); }
                        else
                        { prop.Attributes.Add("[AllowNull(false)]"); }
                        prop.Attributes.Add("[ControlType(ControlType.Combo)]");

                    }

                    writer.ReplaceTag("@DisplayName", table.DisplayName);
                    writer.ReplaceTag("@NameSpaceInfrastructure", this.DataInfraNamespace);
                    writer.ReplaceTag("@NameSpace", this.DataNamespace);
                    writer.ReplaceTag("@EntityName", className);
                    foreach (DbColumn column in table.Columns)
                    {
                        DbForeignKey fkTable = (from fk in table.ForeignKeys where (from j in fk.Joins select j.ChildColumnId ).Contains (column.Id ) select fk).FirstOrDefault();
                        DbForeignKeyJoin fkJoinColumn = null;

                        List<DbUniqueKey> uks = (from uk in table.UniqueKeys where uk.ColumnIds.Contains (column.Id ) select uk).ToList(); 
                     
                        if (fkTable != null)
                        {
                            fkJoinColumn = (from j in fkTable.Joins where j.ChildColumnId.Equals(column.Id) select j).FirstOrDefault(); 
                           
                        }
                        
                        String propertyName = NameConverter.ColumnNameToPropertyName(column.Name.Replace(table.Name, ""));
                        if (column.DataType.Equals("INT4"))
                        {
                            DbRulePr rulePr = (from r in column.Rules where r is DbRulePr select r as DbRulePr).FirstOrDefault();
                            if (column.AllowNull)
                            {
                                TemplateProperty prop = writer.AddProperty("public Nullable<Int64>", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                                prop.Attributes.Add("[ColumnName(\"" + column.Name + "\")]");
                                if (fkJoinColumn != null)
                                { prop.Attributes.Add("[ForeignKey(\"" + fkTable.Name + "\",\"JOIN_" + fkJoinColumn .Id+ "\")]"); }

                                foreach (DbUniqueKey uk in uks)
                                {prop.Attributes.Add("[UniqueKey(\"" + uk.Name + "\")]");}
                                prop.Attributes.Add("[RangeValue(-999999999999,999999999999)]");
                                if (rulePr != null)
                                { 
                                    prop.Attributes.Add("[RulePr(\""+rulePr.ChausseIdColumnName+"\")]");
                                    prop.Attributes.Add("[ControlType(ControlType.Pr)]");
                                }
                                else
                                { prop.Attributes.Add("[ControlType(ControlType.Integer)]"); }         
                                prop.Attributes.Add("[AllowNull(true)]");
                               
                            }
                            else
                            {
                                TemplateProperty prop = writer.AddProperty("public Int64", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                                prop.Attributes.Add("[ColumnName(\"" + column.Name + "\")]");
                                if (fkJoinColumn != null)
                                { prop.Attributes.Add("[ForeignKey(\"" + fkTable.Name + "\",\"JOIN_" + fkJoinColumn.Id + "\")]"); }

                                foreach (DbUniqueKey uk in uks)
                                { prop.Attributes.Add("[UniqueKey(\"" + uk.Name + "\")]"); }
                                prop.Attributes.Add("[RangeValue(-999999999999,999999999999)]");
                                if (rulePr != null)
                                {
                                    prop.Attributes.Add("[RulePr(\"" + rulePr.ChausseIdColumnName + "\")]");
                                    prop.Attributes.Add("[ControlType(ControlType.Pr)]");
                                }
                                else
                                { prop.Attributes.Add("[ControlType(ControlType.Integer)]"); }         
                                prop.Attributes.Add("[AllowNull(false)]");
                            }
                        }
                        else if (column.DataType.Equals("SERIAL"))
                        {

                            TemplateProperty prop = writer.AddProperty("public Int64", propertyName);                        
                            prop.Attributes.Add("[Browsable(false)]");
                            prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                            prop.Attributes.Add("[ColumnName(\"" + column.Name + "\")]");
                            if (table.PrimaryKey.ColumnIds.Contains(column.Id))
                            {prop.Attributes.Add("[PrimaryKey(\"" + table.PrimaryKey.Name + "\")]");}

                            foreach (DbUniqueKey uk in uks)
                            { prop.Attributes.Add("[UniqueKey(\"" + uk.Name + "\")]"); }
                            prop.Attributes.Add("[ControlType(ControlType.None)]");
                            prop.Attributes.Add("[AllowNull(false)]");

                        }
                        else if (column.DataType.StartsWith("VARCHAR"))
                        {

                            TemplateProperty prop = writer.AddProperty("public String", propertyName);
                            prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                            prop.Attributes.Add("[ColumnName(\"" + column.Name + "\")]");
                            if (fkJoinColumn != null)
                            { prop.Attributes.Add("[ForeignKey(\"" + fkTable.Name + "\",\"JOIN_" + fkJoinColumn.Id + "\")]"); }

                            foreach (DbUniqueKey uk in uks)
                            {
                                prop.Attributes.Add("[UniqueKey(\"" + uk.Name + "\")]"); 
                            }

                            prop.Attributes.Add("[MaxCharLength(" + column.Length + ")]");
                            prop.Attributes.Add("[ControlType(ControlType.Text)]");
                            //MaxCharLengthAttribute
                            if (column.AllowNull)
                            { prop.Attributes.Add("[AllowNull(true)]"); }
                            else
                            { prop.Attributes.Add("[AllowNull(false)]"); }

                        }
                        else if (column.DataType.StartsWith("FLOAT8"))
                        {
                            //RangeValueAttribute
                            if (column.AllowNull)
                            {
                                TemplateProperty prop = writer.AddProperty("public Nullable<Double>", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                                prop.Attributes.Add("[ColumnName(\"" + column.Name + "\")]");
                                if (fkJoinColumn != null)
                                { prop.Attributes.Add("[ForeignKey(\"" + fkTable.Name + "\",\"JOIN_" + fkJoinColumn.Id + "\")]"); }

                                foreach (DbUniqueKey uk in uks)
                                { prop.Attributes.Add("[UniqueKey(\"" + uk.Name + "\")]"); }
                                prop.Attributes.Add("[RangeValue(-999999999999,999999999999)]");
                                prop.Attributes.Add("[ControlType(ControlType.Decimal)]");
                                prop.Attributes.Add("[AllowNull(true)]");
                            }
                            else
                            {
                                TemplateProperty prop = writer.AddProperty("public Double", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                                prop.Attributes.Add("[ColumnName(\"" + column.Name + "\")]");
                                if (fkJoinColumn != null)
                                { prop.Attributes.Add("[ForeignKey(\"" + fkTable.Name + "\",\"JOIN_" + fkJoinColumn.Id + "\")]"); }

                                foreach (DbUniqueKey uk in uks)
                                { prop.Attributes.Add("[UniqueKey(\"" + uk.Name + "\")]"); }
                                prop.Attributes.Add("[RangeValue(-999999999999,999999999999)]");
                                prop.Attributes.Add("[ControlType(ControlType.Decimal)]");
                                prop.Attributes.Add("[AllowNull(false)]");
                            }


                        }
                        else if (column.DataType.StartsWith("DATE"))
                        {
                            if (column.AllowNull)
                            {
                                TemplateProperty prop = writer.AddProperty("public Nullable<DateTime>", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                                prop.Attributes.Add("[ColumnName(\"" + column.Name + "\")]");
                                if (fkJoinColumn != null)
                                { prop.Attributes.Add("[ForeignKey(\"" + fkTable.Name + "\",\"JOIN_" + fkJoinColumn.Id + "\")]"); }

                                foreach (DbUniqueKey uk in uks)
                                { prop.Attributes.Add("[UniqueKey(\"" + uk.Name + "\")]"); }
                                prop.Attributes.Add("[ControlType(ControlType.Date)]");
                                prop.Attributes.Add("[AllowNull(true)]");
                            }
                            else
                            {
                                TemplateProperty prop = writer.AddProperty("public DateTime", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                                prop.Attributes.Add("[ColumnName(\"" + column.Name + "\")]");
                                if (fkJoinColumn != null)
                                { prop.Attributes.Add("[ForeignKey(\"" + fkTable.Name + "\",\"JOIN_" + fkJoinColumn.Id + "\")]"); }

                                foreach (DbUniqueKey uk in uks)
                                { prop.Attributes.Add("[UniqueKey(\"" + uk.Name + "\")]"); }
                                prop.Attributes.Add("[ControlType(ControlType.Date)]");
                                prop.Attributes.Add("[AllowNull(false)]");
                            }


                        }
                        else if (column.DataType.StartsWith("BOOL"))
                        {
                            if (column.AllowNull)
                            {
                                TemplateProperty prop = writer.AddProperty("public Nullable<Boolean>", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                                prop.Attributes.Add("[ColumnName(\"" + column.Name + "\")]");
                                if (fkJoinColumn != null)
                                { prop.Attributes.Add("[ForeignKey(\"" + fkTable.Name + "\",\"JOIN_" + fkJoinColumn.Id + "\")]"); }

                                foreach (DbUniqueKey uk in uks)
                                { prop.Attributes.Add("[UniqueKey(\"" + uk.Name + "\")]"); }
                                prop.Attributes.Add("[ControlType(ControlType.Check)]");
                                prop.Attributes.Add("[AllowNull(true)]");
                            }
                            else
                            {
                                TemplateProperty prop = writer.AddProperty("public Boolean", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]"); 
                                prop.Attributes.Add("[ColumnName(\"" + column.Name + "\")]");
                                if (fkJoinColumn != null)
                                { prop.Attributes.Add("[ForeignKey(\"" + fkTable.Name + "\",\"JOIN_" + fkJoinColumn.Id + "\")]"); }

                                foreach (DbUniqueKey uk in uks)
                                { prop.Attributes.Add("[UniqueKey(\"" + uk.Name + "\")]"); }
                                prop.Attributes.Add("[ControlType(ControlType.Check)]");
                                prop.Attributes.Add("[AllowNull(false)]");
                            }


                        }
                        else Console.WriteLine(column.DataType);
                    }
                    writer.WriteContent();
                }
            }
        }

        private void GenerateDataInfra()
        {
            string modelPath = Path.Combine(this.DataInfraPath, "Models");
            String[] files = Directory.GetFiles(modelPath);
            foreach (String file in files)
            {File.Delete (file);}
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            String resourcesPath = Path.Combine (appStartPath,"Resources");
            string templatesPath = Path.Combine (resourcesPath,"Templates");
            string templateFileName = Path.Combine (templatesPath,"EntityInfrastructure.tpl");

            foreach (DbSchema schema in this._model.Schemas)
            {
                foreach (DbTable table in schema.Tables)
                {
                    String interfaceName = "I"+NameConverter.TableNameToEntityName(table.Name)+"";
                    String modelFileName = Path.Combine(modelPath, interfaceName + ".cs");
                    TemplateFileWriter writer = new TemplateFileWriter(modelFileName, templateFileName);
                    writer.ReplaceTag("@DisplayName", table.DisplayName);
                    writer.ReplaceTag("@NameSpace", this.DataInfraNamespace);
                    writer.ReplaceTag("@EntityName", interfaceName);
                    foreach (DbColumn column in table.Columns)
                    {

                        String propertyName = NameConverter.ColumnNameToPropertyName(column.Name.Replace(table.Name, ""));
                        if (column.DataType.Equals("INT4"))
                        {
                            if (column.AllowNull)
                            {
                                TemplateProperty prop = writer.AddProperty("Nullable<Int64>", propertyName);
                                
                            }
                            else
                            {
                                TemplateProperty prop = writer.AddProperty("Int64", propertyName);
                            }
                        }
                        else if (column.DataType.Equals("SERIAL"))
                        {

                            TemplateProperty prop = writer.AddProperty("Int64", propertyName);

                        }
                        else if (column.DataType.StartsWith("VARCHAR"))
                        {

                            TemplateProperty prop = writer.AddProperty("String", propertyName);
                            

                        }
                        else if (column.DataType.StartsWith("FLOAT8"))
                        {
                            if (column.AllowNull)
                            {
                                TemplateProperty prop = writer.AddProperty("Nullable<Double>", propertyName);
                            }
                            else
                            {
                                TemplateProperty prop = writer.AddProperty("Double", propertyName);
                            }


                        }
                        else if (column.DataType.StartsWith("DATE"))
                        {
                            if (column.AllowNull)
                            {
                                TemplateProperty prop = writer.AddProperty("Nullable<DateTime>", propertyName);
                            }
                            else
                            {
                                TemplateProperty prop = writer.AddProperty("DateTime", propertyName);
                            }


                        }
                        else if (column.DataType.StartsWith("BOOL"))
                        {
                            if (column.AllowNull)
                            {
                                TemplateProperty prop = writer.AddProperty("Nullable<Boolean>", propertyName);
                            }
                            else
                            {
                                TemplateProperty prop = writer.AddProperty("Boolean", propertyName);
                            }


                        }
                        else Console.WriteLine(column.DataType);
                    }
                    writer.WriteContent();
                }
            }
        }

        private void ChangeDataPathExecute()
        {
            IntPtr mainWindowPtr = new WindowInteropHelper(System.Windows.Application.Current.MainWindow).Handle; 
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = this.DataPath;
            if (dialog.ShowDialog(new Win32Window(mainWindowPtr)) == DialogResult.OK)
            {
                this.DataPath = dialog.SelectedPath;
                this.RaisePropertyChanged("DataPath");
            }

        }
       

      


        private void ChangeDataInfraPathExecute()
        {
            IntPtr mainWindowPtr = new WindowInteropHelper(System.Windows.Application.Current.MainWindow).Handle;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = this.DataPath;
            if (dialog.ShowDialog(new Win32Window(mainWindowPtr)) == DialogResult.OK)
            {
                this.DataInfraPath = dialog.SelectedPath;
                this.RaisePropertyChanged("DataInfraPath");
            }

        }


       

    }
}

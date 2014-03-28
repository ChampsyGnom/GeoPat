using Emash.GeoPat.Generator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPat.Generator.IO
{
    public class SqlPostgreWriter
    {
        private int IndentLevel { get; set; }
        public Project Project { get; private set; }

        private StreamWriter Writer { get; set; }
        public SqlPostgreWriter(Project project)
        {
            this.Project = project;
          
     
        }

        public void Write()
        {
            String appPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            DirectoryInfo directory = new DirectoryInfo(appPath);
            DirectoryInfo directoryCode = directory;
            while (!directoryCode.Name.Equals("GeoPat"))
            { directoryCode = directoryCode.Parent; }
            String directorySql = Path.Combine(directoryCode.FullName, "Sql");
            String fileName = Path.Combine(directorySql, "Postgre.sql");
         
             using (FileStream stream = new FileStream(fileName, FileMode.Create))
             {
                 using (StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.Unicode))
                 {
                     this.Writer = writer;
                     foreach (DbSchema schema in this.Project.Schemas)
                     {
                         this.WriteLine("DROP SCHEMA "+schema.Name+" CASCADE;");
                     }
                     this.WriteLine("");
                     foreach (DbSchema schema in this.Project.Schemas)
                     {
                         this.WriteLine("CREATE SCHEMA " + schema .Name+ " AUTHORIZATION postgres;");
                         this.WriteLine("COMMENT ON SCHEMA " + schema.Name + " IS '"+schema.DisplayName .Replace ("'","''")+"';");
                     }
                     this.WriteLine("");

                     foreach (DbSchema schema in this.Project.Schemas)
                     {
                         this.WriteLine("");
                         foreach (DbTable table in schema.Tables)
                         {
                             /*
                              * CREATE TABLE INF.INF_ACCIDENT
(
INF_ACCIDENT__ANNEE integer NOT NULL,
INF_ACCIDENT__ABS_DEB integer NOT NULL,
INF_ACCIDENT__ABS_FIN integer,
INF_ACCIDENT__ID serial NOT NULL,
INF_CHAUSSEE__ID integer NOT NULL,
INF_ACCIDENT__MOIS integer NOT NULL,
INF_ACCIDENT__NB integer,
INF_ACCIDENT__NB_MOIS integer
);
COMMENT ON TABLE INF.INF_ACCIDENT IS 'Accident';
COMMENT ON COLUMN INF.INF_ACCIDENT.INF_ACCIDENT__ANNEE IS 'Année';
COMMENT ON COLUMN INF.INF_ACCIDENT.INF_ACCIDENT__ABS_DEB IS 'Début';
COMMENT ON COLUMN INF.INF_ACCIDENT.INF_ACCIDENT__ABS_FIN IS 'Fin';
COMMENT ON COLUMN INF.INF_ACCIDENT.INF_ACCIDENT__ID IS 'Identifiant';
COMMENT ON COLUMN INF.INF_ACCIDENT.INF_CHAUSSEE__ID IS 'Identifiant2';
COMMENT ON COLUMN INF.INF_ACCIDENT.INF_ACCIDENT__MOIS IS 'Mois';
COMMENT ON COLUMN INF.INF_ACCIDENT.INF_ACCIDENT__NB IS 'Nb accident';
COMMENT ON COLUMN INF.INF_ACCIDENT.INF_ACCIDENT__NB_MOIS IS 'Nb accident par mois';*/
                             this.WriteLine("CREATE TABLE "+schema.Name+"."+table.Name+"");
                             this.WriteLine("(");
                             List<String> columnDefinitions = new List<string> ();
                             foreach (DbColumn column in table.Columns)
                             {
                                 if (column.Name.StartsWith(table.Name+"__"))
                                 { columnDefinitions.Add(column.Name.Substring(table.Name.Length+2) + " " + column.ToPostgreSqlDefinition()); }
                                 else
                                 { columnDefinitions.Add(column.Name + " " + column.ToPostgreSqlDefinition()); }
                             }
                             //= (from c in table.Columns select c.Name+" "+ c.ToPostgreSqlDefinition()).ToList();
                             this.WriteLine(String.Join (",\r\n",columnDefinitions));
                             this.WriteLine(");");
                             this.WriteLine("COMMENT ON TABLE " + schema.Name + "." + table.Name + " IS '"+table.DisplayName .Replace ("'","''")+"';");
                             foreach (DbColumn column in table.Columns)
                             {
                                 String columnName = column.Name;
                                 if (columnName.StartsWith(table.Name + "__"))
                                 { columnName = columnName.Substring(table.Name.Length + 2); }
                                 this.WriteLine("COMMENT ON COLUMN " + schema.Name + "." + table.Name + "." + columnName + " IS '" + column.DisplayName.Replace("'", "''") + "';");
                             }
                             this.WriteLine("");
                             
                         }
                     }
                     foreach (DbSchema schema in this.Project.Schemas)
                     {
                         foreach (DbKeyPrimary pk in schema.PrimaryKeys)
                         {
                             DbTable table = (from t in schema.Tables where t.Id.Equals (pk.TableId ) select t).FirstOrDefault();
                             List<DbColumn> columns = (from c in table.Columns where pk.ColumnIds.Contains (c.Id ) select c).ToList();
                             List<String> columnNames = new List<string>();
                             foreach (DbColumn column in columns)
                             {
                                 if (column.Name.StartsWith(table.Name + "__"))
                                 { columnNames.Add(column.Name.Substring(table.Name.Length + 2)); }
                                 else
                                 { columnNames.Add(column.Name); }
                             }
                             this.WriteLine("ALTER TABLE "+schema.Name+"."+table.Name+"  ADD CONSTRAINT "+table.Name+"_PK PRIMARY KEY ("+String.Join (",",columnNames )+");");
                             //
                         }
                         foreach (DbKeyForeign  fk in schema.ForeignKeys)
                         {
                             DbTable tableParent = (from t in schema.Tables where t.Id.Equals(fk.TableIdParent) select t).FirstOrDefault();
                             DbTable tableChild = (from t in schema.Tables where t.Id.Equals(fk.TableIdChild) select t).FirstOrDefault();
                             List<String> columnNamesChild = new List<string> ();
                             List<String> columnNamesParent = new List<string> ();
                             foreach (DbKeyForeignJoin j in fk.Joins)
                             {
                                 DbColumn parentColumn = (from c in tableParent.Columns where c.Id.Equals (j.ColumnIdParent ) select c).FirstOrDefault();
                                 DbColumn childColumn = (from c in tableChild.Columns where c.Id.Equals(j.ColumnIdChild) select c).FirstOrDefault();

                                 String columnNameParent = parentColumn.Name;
                                 if (columnNameParent.StartsWith(tableParent.Name + "__"))
                                 { columnNameParent = columnNameParent.Substring(tableParent.Name.Length + 2); }


                                 String columnNameChild = childColumn.Name;
                                 if (columnNameChild.StartsWith(tableChild.Name + "__"))
                                 {columnNameChild = columnNameChild.Substring(tableChild.Name.Length + 2); }
                               
                                 columnNamesChild.Add (columnNameChild);
                                 columnNamesParent.Add (columnNameParent);
                             }
                             this.WriteLine("ALTER TABLE " + schema.Name + "." + tableChild.Name + " ADD CONSTRAINT " + tableChild.Name + "__"+tableParent.Name+"_FK FOREIGN KEY ("+String.Join (",",columnNamesChild)+") ");
                             if (fk.DeleteOnCascade)
                             { this.WriteLine(" REFERENCES " + schema.Name + "." + tableParent.Name + " (" + String.Join(",", columnNamesParent) + ") MATCH SIMPLE ON UPDATE CASCADE ON DELETE CASCADE;"); }
                             else
                             { this.WriteLine(" REFERENCES " + schema.Name + "." + tableParent.Name + " (" + String.Join(",", columnNamesParent) + ") MATCH SIMPLE;"); }
                         
                             //ALTER TABLE INF.INF_ACCIDENT ADD CONSTRAINT INF_CHAUSSEE__INF_ACCIDENT FOREIGN KEY (INF_CHAUSSEE__ID) 
//REFERENCES INF.INF_CHAUSSEE (INF_CHAUSSEE__ID) MATCH SIMPLE ON UPDATE CASCADE ON DELETE CASCADE;
                         }
                     }
                 }
             }
        }

        private void WriteLine(string content)
        {
            this.Writer.WriteLine(new String(" ".ToCharArray()[0], IndentLevel * 4) + content);
        }
    }

}

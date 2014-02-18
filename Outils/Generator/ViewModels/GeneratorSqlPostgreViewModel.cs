using Emash.GeoPatNet.Generator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using System.Windows.Interop;
using System.Windows.Forms;
using Emash.GeoPatNet.Generator.Views;
using System.IO;
using Microsoft.Practices.ServiceLocation;

namespace Emash.GeoPatNet.Generator.ViewModels
{
    public class GeneratorSqlPostgreViewModel : ViewModelBase
    {
        public DelegateCommand ChangeSqlPathCommand { get; set; }
        public DelegateCommand GenerateCommand { get; set; }
        private Project _project;
        public String SqlPath { get; set; }
        public GeneratorSqlPostgreViewModel(Project project)
        {
            // TODO: Complete member initialization
            this._project = project;
            this.SqlPath = _project.SqlPath;
            this.ChangeSqlPathCommand = new DelegateCommand(ChangeSqlPathExecute);
            this.GenerateCommand = new DelegateCommand(GenerateExecute);
        }

        private void GenerateExecute()
        {
            FileStream stream = new FileStream(Path.Combine(this.SqlPath, "Database.sql"), FileMode.Create);
            StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.UTF8);
            List<String> sqls = new List<string>();
            this._project.SqlPath = this.SqlPath;
            ServiceLocator.Current.GetInstance<MainViewModel>().SaveProjectExecute();

            //DROP SCHEMA mystuff CASCADE;
            writer.WriteLine("-- Supression schemas");
            foreach (DbSchema schema in _project.Schemas)
            {
                writer.WriteLine("DROP SCHEMA " + schema.Name + " CASCADE;");
            }
            //CREATE SCHEMA inf  AUTHORIZATION postgres;
            writer.WriteLine("-- Schemas");
            foreach (DbSchema schema in _project.Schemas)
            {
                writer.WriteLine("CREATE SCHEMA " + schema .Name+ " AUTHORIZATION postgres;");
                writer.WriteLine("COMMENT ON SCHEMA " + schema.Name + " IS '" + schema.DisplayName.Replace("'", "''") + "';");
            }
            writer.WriteLine();
            writer.WriteLine("-- Tables");
            foreach (DbSchema schema in _project.Schemas)
            {
                
                foreach (DbTable table in schema.Tables)
                {
                    writer.WriteLine ("-- Table "+schema.Name +"."+table.Name+" -> "+schema.DisplayName +" "+table.DisplayName );
                    writer.WriteLine("CREATE TABLE " + schema.Name + "." + table.Name + "");
                    writer.WriteLine("(");
                    sqls.Clear();
                    foreach (DbColumn column in table.Columns)
                    {
                        sqls.Add(column.GetSqlPostgreDefinition());
                    }
                    writer.WriteLine (String.Join (",\r\n",sqls));
                    sqls.Clear ();
                    writer.WriteLine(");");
                    writer.WriteLine("COMMENT ON TABLE " + schema.Name + "." + table.Name + " IS '"+table.DisplayName.Replace ("'","''")+"';");
                    foreach (DbColumn column in table.Columns)
                    {
                        writer.WriteLine("COMMENT ON COLUMN " + schema.Name + "." + table.Name + "." + column.Name + " IS '" + column.DisplayName.Replace("'", "''") + "';");
                   
                    }
                    //comment on column comtest1.id is 'Identifier Number One';
                    writer.WriteLine("");

                    /*CREATE TABLE inf.cd_evt_inf
(
  id serial NOT NULL,
  code character varying(50) NOT NULL,
  libelle character varying(255) NOT NULL,
  impact boolean NOT NULL,
  CONSTRAINT cd_evt_inf_pk PRIMARY KEY (id),
  CONSTRAINT cd_evt_inf_uk1 UNIQUE (code),
  CONSTRAINT cd_evt_inf_uk2 UNIQUE (libelle)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE inf.cd_evt_inf
  OWNER TO postgres;
                     * 
                     * */
                }
            }
            writer.WriteLine("-- Clé primaires");
            foreach (DbSchema schema in _project.Schemas)
            {

                foreach (DbTable table in schema.Tables)
                {
                    List<String> pkColumns = (from c in table.Columns where table.PrimaryKey.ColumnIds.Contains  (c.Id ) select c.Name).ToList();
                    writer.WriteLine("ALTER TABLE " + schema.Name + "." + table.Name + "  ADD CONSTRAINT "+table.PrimaryKey.Name+" PRIMARY KEY ("+String.Join (",",pkColumns)+");");
                }
            }
            writer.WriteLine();


            writer.WriteLine("-- Clé uniques");
            foreach (DbSchema schema in _project.Schemas)
            {

                foreach (DbTable table in schema.Tables)
                {
                    foreach (DbUniqueKey uk in table.UniqueKeys)
                    {
                        List<String> ukColumns = (from c in table.Columns where uk.ColumnIds.Contains(c.Id) select c.Name).ToList();
                        writer.WriteLine("ALTER TABLE " + schema.Name + "." + table.Name + "  ADD CONSTRAINT " + uk.Name + " UNIQUE (" + String.Join(",", ukColumns) + ");");
                    }
                   
                    
                }
            }
            writer.WriteLine();
            //ALTER TABLE inf.pave_voie_inf  ADD CONSTRAINT pave_voie_inf_uk1 UNIQUE(chaussee_inf__id, cd_voie_inf__id, abs_deb);


            // ALTER TABLE inf.pave_voie_inf   ADD CONSTRAINT pave_voie_inf__chaussee_inf__fk FOREIGN KEY (chaussee_inf__id)  
          //  
    //  ON UPDATE CASCADE ON DELETE CASCADE;

            writer.WriteLine("-- Clé étrangères");
            foreach (DbSchema schema in _project.Schemas)
            {

                foreach (DbTable table in schema.Tables)
                {
                    foreach (DbForeignKey fk in table.ForeignKeys)
                    {
                        DbTable parentTable = (from t in schema.Tables where t.Id.Equals (fk.ParentTableId ) select t).FirstOrDefault();
                        DbTable childTable = (from t in schema.Tables where t.Id.Equals(fk.ChildTableId) select t).FirstOrDefault();
                      
                        List<String> childColumns = new List<string>();
                        List<String> parentColumns = new List<string>();
                        foreach (DbForeignKeyJoin j in fk.Joins)
                        {
                            childColumns.Add((from c in childTable.Columns where c.Id.Equals (j.ChildColumnId ) select c.Name).FirstOrDefault());
                            parentColumns.Add((from c in parentTable.Columns where c.Id.Equals(j.ParentColumnId) select c.Name).FirstOrDefault());
                        }

                        writer.WriteLine("ALTER TABLE " + schema.Name + "." + childTable.Name + " ADD CONSTRAINT " + fk.Name + " FOREIGN KEY (" + String.Join(",", childColumns) + ") ");
                        writer.WriteLine("REFERENCES " + schema.Name + "." + parentTable.Name + " (" + String.Join(",", parentColumns) + ") MATCH SIMPLE ON UPDATE CASCADE ON DELETE CASCADE;");
                    }


                }
            }
            writer.WriteLine();

            writer.WriteLine("-- Droit de l'utilisateur postgres");
            foreach (DbSchema schema in _project.Schemas)
            {
                
                foreach (DbTable table in schema.Tables)
                {
                    writer.WriteLine("ALTER TABLE " + schema.Name + "." + table .Name+ " OWNER TO postgres;");
                }

             }
            writer.WriteLine();

            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();
        }

        private void ChangeSqlPathExecute()
        {
            IntPtr mainWindowPtr = new WindowInteropHelper(System.Windows.Application.Current.MainWindow).Handle; // 'this' means WPF Window
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = this.SqlPath;
            if (dialog.ShowDialog(new Win32Window(mainWindowPtr)) == DialogResult.OK)
            {
                this.SqlPath = dialog.SelectedPath;
                this.RaisePropertyChanged("SqlPath");
            }
        }

    }
}

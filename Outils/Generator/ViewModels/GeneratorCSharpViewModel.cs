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
        public String BuisnessNamespace { get; set; }
        public String BuisnessPath { get; set; }


        public String DataInfraNamespace { get; set; }
        public String DataInfraPath { get; set; }
        public String BuisnessInfraNamespace { get; set; }
        public String BuisnessInfraPath { get; set; }
        public DelegateCommand ChangeDataInfraPathCommand { get; set; }
        public DelegateCommand ChangeBuisnessInfraPathCommand { get; set; }
        public DelegateCommand ChangeDataPathCommand { get; set; }
        public DelegateCommand ChangeBuisnessPathCommand { get; set; }
        public DelegateCommand GenerateCommand { get; set; }

        

        public GeneratorCSharpViewModel(Project model)
        {
            this._model = model;
            this.DataNamespace = model.DataNamespace;
            this.DataPath = model.DataPath;
            this.BuisnessNamespace = model.BuisnessNamespace;
            this.BuisnessPath = model.BuisnessPath;
            this.DataInfraPath = model.DataInfraPath;
            this.DataInfraNamespace = model.DataInfraNamespace;
            this.BuisnessInfraPath = model.BuisnessInfraPath;
            this.BuisnessInfraNamespace = model.BuisnessInfraNamespace;

            this.ChangeBuisnessPathCommand = new DelegateCommand(ChangeBuisnessPathExecute);
            this.ChangeDataPathCommand = new DelegateCommand(ChangeDataPathExecute);
            this.ChangeBuisnessInfraPathCommand = new DelegateCommand(ChangeBuisnessInfraPathExecute);
            this.ChangeDataInfraPathCommand = new DelegateCommand(ChangeDataInfraPathExecute);

            this.GenerateCommand = new DelegateCommand(GenerateExecute);
        }

        private void GenerateExecute()
        {
            this._model.DataNamespace = this.DataNamespace;
            this._model.DataPath = this.DataPath;
            this._model.BuisnessNamespace = this.BuisnessNamespace;
            this._model.BuisnessPath = this.BuisnessPath;
            this._model.DataInfraPath = this.DataInfraPath;
            this._model.DataInfraNamespace = this.DataInfraNamespace;
            this._model.BuisnessInfraPath = this.BuisnessInfraPath;
            this._model.BuisnessInfraNamespace = this.BuisnessInfraNamespace;
            ServiceLocator.Current.GetInstance<MainViewModel>().SaveProjectExecute();

            this.GenerateDataInfra();
            this.GenerateData();
            this.GenerateDataContext();
           // this.GenerateBuisnessInfra(); 
           // this.GenerateBuisness();
        }
        /*
        private void GenerateBuisness()
        {
            string modelPath = Path.Combine(this.BuisnessPath, "BuisnessObjects");
            String[] files = Directory.GetFiles(modelPath);
            foreach (String file in files)
            { File.Delete(file); }
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            String resourcesPath = Path.Combine(appStartPath, "Resources");
            string templatesPath = Path.Combine(resourcesPath, "Templates");
            string templateFileName = Path.Combine(templatesPath, "BuisnessObjectImplementation.tpl");


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
                    String className = NameConverter.TableNameToEntityName(table.Name) + "BuisnessObject";
                    String interfaceName = "I"+NameConverter.TableNameToEntityName(table.Name) + "BuisnessObject";
                    
                    String modelFileName = Path.Combine(modelPath, className + ".cs");
                    TemplateFileWriter writer = new TemplateFileWriter(modelFileName, templateFileName);
                    writer.ReplaceTag("@DisplayName", table.DisplayName);
                    writer.ReplaceTag("@NameSpaceInfra", this.BuisnessInfraNamespace);
                    writer.ReplaceTag("@NameSpace", this.BuisnessNamespace);
                    writer.ReplaceTag("@InterfaceName", interfaceName);
                    writer.ReplaceTag("@ClassName", className);

                    List<DbForeignKey> childFks = (from fk in allFks where fk.ParentTableId.Equals (table.Id ) select fk).ToList();

                    foreach (DbForeignKey childFk in childFks)
                    {
                        DbTable childTable = (from t in schema.Tables where t.Id.Equals (childFk.ChildTableId ) select t).FirstOrDefault();
                        String childEntityName = NameConverter.TableNameToEntityName(childTable.Name);
                        TemplateProperty prop = writer.AddProperty("public virtual ICollection<"+childEntityName+">", childEntityName+"s");
                        prop.Attributes.Add("[DisplayName(\"" + childTable.DisplayName + "\")]");
                        
                    }
                    //public virtual ICollection<AireInfPlace> AireInfPlaces
                    
                    foreach (DbColumn column in table.Columns)
                    {

                        String propertyName = NameConverter.ColumnNameToPropertyName (column.Name.Replace (table.Name ,"") );
                        if (column.DataType.Equals("INT4"))
                        {
                            if (column.AllowNull)
                            {
                                TemplateProperty prop = writer.AddProperty("public Nullable<Int64>", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                            }
                            else
                            {
                                TemplateProperty prop = writer.AddProperty("public Int64", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                            }
                        }
                        else if (column.DataType.Equals("SERIAL"))
                        {


                            TemplateProperty prop = writer.AddProperty("public Int64", propertyName);
                            prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                            
                        }
                        else if (column.DataType.StartsWith("VARCHAR"))
                        {

                            TemplateProperty prop = writer.AddProperty("public String", propertyName);
                            prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");

                        }
                        else if (column.DataType.StartsWith("FLOAT8"))
                        {
                            if (column.AllowNull)
                            {
                                TemplateProperty prop = writer.AddProperty("public Nullable<Double>", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                            }
                            else
                            {
                                TemplateProperty prop = writer.AddProperty("public Double", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                            }
                            

                        }
                        else if (column.DataType.StartsWith("DATE"))
                        {
                            if (column.AllowNull)
                            {
                                TemplateProperty prop = writer.AddProperty("public Nullable<DateTime>", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                            }
                            else
                            {
                                TemplateProperty prop = writer.AddProperty("public DateTime", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                            }


                        }
                        else if (column.DataType.StartsWith("BOOL"))
                        {
                            if (column.AllowNull)
                            {
                                TemplateProperty prop = writer.AddProperty("public Nullable<Boolean>", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                            }
                            else
                            {
                                TemplateProperty prop = writer.AddProperty("public Boolean", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                            }


                        }
                        else Console.WriteLine(column.DataType);
                    }
                    writer.WriteContent();
                }
            }
        }

       
        private void GenerateBuisnessInfra()
        {
            string buisnessObjectsPath = Path.Combine(this.BuisnessInfraPath, "BuisnessObjects");
            String[] files = Directory.GetFiles(buisnessObjectsPath);
            foreach (String file in files)
            { File.Delete(file); }
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            String resourcesPath = Path.Combine(appStartPath, "Resources");
            string templatesPath = Path.Combine(resourcesPath, "Templates");
            string templateFileName = Path.Combine(templatesPath, "BuisnessObjectInfrastructure.tpl");

            foreach (DbSchema schema in this._model.Schemas)
            {
                foreach (DbTable table in schema.Tables)
                {
                    String interfaceName = "I" + NameConverter.TableNameToEntityName(table.Name) + "BuisnessObject";
                    String modelFileName = Path.Combine(buisnessObjectsPath, interfaceName + ".cs");
                    TemplateFileWriter writer = new TemplateFileWriter(modelFileName, templateFileName);
                    writer.ReplaceTag("@DisplayName", table.DisplayName);
                    writer.ReplaceTag("@NameSpace", this.BuisnessInfraNamespace);
                    writer.ReplaceTag("@InterfaceName", interfaceName);
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
        */
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

                    List<DbForeignKey> childFks = (from fk in allFks where fk.ParentTableId.Equals(table.Id) select fk).ToList();

                    foreach (DbForeignKey childFk in childFks)
                    {
                        DbTable childTable = (from t in schema.Tables where t.Id.Equals(childFk.ChildTableId) select t).FirstOrDefault();
                        String childEntityName = NameConverter.TableNameToEntityName(childTable.Name);
                        TemplateProperty prop = writer.AddProperty("public virtual ICollection<" + childEntityName + ">", childEntityName + "s");
                        prop.Attributes.Add("[DisplayName(\"" + childTable.DisplayName + "\")]");

                    }

                    List<DbForeignKey> parentFks = (from fk in allFks where fk.ChildTableId.Equals(table.Id) select fk).ToList();

                    foreach (DbForeignKey parentFk in parentFks)
                    {
                        DbTable parentTable = (from t in schema.Tables where t.Id.Equals(parentFk.ParentTableId) select t).FirstOrDefault();
                        String parentEntityName = NameConverter.TableNameToEntityName(parentTable.Name);
                        TemplateProperty prop = writer.AddProperty("public virtual " + parentEntityName, parentEntityName);
                        prop.Attributes.Add("[DisplayName(\"" + parentTable.DisplayName + "\")]");

                    }

                    writer.ReplaceTag("@DisplayName", table.DisplayName);
                    writer.ReplaceTag("@NameSpaceInfrastructure", this.DataInfraNamespace);
                    writer.ReplaceTag("@NameSpace", this.DataNamespace);
                    writer.ReplaceTag("@EntityName", className);
                    foreach (DbColumn column in table.Columns)
                    {

                        String propertyName = NameConverter.ColumnNameToPropertyName(column.Name.Replace(table.Name, ""));
                        if (column.DataType.Equals("INT4"))
                        {
                            if (column.AllowNull)
                            {
                                TemplateProperty prop = writer.AddProperty("public Nullable<Int64>", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                            }
                            else
                            {
                                TemplateProperty prop = writer.AddProperty("public Int64", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                            }
                        }
                        else if (column.DataType.Equals("SERIAL"))
                        {

                            TemplateProperty prop = writer.AddProperty("public Int64", propertyName);
                            prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");

                        }
                        else if (column.DataType.StartsWith("VARCHAR"))
                        {

                            TemplateProperty prop = writer.AddProperty("public String", propertyName);
                            prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");

                        }
                        else if (column.DataType.StartsWith("FLOAT8"))
                        {
                            if (column.AllowNull)
                            {
                                TemplateProperty prop = writer.AddProperty("public Nullable<Double>", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                            }
                            else
                            {
                                TemplateProperty prop = writer.AddProperty("public Double", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                            }


                        }
                        else if (column.DataType.StartsWith("DATE"))
                        {
                            if (column.AllowNull)
                            {
                                TemplateProperty prop = writer.AddProperty("public Nullable<DateTime>", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                            }
                            else
                            {
                                TemplateProperty prop = writer.AddProperty("public DateTime", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                            }


                        }
                        else if (column.DataType.StartsWith("BOOL"))
                        {
                            if (column.AllowNull)
                            {
                                TemplateProperty prop = writer.AddProperty("public Nullable<Boolean>", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
                            }
                            else
                            {
                                TemplateProperty prop = writer.AddProperty("public Boolean", propertyName);
                                prop.Attributes.Add("[DisplayName(\"" + column.DisplayName + "\")]");
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
       

        private void ChangeBuisnessPathExecute()
        {
            IntPtr mainWindowPtr = new WindowInteropHelper(System.Windows.Application.Current.MainWindow).Handle; // 'this' means WPF Window
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = this.BuisnessPath;
            if (dialog.ShowDialog(new Win32Window(mainWindowPtr)) == DialogResult.OK)
            {
                this.BuisnessPath = dialog.SelectedPath;
                this.RaisePropertyChanged("BuisnessPath");
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


        private void ChangeBuisnessInfraPathExecute()
        {
            IntPtr mainWindowPtr = new WindowInteropHelper(System.Windows.Application.Current.MainWindow).Handle; // 'this' means WPF Window
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = this.BuisnessPath;
            if (dialog.ShowDialog(new Win32Window(mainWindowPtr)) == DialogResult.OK)
            {
                this.BuisnessInfraPath = dialog.SelectedPath;
                this.RaisePropertyChanged("BuisnessInfraPath");
            }
        }

    }
}

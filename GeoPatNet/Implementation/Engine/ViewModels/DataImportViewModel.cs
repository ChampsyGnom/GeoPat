using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Emash.GeoPatNet.Engine.Infrastructure.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace Emash.GeoPatNet.Engine.Implentation.ViewModels
{
    public class DataImportViewModel : IDataImportViewModel,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                Console.WriteLine("RaisePropertyChanged " + name);
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public String Title { get; set; }
        private String _importDirectory;


        public String ImportDirectory
        {
            get { return _importDirectory; }
            set 
            { 
                _importDirectory = value;
                this.RaisePropertyChanged("ImportDirectory");
                this.StartDirectoryScan(); 
            }
        }

        private void StartDirectoryScan()
        {
            Task task = new Task(DirectoryScan);
            task.Start();
        }

        private void DirectoryScan()
        {
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            if (Directory.Exists (this._importDirectory ))
            {
                String[] files = Directory.GetFiles(this._importDirectory,"*.csv");
                foreach (String file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    String entityName = fileInfo.Name.Substring(0,fileInfo.Name.Length - 4);
                    EntityTableInfo entityTableInfo =  dataService.GetEntityTableInfo(entityName);
                    if (entityTableInfo == null)
                    { 
                        // Tentative de mode legacy
                        if (entityName.StartsWith("CD_"))
                        {entityName = "CODE_" + entityName.Substring(3);}
                        List<String> items= entityName.Split("_".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList ();
                        String schemaName = items.Last();
                        items.Remove(items.Last());
                        items.Insert(0, schemaName);
                        List<String> camelCaseItems = new List<string>();
                        foreach (String item in items)
                        {
                            String camelCaseItem = item.Substring(0, 1).ToUpper() + item.Substring(1).ToLower();
                            camelCaseItems.Add(camelCaseItem);
                        }
                        entityName = String.Join("", camelCaseItems);
                        entityTableInfo = dataService.GetEntityTableInfo(entityName);
                        if (entityTableInfo != null)
                        {
                            Console.WriteLine("legacy");
                        }
                    }
                }
            }
           
        }

        public DataImportViewModel()
        {
            this.Title = "Importer des données";
        }
    }
}

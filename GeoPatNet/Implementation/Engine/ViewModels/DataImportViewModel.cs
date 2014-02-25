﻿using System;
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
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Threading;
using Microsoft.Practices.Prism.Commands;
using System.Threading;
using System.Data.Entity;
using System.Reflection;
namespace Emash.GeoPatNet.Engine.Implentation.ViewModels
{
    public class DataImportViewModel : IDataImportViewModel,INotifyPropertyChanged
    {
        public Boolean IsEnabled { get; private set; }
        public DelegateCommand ImportCommand { get; private set; }
        public Dispatcher Dispatcher { get; private set; }
        public ListCollectionView Files { get; private set; }
        private ObservableCollection<DataFileViewModel> _files;
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
        public DataImportViewModel()
        {
            this.Title = "Importer des données";
            this._files = new ObservableCollection<DataFileViewModel>();
            this.Files = new ListCollectionView(this._files);
            this.Dispatcher = System.Windows.Application.Current.Dispatcher;
            this.ImportCommand = new DelegateCommand(ImportExecute);
            this.IsEnabled = true;
        }

        private void ImportExecute()
        {
            #if DEBUG
            this.Import();
            #else
            Task task = new Task(Import);
            task.Start();
            #endif


        }

        private void Import()
        {
           
            this.Dispatcher.Invoke(new Action(delegate() {
                this.IsEnabled = false;
                this.RaisePropertyChanged("IsEnabled");
                this.Files.SortDescriptions.Clear();
                this.Files.SortDescriptions.Add(new SortDescription("Level", ListSortDirection.Ascending));
            }));

            List<DataFileViewModel> vms = (from f in this._files orderby f.Level select f).ToList();
            this.ImportFile(vms);

            this.Dispatcher.Invoke(new Action(delegate()
            {
                this.IsEnabled = true;
                this.RaisePropertyChanged("IsEnabled");
            }));
        }

        private void ImportFile(List<DataFileViewModel> vms)
        {
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            foreach (DataFileViewModel vm in vms)
            {
                if (vm.Import)
                {
                    DbSet dbSet = dataService.GetDbSet(vm.TableInfo.EntityType);
                    dbSet.Load();
                    List<Object> oldObjs = new List<object>();
                    foreach (Object o in dbSet.Local)
                    { oldObjs.Add(o); }

                    foreach (Object o in oldObjs)
                    {
                        dbSet.Remove(o);
                    }
                    dataService.DataContext.SaveChanges();
                    foreach (List<String> datas in vm.Datas)
                    {
                        
                        Object item = Activator.CreateInstance(vm.TableInfo.EntityType);
                        foreach (String propertyName in vm.Mapping.Keys)
                        {
                            int index = vm.Mapping[propertyName];
                        
                            PropertyInfo property = item.GetType().GetProperty(propertyName);
                            Object propertyValue = this.ParseString(property.PropertyType, datas[index]);
                            property.SetValue(item, propertyValue);
                        
                        }
                        dbSet.Add(item);
                    }
                    dataService.DataContext.SaveChanges();
                    
                }
            }
        }

        private object ParseString(Type type, string valueString)
        {
            if (type.Equals(typeof(String)))
            {
                if (String.IsNullOrEmpty(valueString)) return null;
                else return valueString;
            }
            else throw new Exception("Type non géré " + type.Name);
        }

        private void StartDirectoryScan()
        {
            Task task = new Task(DirectoryScan);
            task.Start();
        }

        private void DirectoryScan()
        {
            this.Dispatcher.Invoke(new Action(delegate()
            {
                this._files.Clear();
                this.Files.SortDescriptions.Clear();
            }));
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
                        { entityName = "CODE_" + entityName.Substring(3); }
                        List<String> items = entityName.Split("_".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
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
                            this.Dispatcher.Invoke(new Action(delegate() {
                                DataFileViewModel vm = new DataFileViewModel(file, entityTableInfo, true);
                                this._files.Add(vm);
                            }));
                           
                        }
                    }
                    else
                    {
                        this.Dispatcher.Invoke(new Action(delegate()
                        {
                            DataFileViewModel vm = new DataFileViewModel(file, entityTableInfo, false);
                            this._files.Add(vm);
                        }));
                       
                    }
                }
                foreach (DataFileViewModel vm in this._files)
                { vm.ReadFile(); }
                this.Dispatcher.Invoke(new Action(delegate()
                {
                  
                    this.Files.SortDescriptions.Add(new SortDescription("Level", ListSortDirection.Ascending));
                }));
            }
           
        }

      
    }
}

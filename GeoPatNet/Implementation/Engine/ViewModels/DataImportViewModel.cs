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
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Threading;
using Microsoft.Practices.Prism.Commands;
using System.Threading;
using System.Data.Entity;
using System.Reflection;
using Emash.GeoPatNet.Data.Infrastructure.Validations;
using System.Linq.Expressions;
namespace Emash.GeoPatNet.Engine.Implentation.ViewModels
{
    public class DataImportViewModel : IDataImportViewModel,INotifyPropertyChanged
    {
        public IDataService DataService { get; private set; }
        public Boolean IsEnabled { get; private set; }
        public DelegateCommand ImportCommand { get; private set; }
        public DelegateCommand CheckAllCommand { get; private set; }
        public DelegateCommand UncheckAllCommand { get; private set; }

        //
        public Dispatcher Dispatcher { get; private set; }
        public ListCollectionView Files { get; private set; }
        private ObservableCollection<DataFileViewModel> _files;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
             
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
            this.DataService = ServiceLocator.Current.GetInstance<IDataService>();
            this.CheckAllCommand = new DelegateCommand(CheckAllExecute);
            this.UncheckAllCommand = new DelegateCommand(UncheckAllExecute);
        }

        private void CheckAllExecute()
        {
            foreach (DataFileViewModel vm in this._files)
            {
                vm.Import = true;
            }
        }
        private void UncheckAllExecute()
        {
            foreach (DataFileViewModel vm in this._files)
            {
                vm.Import = false;
            }
        }

        private void ImportExecute()
        {
            #if DEBUG
            Task task = new Task(Import);
            task.Start();
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
            List<DataFileViewModel> lst = new List<DataFileViewModel>();
            foreach (Object o in this.Files)
            { lst.Add (o as DataFileViewModel); }
            this.ImportFile(lst);
            this.Dispatcher.Invoke(new Action(delegate()
            {
                this.IsEnabled = true;
                this.RaisePropertyChanged("IsEnabled");
            }));
        }

        private void ImportFile(List<DataFileViewModel> vms)
        {
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            dataService.DataContext.Configuration.AutoDetectChangesEnabled = false;
            dataService.DataContext.Configuration.ValidateOnSaveEnabled = false;
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
                    String message = null;
                    int total = vm.Datas.Count;
                    int index = 0;
                    foreach (List<String> datas in vm.Datas)
                    {
                        index++;
                        Object item = Activator.CreateInstance(vm.TableInfo.EntityType);
                        foreach (EntityColumnInfo columnInfo in vm.TableInfo.ColumnInfos)
                        {
                            if (columnInfo.PrimaryKeyName == null)
                            {
                                if (columnInfo.ForeignKeyNames.Count > 0)
                                {
                                    List<EntityColumnInfo> fkParentColumnsInfos = dataService.FindParentForeignColumnInfos(columnInfo);
                                    Boolean allValuePresent = true;
                                    if (allValuePresent)
                                    { }
                                    foreach (EntityColumnInfo fkParentColumnsInfo in fkParentColumnsInfos)
                                    {
                                        String dataPath = dataService.GetPath(fkParentColumnsInfo.TableInfo, columnInfo.TableInfo) + "." + fkParentColumnsInfo.PropertyName;
                                        if (!vm.Mapping.ContainsKey(dataPath))
                                        {
                                            allValuePresent = false;
                                        }
                                    }
                                    EntityTableInfo listTableInfo = dataService.GetEntityTableInfo(columnInfo.PropertyType);
                                    ParameterExpression expressionBase = Expression.Parameter(listTableInfo.EntityType, "item");
                                    //if (allValuePresent)
                                    //{
                                       
                                        DbSet listDbSet = dataService.GetDbSet(columnInfo.PropertyType);
                                        IQueryable queryable = listDbSet.AsQueryable();
                                        List<Expression> expressions = new List<Expression>();
                                        foreach (EntityColumnInfo fkParentColumnsInfo in fkParentColumnsInfos)
                                        {
                                            String dataPath = dataService.GetPath(fkParentColumnsInfo.TableInfo, columnInfo.TableInfo) + "." + fkParentColumnsInfo.PropertyName;
                                            Object propertyValue = null;
                                            if (vm.Mapping.ContainsKey (dataPath) &&  Validator.ValidateEntityColumn(datas[vm.Mapping[dataPath]], fkParentColumnsInfo, out message, out propertyValue))
                                            {
                                                String localDataPath = String.Join(".", (from s in dataPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                                                                         where dataPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList().IndexOf(s) > 0
                                                                                         select s).ToList());

                                                String[] localDataPaths = localDataPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                                Expression expression = null;
                                                foreach (string path in localDataPaths)
                                                {
                                                    if (expression == null)
                                                    {
                                                        expression = Expression.Property(expressionBase, path);
                                                    }
                                                    else
                                                    { expression = Expression.Property(expression, path); }
                                                }
                                                expression = Expression.Equal(expression, Expression.Constant(propertyValue));
                                                expressions.Add(expression);
                                            }

                                        }
                                        if (expressions.Count > 0)
                                        {
                                            Expression expressionAnd = expressions.First();
                                            for (int i = 1; i < expressions.Count; i++)
                                            { expressionAnd = Expression.And(expressionAnd, expressions[i]); }
                                            MethodCallExpression whereCallExpression = Expression.Call(
                                            typeof(Queryable),
                                            "Where",
                                            new Type[] { queryable.ElementType },
                                            queryable.Expression,
                                            Expression.Lambda(expressionAnd, expressionBase));
                                            queryable = queryable.Provider.CreateQuery(whereCallExpression);
                                        }
                                        
                                        foreach (Object o in queryable)
                                        {
                                            columnInfo.Property.SetValue(item, o);
                                        }

                                   
                                  
                                }
                                else
                                {
                                    if (vm.Mapping.ContainsKey(columnInfo.PropertyName))
                                    {


                                        PropertyInfo property = item.GetType().GetProperty(columnInfo.PropertyName);
                                        Object propertyValue = null;
                                        if (Validator.ValidateEntityColumn(datas[vm.Mapping[columnInfo.PropertyName]], columnInfo, out message, out propertyValue))
                                        {
                                            property.SetValue(item, propertyValue);
                                        }

                                    }
                                }
                                
                            }
                            
                           
                        }
                        if (index % 10 == 0)
                        { vm.StateMessage = "Import lignes " + index.ToString() + " / " + total.ToString(); }
                        
                        dbSet.Add(item);
                       // IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> result = dataService.DataContext.GetValidationErrors();
                       
                       
                    }

                    vm.StateMessage = "Import lignes " + index.ToString() + " / " + total.ToString();
                    try { dataService.DataContext.SaveChanges(); }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
             
                }
            }
            dataService.DataContext.Configuration.AutoDetectChangesEnabled = true;
            dataService.DataContext.Configuration.ValidateOnSaveEnabled = true;
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
                        if (entityName.Equals("InfCodeBif"))
                        { 
                            entityName = "InfCodeBifurcation"; 
                        }
                        entityTableInfo = dataService.GetEntityTableInfo(entityName);
                        if (entityTableInfo != null)
                        {
                          
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

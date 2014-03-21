using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Infrastructure.ViewModels;
using Microsoft.Practices.ServiceLocation;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Threading;
using Microsoft.Practices.Prism.Commands;
using System.Threading;
using System.Data.Entity;
using System.Reflection;
using Emash.GeoPatNet.Infrastructure.Validations;
using System.Linq.Expressions;
using Emash.GeoPatNet.Infrastructure.Attributes;
using System.Data;
namespace Emash.GeoPatNet.Engine.ViewModels
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
                    this.Dispatcher.Invoke(new Action(delegate()
                    {
                        this.Files.MoveCurrentTo(vm);
                    }));
                    DbSet dbSet = dataService.GetDbSet(vm.TableInfo.EntityType);
                    dbSet.Load();
                    List<Object> oldObjs = new List<object>();
                    foreach (Object o in dbSet.Local)
                    { oldObjs.Add(o); }

                    foreach (Object o in oldObjs)
                    {dbSet.Remove(o);}
                    dataService.DataContext.SaveChanges();
                    String message = null;
                    int total = vm.Datas.Count;
                    int index = 0;
                    Object result = null;
                    Object propertyValue = null;
                    foreach (List<String> datas in vm.Datas)
                    {
                        index++;
                        Dictionary<String,String> dico = new Dictionary<string,string> ();
                        foreach (string key in  vm.Mapping.Keys )
                        { dico.Add (key,datas[vm.Mapping[key]]); }
                        Object item = Activator.CreateInstance(vm.TableInfo.EntityType);
                        bool allfieldAreValid = true;
                        foreach (EntityFieldInfo fieldInfo in vm.TableInfo.FieldInfos)
                        {
                            if (dico.ContainsKey(fieldInfo.Path))
                            {
                                if (!fieldInfo.ValidateString(dico[fieldInfo.Path], out message, out result))
                                { allfieldAreValid = false; throw new Exception("Valeur invalide"); }
                            }
                        }
                        if (!allfieldAreValid) throw new Exception("Valeur invalide");
                        //fieldInfo.ValidateString(this._values[path], out message, out result))
                        if (vm.TableInfo.Validate(item, dico, out message))
                        {
                            vm.TableInfo.SaveToModel(item, dico);
                            dbSet.Add(item);
                           
                            if (index % 10 == 0)
                            { vm.StateMessage = "Import lignes " + index.ToString() + " / " + total.ToString(); }

                        }
                        else {
                            Console.WriteLine("Erreur : " + message);

                        }
                      
                    
                       
                    }
                    try { dataService.DataContext.SaveChanges(); }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    /*
                    foreach (List<String> datas in vm.Datas)
                    {
                        index++;
                        Object item = Activator.CreateInstance(vm.TableInfo.EntityType);
                        foreach (EntityFieldInfo field in vm.TableInfo.FieldInfos)
                        {
                            if (field.IsMainTableField)
                            {
                                if (vm.Mapping.ContainsKey(field.ColumnInfo.PropertyName))
                                {
                                   
                                    Nullable<Int64> valInt64 = 0;
                                    if (field.ColumnInfo.ControlType == ControlType.Pr)
                                    {
                                        if (datas[vm.Mapping[field.ColumnInfo.PropertyName]].IndexOf("+") == -1)
                                        {
                                            if (Validator.ValidateNullableInt64(datas[vm.Mapping[field.ColumnInfo.PropertyName]], out message, out valInt64))
                                            {
                                                field.ColumnInfo.Property.SetValue(item, valInt64);
                                            }
                                        }
                                        else
                                        {
                                            if (field.ValidateString(datas[vm.Mapping[field.ColumnInfo.PropertyName]], out message, out propertyValue))
                                            {
                                                field.ColumnInfo.Property.SetValue(item, propertyValue);
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (field.ValidateString(datas[vm.Mapping[field.ColumnInfo.PropertyName]], out message, out propertyValue))
                                        {
                                            field.ColumnInfo.Property.SetValue(item, propertyValue);
                                        }
                                    }
                                }
                            }
                            else
                            {

                            }
                        }
                        
                        foreach (EntityColumnInfo columnInfo in vm.TableInfo.ColumnInfos)
                        {

                            if (columnInfo.PrimaryKeyName == null && columnInfo.PropertyType != typeof(Byte[]))
                            {
                                if (columnInfo.ForeignKeyNames.Count > 0)
                                {
                                    DbSet listDbSet = dataService.GetDbSet(columnInfo.PropertyType);
                                    EntityTableInfo listTableInfo = dataService.GetEntityTableInfo(columnInfo.PropertyType);
                                    ParameterExpression expressionBase = Expression.Parameter(listTableInfo.EntityType, "item");
                                    List<EntityFieldInfo> fieldInfos = (from f in vm.TableInfo.FieldInfos where f.ColumnInfo != null &&  f.ColumnInfo .Equals (columnInfo ) && f.ParentColumnInfo != null select f).ToList();
                                    List<Expression> expressions = new List<Expression>();
                                    IQueryable queryable = listDbSet.AsQueryable();
                                    foreach (EntityFieldInfo fieldInfo in fieldInfos)
                                    {

                                        if (vm.Mapping.ContainsKey(fieldInfo.Path) && fieldInfo.ValidateString(datas[vm.Mapping[fieldInfo.Path]], out message, out propertyValue))
                                        {
                                            String localDataPath = String.Join(".", (from s in fieldInfo.Path.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                                                                     where fieldInfo.Path.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList().IndexOf(s) > 0
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
                            }
                        }
                        
                        if (index % 10 == 0)
                        { vm.StateMessage = "Import lignes " + index.ToString() + " / " + total.ToString(); }
                       
                        dbSet.Add(item);
                        try { dataService.DataContext.SaveChanges(); }
                        catch (Exception ex)
                        { Console.WriteLine(ex); }   
                        // IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> result = dataService.DataContext.GetValidationErrors();


                    }
                    */
                    vm.StateMessage = "Import lignes " + index.ToString() + " / " + total.ToString();
                }
            }
            dataService.DataContext.Configuration.AutoDetectChangesEnabled = true;
            dataService.DataContext.Configuration.ValidateOnSaveEnabled = true;

            /*
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            dataService.DataContext.Configuration.AutoDetectChangesEnabled = false;
            dataService.DataContext.Configuration.ValidateOnSaveEnabled = false;
            foreach (DataFileViewModel vm in vms)
            {
                if (vm.Import)
                {
                    
                    
             
                }
            }
            dataService.DataContext.Configuration.AutoDetectChangesEnabled = true;
            dataService.DataContext.Configuration.ValidateOnSaveEnabled = true;
             * */
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

using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using Emash.GeoPatNet.Data.Infrastructure.Validations;
using Emash.GeoPatNet.Engine.Infrastructure.ComponentModel;
using Emash.GeoPatNet.Engine.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;

namespace Emash.GeoPatNet.Engine.Implentation.ViewModels
{
    public class GenericListItemViewModel<M> : INotifyPropertyChanged, IRowEditableItem,IDataErrorInfo
    {
        public GenericListSources<M> Lists { get; private set; }
        
        private Dictionary<String, Object> _values;
        public event PropertyChangedEventHandler PropertyChanged;
        public Dictionary<String, ObservableCollection<Object>> _comboItemsSource;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                Console.WriteLine("RaisePropertyChanged " + name);
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public M Model { get; private set; }
        public IGenericListViewModel Manager { get; private set; }
        public GenericListItemViewModel(IGenericListViewModel manager, M model)
        {
            this.Model = model;
            this.Manager = manager;
            this._values = new Dictionary<string, Object>();
            this.Lists = new GenericListSources<M>();
            this._comboItemsSource = new Dictionary<string, ObservableCollection<object>>();
        }
     
        public Object  this[String  fieldPath]
        {
            get 
            {
                // Si le nom du champ finit par ItemsSource il s'agit d'une source d'une combo
                if (fieldPath.EndsWith(".ItemsSource"))
                { 
                    return this.GetComboItemsSource(fieldPath);
                }
                else
                {
                    if (!this._values.ContainsKey(fieldPath))
                    { this._values.Add(fieldPath, null); }
                    return this._values[fieldPath];
                }
                
            }
            set
            {
                if (!this._values.ContainsKey(fieldPath))
                { this._values.Add(fieldPath, null); }

                
                this._values[fieldPath] = value;
                this.Lists.Values = this._values;

               

                if (this.Manager.State == Infrastructure.Enums.GenericDataListState.Display && !this.Manager.IsLocked)
                {this.Manager.BeginEdit(this);}


                if (fieldPath.IndexOf(".") == -1)
                {
                    this.RaisePropertyChanged("[" + fieldPath + "]");
                   
                    
                }
                else
                {
             
                    EntityColumnInfo bottomProp = this.Manager.DataService.GetBottomProperty(typeof(M), fieldPath);
                    List<EntityColumnInfo> parentfkProperties = this.Manager.DataService.FindFkParentProperties(bottomProp);
                    List<String> pathToProps = new List<string>();
                    foreach (EntityColumnInfo parentfkProperty in parentfkProperties)
                    {
                        String pathToChild = this.Manager.DataService.GetPath(parentfkProperty.TableInfo, bottomProp.TableInfo);
                        String pathToProp = pathToChild + "." + parentfkProperty.PropertyName;
                        pathToProps.Add(pathToProp);
                    }
                    int nextPropIndex = pathToProps.IndexOf(fieldPath)+1;
                    if (nextPropIndex < pathToProps.Count)
                    {
                        this[pathToProps[nextPropIndex]] = CultureConfiguration.ListNullString;
                        this.RaisePropertyChanged("[" + pathToProps[nextPropIndex] + "]");

                        Console.WriteLine("Reset List " + pathToProps[nextPropIndex] + " -> " + CultureConfiguration.ListNullString);
                      
                    }

                    this.RaisePropertyChanged("[" + fieldPath + "]");
                }
                this.RaisePropertyChanged("Error");
                this.RaiseValuesChanges();

            }
        }

        private Object GetComboItemsSource(string fieldPath)
        {
            // Si la clé n'est pas encore dans le dico des source de combo on l'y ajoute
            if (!this._comboItemsSource.ContainsKey(fieldPath))
            {
                this._comboItemsSource.Add(fieldPath, new ObservableCollection<object>());
                // On lance le premier chargemement
                this.LoadList(fieldPath);
            }
            return this._comboItemsSource[fieldPath];
        }

        private void LoadList(string fieldPath)
        {
            if (fieldPath.EndsWith(".ItemsSource"))
            {
                this._comboItemsSource[fieldPath].Clear();
                IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
                String[] items = fieldPath.Substring(0, fieldPath.Length - ".ItemsSource".Length).Split (".".ToArray (),StringSplitOptions .RemoveEmptyEntries );            
                Console.WriteLine("Load ItemsSource for path " + items[0] + "." + items[1]);
                EntityTableInfo itemsSourceTableInfo = dataService.GetEntityTableInfo(items[0]);
                DbSet itemsSourceDbSet = dataService.GetDbSet(itemsSourceTableInfo.EntityType);
                IQueryable itemsSourceQueryable = itemsSourceDbSet.AsQueryable();
                itemsSourceQueryable = this.TryApplyListFilters(itemsSourceQueryable);
                PropertyInfo itemsSourcePropertyInfo = itemsSourceTableInfo.EntityType.GetProperty (items [1]);

                List<Object> datas = new List<object>();
                foreach (Object data in itemsSourceQueryable)
                {
                    Object value = itemsSourcePropertyInfo.GetValue(data);
                    if (value != null)
                    { datas.Add(value); }
                }
                datas = (from d in datas orderby d select d).Distinct().ToList();
                foreach (Object d in datas)
                { this._comboItemsSource[fieldPath].Add(d); }
                this._comboItemsSource[fieldPath].Insert(0, CultureConfiguration.ListNullString);
            }
           
            /*
            

            String[] items = fieldPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            EntityTableInfo tableInfo = dataService.GetEntityTableInfo(items[0]);
            EntityTableInfo masterTableInfo = dataService.GetEntityTableInfo(typeof(M));
            String masterPath = dataService.GetPath(tableInfo, masterTableInfo);
            String masterPropertyPath = masterPath + "." + items[items.Length - 1];
            DbSet dbSet = dataService.GetDbSet(tableInfo.EntityType);

            IQueryable queryable = dbSet.AsQueryable();
            List<Expression> expressions = new List<Expression>();
            if (this._values != null)
            {
                EntityColumnInfo bottomProp = dataService.GetBottomProperty(typeof(M), masterPropertyPath);
                List<EntityColumnInfo> parentfkProperties = dataService.FindFkParentProperties(bottomProp);

                List<String> pathToProps = new List<string>();
                foreach (EntityColumnInfo parentfkProperty in parentfkProperties)
                {
                    String pathToChild = dataService.GetPath(parentfkProperty.TableInfo, bottomProp.TableInfo);
                    String pathToProp = pathToChild + "." + parentfkProperty.PropertyName;
                    pathToProps.Add(pathToProp);

                }
                int endIndex = pathToProps.IndexOf(fieldPath);
                ParameterExpression expressionBase = Expression.Parameter(tableInfo.EntityType, "item");
                for (int i = 0; i < endIndex; i++)
                {
                    String realPath = pathToProps[i].Substring(tableInfo.EntityType.Name.Length + 1);
                    Console.WriteLine("Add filter to " + fieldPath + " on " + realPath);
                    String[] itemsFilters = realPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    Expression expression = null;
                    for (int j = 0; j < itemsFilters.Length; j++)
                    {
                        if (expression == null)
                        { expression = Expression.Property(expressionBase, itemsFilters[j]); }
                        else

                        { expression = Expression.Property(expression, itemsFilters[j]); }
                    }
                    String key = dataService.GetPath(tableInfo, masterTableInfo) + "." + realPath;
                    Console.WriteLine(key);
                    if (_values.ContainsKey(key) && !key.Equals(fieldPath))
                    {
                        String value = this._values[key].ToString(); ;
                        expression = Expression.Equal(expression, Expression.Constant(value));
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
            }
            Console.WriteLine(queryable.ToString());
            List<Object> objs = new List<object>();
            foreach (Object obj in queryable)
            {
                Object value = obj.GetType().GetProperty(items[1]).GetValue(obj);
                objs.Add(value);
            }
            objs = (from o in objs orderby o select o).Distinct().ToList();
            objs.Insert(0, CultureConfiguration.ListNullString );
            foreach (Object o in objs)
            { this._comboItemsSource[fieldPath].Add(o); }
             * */
        }

        private IQueryable TryApplyListFilters(IQueryable itemsSourceQueryable)
        {
            return itemsSourceQueryable;
        }


        /*
        private void UpdateDepedencyListFilter(string fieldPath)
        {
            this.Lists.UpdateFilter(fieldPath, this._values);
            EntityColumnInfo bottomProp = this.Manager.DataService.GetBottomProperty(typeof(M), fieldPath);
            List<EntityColumnInfo> parentfkProperties = this.Manager.DataService.FindFkParentProperties(bottomProp);         
            List<String> pathToProps = new List<string>();
            foreach (EntityColumnInfo parentfkProperty in parentfkProperties)
            {
                String pathToChild = this.Manager.DataService.GetPath(parentfkProperty.TableInfo, bottomProp.TableInfo);
                String pathToProp = pathToChild + "." + parentfkProperty.PropertyName;
                pathToProps.Add(pathToProp);
                

            }
            int startIndex = pathToProps.IndexOf(fieldPath)+1;
            for (int i = startIndex; i < pathToProps.Count; i++)
            {
                this[pathToProps[i]] = null;
              
            }
           
        }

        */

        public void LoadFromModel(List<String> fieldPaths)
        {
            foreach (String fieldPath in fieldPaths)
            {
                EntityColumnInfo columnInfo = this.Manager.DataService.GetTopParentProperty(typeof(M), fieldPath);
                if (fieldPath.IndexOf(".") == -1)
                {
                    if (columnInfo.PropertyType.Equals(typeof(String)))
                    {
                        if (!this._values.ContainsKey(fieldPath))
                        { this._values.Add(fieldPath, null); }
                        Object value = this.Model.GetType().GetProperty(fieldPath).GetValue(this.Model);
                        if (value == null)
                        { this._values[fieldPath] = ""; }
                        else
                        { this._values[fieldPath] = value.ToString(); }
                       
                    }
                }
                else
                {
                    String[] items = fieldPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    Type baseType = typeof(M);
                    object baseValue = this.Model;
                    for(int i = 0 ; i < items .Length ;i++)
                    {
                        PropertyInfo prop = baseType.GetProperty(items[i]);
                        baseValue = prop.GetValue(baseValue);
                        if (baseValue == null)
                        {break;}
                        baseType = baseValue.GetType();
                    }
                    if (baseValue != null)
                    { this._values[fieldPath] = baseValue.ToString (); }
                    else
                    { this._values[fieldPath] = CultureConfiguration.ListNullString; }
                }
            }
        }



        public void SaveToModel(List<String> fieldPaths)
        {
            EntityTableInfo tableInfo = this.Manager.DataService.GetEntityTableInfo (typeof(M));
            List<EntityColumnInfo> navigationProperties = new List<EntityColumnInfo>();
            foreach (String fieldPath in fieldPaths)
            {
                EntityColumnInfo columnInfo = this.Manager.DataService.GetTopParentProperty(typeof(M), fieldPath);
                if (fieldPath.IndexOf(".") == -1)
                {
                    if (columnInfo.PropertyType.Equals(typeof(String)))
                    {
                        this.Model.GetType().GetProperty(fieldPath).SetValue(this.Model, this[fieldPath]);
                    }
                }
                else
                {
                 
                    String[] fieldPathItems = fieldPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    EntityColumnInfo bottomProp = (from p in tableInfo.ColumnInfos where p.PropertyName.Equals (fieldPathItems[0]) select p).FirstOrDefault();
                    navigationProperties.Add(bottomProp);
                }
            }
            navigationProperties = (from p in navigationProperties select p).Distinct().ToList();
            foreach (EntityColumnInfo navigationProperty in navigationProperties)
            {
                EntityTableInfo parentTableInfo = this.Manager.DataService.GetEntityTableInfo(navigationProperty.PropertyType);
                DbSet set = this.Manager.DataService.GetDbSet(parentTableInfo.EntityType);
                IQueryable queryable = set.AsQueryable();
                List<EntityColumnInfo> parentNavProps =  this.Manager.DataService.FindFkParentProperties(navigationProperty);
                List<String> parentNavPropsPaths = new List<string>();
                foreach (EntityColumnInfo column in parentNavProps)
                {
                    String pathToChild = this.Manager.DataService.GetPath(column.TableInfo, tableInfo);
                    String pathToProp = pathToChild + "." + column.PropertyName;
                   
                }

                ParameterExpression expressionBase = Expression.Parameter(parentTableInfo.EntityType, "item");
                List<Expression> expressions = new List<Expression>();

                foreach (String parentNavPropsPath in parentNavPropsPaths)
                {
                    String[] items = parentNavPropsPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    Expression propertyMember = null;
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (propertyMember == null)
                        { propertyMember = Expression.Property(expressionBase, items[i]); }
                        else
                        { propertyMember = Expression.Property(propertyMember, items[i]); }
                    }
                    Expression expression = Expression.Equal(propertyMember, Expression.Constant(this._values[parentNavPropsPath]));
                    expressions.Add(expression);
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
              
                List<Object> values = new List<object>();
                foreach (Object obj in queryable)
                {this.Model.GetType().GetProperty(navigationProperty.PropertyName).SetValue(this.Model, obj);}
            }
        }

        internal void RaiseValuesChanges()
        {
            foreach (String key in this._values.Keys)
            {
                this.RaisePropertyChanged("Item["+key+"]");
                this.RaisePropertyChanged("[" + key + "]"); 
            }
            this.RaisePropertyChanged("Item[]");
           
        }

       
        string IDataErrorInfo.Error
        {
            get {
                List<String> errors = new List<string>();
                foreach (String key in this._values.Keys)
                { 
                    if (((IDataErrorInfo ) this)[key] != null)
                    {
                        errors.Add(((IDataErrorInfo)this)[key]);
                    }
                }
                if (errors.Count > 0)
                { return String.Join("\r\n", errors); }
                else
                { return null; }
           
            }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get {
                String message = null;
                Object result = null;
                if (this.Model != null && !columnName.EndsWith (".ItemsSource"))
                {
                    Console.WriteLine("Search Error for " + columnName);
                    if (columnName.StartsWith("[") && columnName.EndsWith("]"))
                    {
                        String path = columnName.Substring(1);
                        path = path.Substring(0, path.Length - 1);
                        EntityColumnInfo topColumn = this.Manager.DataService.GetTopParentProperty(typeof(M), path);
                        if (path.IndexOf(".") == -1)
                        {

                            if (!Validator.ValidateObject(this._values[path], topColumn, out message, out result))
                            {
                                return message;
                            }
                        }
                        else
                        {
                            String[] items = path.Split (".".ToCharArray (),StringSplitOptions .RemoveEmptyEntries );
                            EntityTableInfo tableInfo = this.Manager.DataService.GetEntityTableInfo(typeof(M));
                            EntityColumnInfo topProperty = this.Manager.DataService.GetTopParentProperty(typeof(M), path);
                            EntityColumnInfo bottomProp = (from c in tableInfo.ColumnInfos where c.PropertyName.Equals (items[0]) select c).FirstOrDefault();
                            if (!bottomProp.AllowNull && (this._values[path] == null || String.IsNullOrEmpty(this._values[path].ToString ()) || this._values[path].Equals(CultureConfiguration.ListNullString)))
                            {
                                Console.WriteLine("Find Error for " + columnName);
                                return "Valeur vide non autorisée";
                            }
                        }
                    }
                }
               
                return null;
            }
        }
    }
}

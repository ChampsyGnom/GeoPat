using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using System.Data.Entity;
using Emash.GeoPatNet.Data.Infrastructure.Validations;
using System.ComponentModel;
using System.Linq.Expressions;
namespace Emash.GeoPatNet.Engine.Implentation.ViewModels
{
    public class GenericListSources<M> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        private Dictionary<String, Object> _values;


        public Dictionary<String, Object> Values
        {
            get { return _values; }
            set { _values = value; }
        }


     
        public Dictionary<String, ObservableCollection<Object>> _lists;
        public IDataService DataService { get; private set; }
        public GenericListSources()
        {
            _lists = new Dictionary<string, ObservableCollection<object>>();
            this.DataService = ServiceLocator.Current.GetInstance<IDataService>();
        }
        public ObservableCollection<Object> this[String fieldPath]
        {
            get 
            {
                String[] items = fieldPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (!this._lists.ContainsKey(fieldPath))
                {
                    this._lists.Add(fieldPath, new ObservableCollection<object>());
                    this.LoadList(fieldPath);
                }
              
                ObservableCollection<Object> results = this._lists[fieldPath];
                return results;
            }
           
        }

        private void LoadList(string fieldPath)
        {
            this._lists[fieldPath].Clear();
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            
            String[] items = fieldPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            EntityTableInfo tableInfo = dataService.GetEntityTableInfo(items[0]);
            EntityTableInfo masterTableInfo = dataService.GetEntityTableInfo(typeof (M));
            DbSet dbSet = dataService.GetDbSet(tableInfo.EntityType);
          
            IQueryable queryable = dbSet.AsQueryable();
            List<Expression> expressions = new List<Expression>();
            if (this._values != null)
            {
                EntityColumnInfo bottomProp = this.DataService.GetBottomProperty(typeof(M), fieldPath);
                List<EntityColumnInfo> parentfkProperties = this.DataService.FindFkParentProperties(bottomProp);
                List<String> pathToProps = new List<string>();
                foreach (EntityColumnInfo parentfkProperty in parentfkProperties)
                {
                    String pathToChild = this.DataService.GetPath(parentfkProperty.TableInfo, bottomProp.TableInfo);
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
                    String key = this.DataService.GetPath(tableInfo, masterTableInfo) + "." + realPath;
                    Console.WriteLine(key);
                    if (_values.ContainsKey(key) && ! key .Equals (fieldPath ))
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
            objs.Insert(0, null);
            foreach (Object o in objs)
            {this._lists[fieldPath].Add(o);}
        }





        internal void UpdateFilter(string fieldPath, Dictionary<string, Object> values)
        {
            this._values = values;
            
            EntityColumnInfo bottomProp = this.DataService.GetBottomProperty(typeof(M), fieldPath);
            List<EntityColumnInfo> parentfkProperties = this.DataService.FindFkParentProperties(bottomProp);
            List<String> pathToProps = new List<string>();
            foreach (EntityColumnInfo parentfkProperty in parentfkProperties)
            {
                String pathToChild = this.DataService.GetPath(parentfkProperty.TableInfo, bottomProp.TableInfo);
                String pathToProp = pathToChild + "." + parentfkProperty.PropertyName;
                pathToProps.Add(pathToProp);

            }
               
            int startIndex = pathToProps.IndexOf(fieldPath) + 1;
            for (int i = startIndex; i < pathToProps.Count; i++)
            {
                this[pathToProps[i]].Clear();
                this.LoadList(pathToProps[i]);
                this.RaisePropertyChanged("[" + pathToProps[i] + "]");
          
               
            }


        }

        
    }
}

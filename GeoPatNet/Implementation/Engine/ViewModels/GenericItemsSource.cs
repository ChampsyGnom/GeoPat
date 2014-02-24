using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Emash.GeoPatNet.Data.Infrastructure.Validations;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.ComponentModel;

namespace Emash.GeoPatNet.Engine.Implentation.ViewModels
{
    public class GenericItemsSource<M> : INotifyPropertyChanged
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
        private Dictionary<String, Object> _values;


        public Dictionary<String, Object> Values
        {
            get { return _values; }
            set { _values = value; }
        }
        private Dictionary<String, ObservableCollection<Object>> _comboItemsSource;

        public Dictionary<String, ObservableCollection<Object>> ComboItemsSource
        {
            get { return _comboItemsSource; }
  
        }
        public IDataService DataService { get;private  set; }
        public GenericItemsSource()
        {
            this._comboItemsSource = new Dictionary<string, ObservableCollection<object>>();
            this.DataService = ServiceLocator.Current.GetInstance<IDataService>();
        }

        public ObservableCollection<Object> this[String fieldPath]
        {
            get
            {
                if (!this._comboItemsSource.ContainsKey(fieldPath))
                { 
                    this._comboItemsSource.Add(fieldPath, new ObservableCollection<object>());
                    this.LoadList(fieldPath);
                }
              return   this._comboItemsSource[fieldPath];
            }
            set 
            {
                this._comboItemsSource[fieldPath] = value;
            }
        }

        internal bool ContainsKey(string fieldPath)
        {
            return this._comboItemsSource.Keys.Contains(fieldPath);
        }

        internal void Add(string fieldPath, ObservableCollection<object> observableCollection)
        {
            this._comboItemsSource.Add(fieldPath, observableCollection);
        }

        internal void Remove(string itemSourceName)
        {
            this._comboItemsSource.Remove(itemSourceName);
        }

        public  void LoadList(string fieldPath)
        {
           
                this._comboItemsSource[fieldPath].Clear();
                IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
                String[] items = fieldPath.Split(".".ToArray(), StringSplitOptions.RemoveEmptyEntries);
               // Console.WriteLine("Load ItemsSource for path " + items[0] + "." + items[1]);
                EntityTableInfo itemsSourceTableInfo = dataService.GetEntityTableInfo(items[0]);
                DbSet itemsSourceDbSet = dataService.GetDbSet(itemsSourceTableInfo.EntityType);
                IQueryable itemsSourceQueryable = itemsSourceDbSet.AsQueryable();
                itemsSourceQueryable = this.TryApplyListFilters(itemsSourceQueryable, fieldPath);
                PropertyInfo itemsSourcePropertyInfo = itemsSourceTableInfo.EntityType.GetProperty(items[1]);                
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

        private IQueryable TryApplyListFilters(IQueryable itemsSourceQueryable, string fieldPath)
        {
          //  Console.Write("Try apply filter for " + fieldPath);
            String[] items = fieldPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            EntityTableInfo listTableInfo = this.DataService.GetEntityTableInfo (items[0]);
            EntityColumnInfo listColumnInfo = (from c in listTableInfo.ColumnInfos where c.PropertyName.Equals (items[1]) select c).FirstOrDefault();
            EntityTableInfo baseTableInfo = this.DataService.GetEntityTableInfo (typeof (M));
            String basePropertyName =   this.DataService.GetPath (listTableInfo,baseTableInfo)+"."+items[1];
            EntityColumnInfo baseProperty = this.DataService.GetBottomProperty(typeof(M), basePropertyName);
            List<EntityColumnInfo> parentfkProperties = this.DataService.FindParentForeignColumnInfos(baseProperty);
            int index = parentfkProperties.IndexOf(listColumnInfo);
            ParameterExpression expressionBase = Expression.Parameter(listTableInfo.EntityType, "item");
            List<Expression> expressions = new List<Expression>();
            for (int i = 0; i < index; i++)
            {
                EntityColumnInfo parentfkProperty = parentfkProperties[i];
                String parentfkPropertyPath = this.DataService.GetPath(parentfkProperty.TableInfo,baseTableInfo)+"."+parentfkProperty.PropertyName;
                if (this._values.ContainsKey(parentfkPropertyPath))
                {
                    String listPropertyPath = this.DataService.GetPath (parentfkProperty.TableInfo, listTableInfo)+"."+parentfkProperty.PropertyName;
                    String[] listPropertyPathItems = listPropertyPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                 
                    Expression expression = null;
                    foreach (String listPropertyPathItem in listPropertyPathItems)
                    {
                        if (expression == null)
                        {
                            expression = Expression.Property(expressionBase, listPropertyPathItem);
                        }
                        else
                        { expression = Expression.Property(expression, listPropertyPathItem); }
                    }
                    expression = Expression.Equal(expression, Expression.Constant(this._values[parentfkPropertyPath]));
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
                new Type[] { itemsSourceQueryable.ElementType },
                itemsSourceQueryable.Expression,
                Expression.Lambda(expressionAnd, expressionBase));
                itemsSourceQueryable = itemsSourceQueryable.Provider.CreateQuery(whereCallExpression);
            }
            return itemsSourceQueryable;
        }



       
    }
}

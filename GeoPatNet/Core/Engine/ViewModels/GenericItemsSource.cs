using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Infrastructure.Validations;
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

namespace Emash.GeoPatNet.Engine.ViewModels
{
    public class GenericItemsSource<M> : INotifyPropertyChanged
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
        private Dictionary<String, String> _values;


        public Dictionary<String, String> Values
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

        public  void LoadList(string itemSourceName)
        {
            if (!this._comboItemsSource.ContainsKey(itemSourceName))
            {this._comboItemsSource.Add(itemSourceName, new ObservableCollection<object>());}
            this._comboItemsSource[itemSourceName].Clear();
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            String[] items = itemSourceName.Split(".".ToArray(), StringSplitOptions.RemoveEmptyEntries);
             
            EntityTableInfo itemsSourceTableInfo = dataService.GetEntityTableInfo(items[0]);
            DbSet itemsSourceDbSet = dataService.GetDbSet(itemsSourceTableInfo.EntityType);
            IQueryable itemsSourceQueryable = itemsSourceDbSet.AsQueryable();
            itemsSourceQueryable = this.TryApplyListFilters(itemsSourceQueryable, itemSourceName);
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
            { this._comboItemsSource[itemSourceName].Add(d); }
            this._comboItemsSource[itemSourceName].Insert(0, CultureConfiguration.ListNullString);
            

        }

        private IQueryable TryApplyListFilters(IQueryable itemsSourceQueryable, string itemSourceName)
        {
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            String[] itemSourceNameItems = itemSourceName.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            EntityTableInfo itemSourceTableInfo = this.DataService.GetEntityTableInfo(itemSourceNameItems[0]);
            ParameterExpression itemSourceExpressionBase = Expression.Parameter(itemSourceTableInfo.EntityType, "item");           
            EntityTableInfo tableInfo = dataService.GetEntityTableInfo(typeof(M));
            EntityFieldInfo fieldInfo = (from f in tableInfo.FieldInfos where f.Path.EndsWith (itemSourceName) select f).FirstOrDefault();
             List<EntityFieldInfo> fieldInfoUks = new List<EntityFieldInfo>();
            List<EntityColumnInfo> columnInfoUks = DataService.GetAllParentUniqueKeyColumnInfos(fieldInfo.ColumnInfo);
            List<Expression> expressions = new List<Expression>();
            foreach (EntityColumnInfo columnInfoUk in columnInfoUks)
            {
                EntityFieldInfo fieldInfoUk = (from f in tableInfo.FieldInfos where f.ParentColumnInfo.Equals(columnInfoUk) select f).FirstOrDefault();
                fieldInfoUks.Add(fieldInfoUk);
            }
            fieldInfoUks = (from f in fieldInfoUks orderby f.ParentColumnInfo.TableInfo.Level select f).ToList();
            Console.WriteLine(fieldInfoUks);
            foreach (EntityFieldInfo fieldInfoUk in fieldInfoUks)
            {
                if (fieldInfoUks.IndexOf(fieldInfo) > fieldInfoUks.IndexOf(fieldInfoUk) && _values.ContainsKey (fieldInfoUk.Path ))
                {
                    Object result  = null;
                    String message = null;
                    if (fieldInfoUk.ValidateString(_values[fieldInfoUk.Path], out message, out result))
                    {
                       List<String> fieldInfoUkItems = fieldInfoUk.Path.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList ();
                       int indexItemSourceTable = fieldInfoUkItems.IndexOf(itemSourceNameItems[0]);
                       Expression expression = null;
                       for (int i = (indexItemSourceTable + 1); i < fieldInfoUkItems.Count; i++)
                       {
                           if (expression == null)
                           {
                               expression = Expression.Property(itemSourceExpressionBase, fieldInfoUkItems[i]);
                           }
                           else expression = Expression.Property(expression, fieldInfoUkItems[i]);
                       }
                       expression = Expression.Equal(expression, Expression.Constant(result));
                       expressions.Add(expression);
                    }
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
                Expression.Lambda(expressionAnd, itemSourceExpressionBase));
                itemsSourceQueryable = itemsSourceQueryable.Provider.CreateQuery(whereCallExpression);
            }
            return itemsSourceQueryable;
        }



       
    }
}

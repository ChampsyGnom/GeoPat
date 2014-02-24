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

namespace Emash.GeoPatNet.Engine.Implentation.ViewModels
{
    public class GenericItemsSource<M>
    {
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
                Console.WriteLine("Load ItemsSource for path " + items[0] + "." + items[1]);
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
            Console.Write("Try apply filter for " + fieldPath);
            String[] items = fieldPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            EntityTableInfo listTableInfo = this.DataService.GetEntityTableInfo (items[0]);
            EntityTableInfo baseTableInfo = this.DataService.GetEntityTableInfo (typeof (M));
            String basePropertyName =   this.DataService.GetPath (listTableInfo,baseTableInfo)+"."+items[1];
            EntityColumnInfo baseProperty = this.DataService.GetBottomProperty(typeof(M), basePropertyName);
            List<EntityColumnInfo> parentfkProperties = this.DataService.FindFkParentProperties(baseProperty);
            int index = parentfkProperties.IndexOf(baseProperty) + 1;
            for (int i = index; i < parentfkProperties.Count; i++)
            { 
                
            }
            return itemsSourceQueryable;
        }

      
    }
}

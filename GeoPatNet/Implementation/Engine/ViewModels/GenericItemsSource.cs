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
    public class GenericItemsSource
    {
        private Dictionary<String, ObservableCollection<Object>> _comboItemsSource;

        public Dictionary<String, ObservableCollection<Object>> ComboItemsSource
        {
            get { return _comboItemsSource; }
  
        }

        public GenericItemsSource()
        {
            this._comboItemsSource = new Dictionary<string, ObservableCollection<object>>();

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
                itemsSourceQueryable = this.TryApplyListFilters(itemsSourceQueryable);
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

        private IQueryable TryApplyListFilters(IQueryable itemsSourceQueryable)
        {
            return itemsSourceQueryable;
        }
    }
}

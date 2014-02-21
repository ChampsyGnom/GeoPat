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
namespace Emash.GeoPatNet.Engine.Implentation.ViewModels
{
    public class GenericListSources<M>
    {
        public Dictionary<String, ObservableCollection<Object>> _lists;

        public GenericListSources()
        {
            _lists = new Dictionary<string, ObservableCollection<object>>();
        }
        public ObservableCollection<Object> this[String fieldPath]
        {
            get 
            {
                String[] items = fieldPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (!this._lists.ContainsKey(fieldPath))
                {this._lists.Add(fieldPath, new ObservableCollection<object>());}
                if (this._lists[fieldPath] == null || this._lists[fieldPath].Count() == 0)
                { this.LoadList(fieldPath); }
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
            DbSet dbSet = dataService.GetDbSet(tableInfo.EntityType);
            List<Object> objs = new List<object> ();
            foreach (Object obj in dbSet)
            {
                Object value = obj.GetType().GetProperty(items[1]).GetValue(obj);
                objs.Add(value);
            }
            objs = (from o in objs orderby o select o).Distinct().ToList();
            objs.Insert(0, CultureConfiguration.ListNullString);
            foreach (Object o in objs)
            {this._lists[fieldPath].Add(o);}
        }





        internal void UpdateFilter(string fieldPath, Dictionary<string, string> dictionary)
        {
            
        }
    }
}

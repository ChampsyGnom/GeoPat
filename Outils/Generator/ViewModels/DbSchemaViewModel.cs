using Emash.GeoPatNet.Generator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace Emash.GeoPatNet.Generator.ViewModels
{
    [DisplayName("Schéma")]
    public class DbSchemaViewModel
    {
        [Browsable(false)]
        public DbSchema Model { get; set; }

        [ReadOnly(true)]
        [DisplayName("Libellé")]
        public String DisplayName { get; set; }

        [ReadOnly(true)]
        [DisplayName("Nom")]
        public String Name { get; set; }

        [Browsable(false)]
        public ObservableCollection<ViewModelBase> Items { get; set; }

        public DbSchemaViewModel(DbSchema model)
        {
            this.Items = new ObservableCollection<ViewModelBase>();
            DbTablesViewModel vms = new DbTablesViewModel();
            model.Tables = (from t in model.Tables orderby t.DisplayName select t).ToList();
            foreach (DbTable table in model.Tables)
            {
                DbTableViewModel vm = new DbTableViewModel(model,table);
                vms.Items.Add(vm);
            }
            this.Items.Add(vms);
            this.DisplayName = model.DisplayName;
            this.Name = model.Name;
        }
    }
}

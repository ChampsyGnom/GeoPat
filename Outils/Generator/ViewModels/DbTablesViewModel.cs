using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Generator.ViewModels
{
    [DisplayName("Liste des tables")]
    [Browsable(false)]
    public class DbTablesViewModel  : ViewModelBase
    {
        [Browsable(false)]
        public ObservableCollection<DbTableViewModel> Items { get; set; }

        public DbTablesViewModel()
        {
            this.Items = new ObservableCollection<DbTableViewModel>();
        }
    }
}

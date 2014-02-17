using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace Emash.GeoPatNet.Generator.ViewModels
{
    [DisplayName("Liste des colonnes")]    
    [Browsable(false)]
    public class DbColumnsViewModel : ViewModelBase
    {
        [Browsable(false)]
        public ObservableCollection<DbColumnViewModel> Items { get; set; }

       
        public DbColumnsViewModel()
        {
            this.Items = new ObservableCollection<DbColumnViewModel>();
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace Emash.GeoPatNet.Generator.ViewModels
{
    [DisplayName("Liste des contraintes")]
    [Browsable(false)]
    public  class DbConstraintsViewModel : ViewModelBase
    {
        [Browsable(false)]
        public ObservableCollection<DbConstraintViewModel> Items  {get;set;}

        public DbConstraintsViewModel()
        {
            this.Items = new ObservableCollection<DbConstraintViewModel>();
        }
    }
}

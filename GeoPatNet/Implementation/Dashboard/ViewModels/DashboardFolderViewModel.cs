using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Data.Implementation.Models;
namespace Emash.GeoPatNet.Dashboard.Implementation.ViewModels
{
    public class DashboardFolderViewModel : DashboardItemViewModel
    {
        public ObservableCollection<DashboardItemViewModel> Items { get; private set; }
        
        public DashboardFolderViewModel()
        {
            this.Items = new ObservableCollection<DashboardItemViewModel>();
        }
    }
}

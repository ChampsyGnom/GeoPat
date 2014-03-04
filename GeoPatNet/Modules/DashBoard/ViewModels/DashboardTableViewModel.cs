using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.ServiceLocation;

namespace Emash.GeoPatNet.Dashboard.Implementation.ViewModels
{
    public class DashboardTableViewModel : DashboardItemViewModel
    {
        public DashboardTableViewModel()
        {
            this.TreeContextMenuItems = new System.Collections.ObjectModel.ObservableCollection<ContextMenuItem>();
            
            ContextMenuItem contextMenuItemRemoveTable = new ContextMenuItem();
            contextMenuItemRemoveTable.DisplayName = "Supprimer cete table";
            contextMenuItemRemoveTable.Command = new DelegateCommand(new Action (delegate(){
                IDashboardService dashboardService = ServiceLocator.Current.GetInstance<IDashboardService>();
                dashboardService.RemoveTable(this);
            }));
            contextMenuItemRemoveTable.DashboardItem = this;
            this.TreeContextMenuItems.Add(contextMenuItemRemoveTable);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Data.Implementation.Models;
using Microsoft.Practices.Prism.Commands;
using System.Data.Entity;
using System.Data.Entity.Validation;
using Emash.GeoPatNet.Dashboard.Implementation.Views;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
namespace Emash.GeoPatNet.Dashboard.Implementation.ViewModels
{
    public class DashboardFolderViewModel : DashboardItemViewModel
    {
        public ObservableCollection<DashboardItemViewModel> Items { get; private set; }
        public ObservableCollection<ContextMenuItem> TreeContextMenuItems { get; private set; }
        public DashboardFolderViewModel()
        {
            this._dataService = ServiceLocator.Current.GetInstance<IDataService>();
            this.Items = new ObservableCollection<DashboardItemViewModel>();
            this.TreeContextMenuItems = new ObservableCollection<ContextMenuItem>();

            ContextMenuItem contextMenuItemAddFolder = new ContextMenuItem();
            contextMenuItemAddFolder.DisplayName = "Ajouter un dossier";
            contextMenuItemAddFolder.Command = new DelegateCommand<object>(AddFolder);
            contextMenuItemAddFolder.DashboardItem = this;
            this.TreeContextMenuItems.Add(contextMenuItemAddFolder);
        }
        private IDataService _dataService;
        private void AddFolder(Object value)
        {
            DbSet<InfCodeDashboard> datasCodeDashboard = _dataService.GetDbSet<InfCodeDashboard>();
            DbSet<InfDashboard> datasDashboard = _dataService.GetDbSet<InfDashboard>();
            DashboardDialogFolderViewModel vm = new DashboardDialogFolderViewModel();
            DashboardDialogFolderView v = new DashboardDialogFolderView();
            v.DataContext = vm;
            v.Owner = System.Windows.Application.Current.MainWindow;
            Nullable<Boolean> result = v.ShowDialog();
            if (result.HasValue && result.Value == true)
            {
                InfDashboard dashboardFolder = new InfDashboard();
                dashboardFolder.Code = vm.FolderName;
                dashboardFolder.Libelle = vm.FolderName;
                dashboardFolder.IdParent = this.Model.Id;
                dashboardFolder.InfCodeDashboard = (from c in datasCodeDashboard where c.Code.Equals("FOLDER") select c).FirstOrDefault();
                dashboardFolder.Ordre = this.Items.Count + 1;
                datasDashboard.Add(dashboardFolder);
                IEnumerable<DbEntityValidationResult> results = _dataService.DataContext.GetValidationErrors();
                _dataService.DataContext.SaveChanges();

                DashboardFolderViewModel folder = new DashboardFolderViewModel();
                folder.DisplayName = vm.FolderName;
                folder.Model = dashboardFolder;
                this.Items.Add(folder);
            }
        }
    }
}

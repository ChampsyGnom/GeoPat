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
using Emash.GeoPatNet.Atom.Infrastructure.Services;
using Emash.GeoPatNet.Data.Infrastructure.Reflection;
namespace Emash.GeoPatNet.Dashboard.Implementation.ViewModels
{
    public class DashboardFolderViewModel : DashboardItemViewModel
    {
        public ObservableCollection<DashboardItemViewModel> Items { get; private set; }
    
        public DashboardFolderViewModel()
        {
            this._dataService = ServiceLocator.Current.GetInstance<IDataService>();
            this.Items = new ObservableCollection<DashboardItemViewModel>();
            this.TreeContextMenuItems = new ObservableCollection<ContextMenuItem>();
            IDashboardService dashboardService = ServiceLocator.Current.GetInstance<IDashboardService>();
            ContextMenuItem contextMenuItemAddFolder = new ContextMenuItem();
            contextMenuItemAddFolder.DisplayName = "Ajouter un dossier";
            contextMenuItemAddFolder.Command = new DelegateCommand(AddFolder);
            contextMenuItemAddFolder.DashboardItem = this;
            this.TreeContextMenuItems.Add(contextMenuItemAddFolder);

            ContextMenuItem contextMenuItemRemoveFolder = new ContextMenuItem();
            contextMenuItemRemoveFolder.DisplayName = "Supprimer ce dossier";
            contextMenuItemRemoveFolder.Command = new DelegateCommand(RemoveFolder);
            contextMenuItemRemoveFolder.DashboardItem = this;
            this.TreeContextMenuItems.Add(contextMenuItemRemoveFolder);

            ContextMenuItem contextMenuItemAddTable = new ContextMenuItem();
            contextMenuItemAddTable.DisplayName = "Ajouter une table";
            contextMenuItemAddTable.DashboardItem = null;
            this.TreeContextMenuItems.Add(contextMenuItemAddTable);
            foreach (EntitySchemaInfo schema in _dataService.SchemaInfos)
            {
                ContextMenuItem contextMenuItemSchema = new ContextMenuItem();
                contextMenuItemSchema.DisplayName = schema.SchemaName;
                contextMenuItemSchema.DashboardItem = null;
                contextMenuItemAddTable.Items.Add(contextMenuItemSchema);
                List<EntityTableInfo> tbls = (from t in schema.TableInfos orderby t.DisplayName select t).ToList();
                foreach (EntityTableInfo table in tbls)
                {
                    ContextMenuItem contextMenuItemTable = new ContextMenuItem();
                    contextMenuItemTable.DisplayName = table.DisplayName;
                    contextMenuItemTable.DashboardItem = null;
                    contextMenuItemTable.Command = new DelegateCommand(new Action(delegate()
                    {
                        dashboardService.AddTable(this, table);
                    }));
                    contextMenuItemSchema.Items.Add(contextMenuItemTable);
                }

            }
        }
        private IDataService _dataService;
        private void RemoveFolder()
        {
            IDashboardService dashboardService = ServiceLocator.Current.GetInstance<IDashboardService>();
            dashboardService.RemoveFolder(this);
            dashboardService.FillOrder();

        }

        private void AddFolder()
        {
            IDashboardService dashboardService = ServiceLocator.Current.GetInstance<IDashboardService>();
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
                this.IsExpanded = true;
                DashboardFolderViewModel folder = new DashboardFolderViewModel();
                folder.DisplayName = vm.FolderName;
                folder.Model = dashboardFolder;              
                this.Items.Add(folder);
                folder.IsSelected = true;
            }
            dashboardService.FillOrder();
        }
    }
}

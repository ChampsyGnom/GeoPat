using Emash.GeoPatNet.Atom.Infrastructure.Services;
using Emash.GeoPatNet.Dashboard.Implementation.ViewModels;
using Emash.GeoPatNet.Dashboard.Implementation.Views;
using Emash.GeoPatNet.Data.Implementation.Models;
using Emash.GeoPatNet.Data.Infrastructure.Models;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Emash.GeoPatNet.Presentation.Infrastructure.Events;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Emash.GeoPatNet.Dashboard.Implementation.Services
{
    public class DashboardService : IDashboardService
    {
        public ObservableCollection<DashboardItemViewModel> Items { get; private set; }
        public DashboardItemViewModel SelectedItem { get; set; }
        private IDataService _dataService;
        private IEventAggregator _eventAggregator;
        private Dispatcher _dispatcher;
        public DashboardService(IEventAggregator eventAggregator,IDataService dataService)
        {
            this._dataService = dataService;
            this._eventAggregator = eventAggregator;
            this.AddItemCommand= new DelegateCommand(AddItem);
            this.RemoveItemCommand = new DelegateCommand(RemoveItem);
            this.Items = new ObservableCollection<DashboardItemViewModel>();
            _dispatcher = System.Windows.Application.Current.MainWindow.Dispatcher;
        }

        private void AddItem()
        {
            DashboardItemViewModel selectedItem = this.SelectedItem;
            DashboardDialogItemViewModel vm = new DashboardDialogItemViewModel(null);
            DashboardDialogItemView view = new DashboardDialogItemView();
            view.DataContext = vm;
            view.Owner = System.Windows.Application.Current.MainWindow;
            Nullable<Boolean> result =   view.ShowDialog();
            DbSet<InfCodeDashboard> datasCodeDashboard = _dataService.GetDbSet<InfCodeDashboard>();
             DbSet<InfDashboard> datasDashboard = _dataService.GetDbSet<InfDashboard>();
            if (result.HasValue && result.Value == true)
            {
                long idParent = -1;
                if (selectedItem != null)
                { idParent = selectedItem.Model.Id; }
                long order = 0;

                if ((from i in datasDashboard where i.IdParent == idParent select i.Ordre).Count() > 0)
                { order = (from i in datasDashboard where i.IdParent == idParent select i.Ordre).Max()+1; }
                
                if (vm.IsFolder)
                {
                   
                    InfDashboard dashboardFolder = new InfDashboard();
                    dashboardFolder.InfCodeDashboard = (from c in datasCodeDashboard where c.Code .Equals ("FOLDER") select c).FirstOrDefault();
                    dashboardFolder.IdParent = idParent;
                    dashboardFolder.Ordre = order ;
                    dashboardFolder.Libelle = vm.FolderName;
                    datasDashboard.Add(dashboardFolder);
                    _dataService.DataContext.SaveChanges();
                    this.LoadDashboard();
                }
            }
        }

       

        private void RemoveItem()
        {
            if (this.SelectedItem != null)
            {
                this.RecurseRemoveItem(this.SelectedItem.Model);
                this.LoadDashboard();
            }
        }

        private void RecurseRemoveItem(InfDashboard item)
        {
            DbSet<InfDashboard> datasDashboard = _dataService.GetDbSet<InfDashboard>();
            List<InfDashboard> childs = (from c in datasDashboard where c.IdParent == item.Id select c).ToList();
            foreach (InfDashboard child in childs)
            {
                this.RecurseRemoveItem(child);
                datasDashboard.Remove(child);
                _dataService.DataContext.SaveChanges();
            }
        }


        public DelegateCommand AddItemCommand { get; private set; }
        public DelegateCommand RemoveItemCommand { get; private set; }

        public void Initialize()
        {
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Initialisation du tableau de bord ...");
            
            DbSet<InfCodeDashboard> datasCodeDashboard = _dataService.GetDbSet<InfCodeDashboard>();
            IQueryable<InfCodeDashboard> query = (from d in datasCodeDashboard where d.Code == "TABLE" select d);
            Console.WriteLine(query);

            if (query.Count() == 0)
            {
                InfCodeDashboard codeTable = new InfCodeDashboard();
                codeTable.Code = "TABLE";
                codeTable.Libelle = "Table de la base de donnée";
                datasCodeDashboard.Add(codeTable);
                _dataService.DataContext.SaveChanges();
            }
            if ((from d in datasCodeDashboard where d.Code == "FOLDER" select d).Count() == 0)
            {
                InfCodeDashboard codeTable = new InfCodeDashboard();
                codeTable.Code = "FOLDER";
                codeTable.Libelle = "Dossier";
                datasCodeDashboard.Add(codeTable);
                _dataService.DataContext.SaveChanges();
            }
           _dispatcher.Invoke(new Action(delegate()
            {
                this.LoadDashboard();
            }));
           
         
        }

        private void LoadDashboard()
        {
            IQueryable<InfDashboard> datasDashboard = _dataService.GetDbSet<InfDashboard>();
            List<InfDashboard> items = (from i in datasDashboard select i).ToList();
           
            this.Items.Clear();
            this.RecurseLoadDashboard(items, this.Items, -1);
            Console.WriteLine(datasDashboard.ToString());
        }

        private void RecurseLoadDashboard(List<InfDashboard> items, ObservableCollection<DashboardItemViewModel> parentList, long parentId)
        {
            List<InfDashboard> childs = (from i in items where i.IdParent == parentId orderby i.Ordre select i).ToList();
            foreach (InfDashboard child in childs) 
            {
                if (child.InfCodeDashboard.Code.Equals("FOLDER"))
                {
                    DashboardFolderViewModel folder = new DashboardFolderViewModel();
                    folder.Model = child;
                    folder.DisplayName = child.Libelle;
                    parentList.Add(folder);
                    this.RecurseLoadDashboard(items, folder.Items, child.Id);
                }
            }
        }

        
    }
}

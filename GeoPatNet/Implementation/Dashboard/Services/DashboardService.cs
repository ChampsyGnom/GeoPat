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
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using Emash.GeoPatNet.Data.Infrastructure.Events;

namespace Emash.GeoPatNet.Dashboard.Implementation.Services
{
    public class DashboardService : IDashboardService, INotifyPropertyChanged
    {
        public String FolderName { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public DelegateCommand OpenItemCommand { get; private set; }
        public ObservableCollection<DashboardItemViewModel> Items { get; private set; }
       

        public DashboardItemViewModel SelectedItem
        {
            get { 
                return this.RecurseGetSelectedItem(this.Items); 
            }
           
        }

        private DashboardItemViewModel RecurseGetSelectedItem(ObservableCollection<DashboardItemViewModel> list)
        {
            foreach (DashboardItemViewModel vm in list)
            {
                if (vm.IsSelected) return vm;
                else
                {
                    if (vm is DashboardFolderViewModel)
                    {
                        if (this.RecurseGetSelectedItem((vm as DashboardFolderViewModel).Items) != null)
                        { return this.RecurseGetSelectedItem((vm as DashboardFolderViewModel).Items); }
                    }
                }
            }
            return null;
        }

        
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
            this.OpenItemCommand = new DelegateCommand(OpenItem);
        }
        private void OpenItem()
        {
            if (this.SelectedItem != null && this.SelectedItem is DashboardTableViewModel)
            {
                DashboardTableViewModel vm = this.SelectedItem as DashboardTableViewModel;
                String[] items = vm.Model.Code.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (items.Length == 2)
                {
                    EntitySchemaInfo schema = (from s in _dataService.SchemaInfos where s.SchemaName.Equals (items[0]) select s).FirstOrDefault();
                    if (schema != null)
                    {
                        EntityTableInfo table = (from t in schema.TableInfos where t.TableName.Equals (items[1]) select t).FirstOrDefault();
                        this._eventAggregator.GetEvent<OpenEntityEvent>().Publish(table);
                    }
                }
            }
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
                    dashboardFolder.Code = vm.FolderName;
                    datasDashboard.Add(dashboardFolder);
                    DashboardFolderViewModel folder = new DashboardFolderViewModel();
                    folder.Model = dashboardFolder;
                    folder.DisplayName = dashboardFolder.Libelle;
                    if (idParent == -1)
                    {this.Items.Add(folder);}
                    else
                    {
                        (selectedItem as DashboardFolderViewModel).Items.Add(folder);
                        selectedItem.IsExpanded = true;                        
                        folder.IsSelected = true;
                       
                    }
                    _dataService.DataContext.SaveChanges();
                }


                if (vm.IsTable )
                {

                    InfDashboard dashboardTable = new InfDashboard();
                    dashboardTable.InfCodeDashboard = (from c in datasCodeDashboard where c.Code.Equals("TABLE") select c).FirstOrDefault();
                    dashboardTable.IdParent = idParent;
                    dashboardTable.Ordre = order;
                    dashboardTable.Code = vm.SelectedTableInfo.SchemaName + "." + vm.SelectedTableInfo.TableName;
                    dashboardTable.Libelle = vm.SelectedTableInfo.DisplayName;
                    datasDashboard.Add(dashboardTable);
                    DashboardTableViewModel table = new DashboardTableViewModel();
                    table.Model = dashboardTable;

                    table.DisplayName = dashboardTable.Libelle;
                    if (idParent == -1)
                    { this.Items.Add(table); }
                    else
                    {
                        (selectedItem as DashboardFolderViewModel).Items.Add(table);
                        selectedItem.IsExpanded = true;
                        table.IsSelected = true;

                    }
                    _dataService.DataContext.SaveChanges();
                }
            }
        }

       

        private void RemoveItem()
        {
            if (this.SelectedItem != null)
            {
                DashboardFolderViewModel parent = this.GetParentFolder(this.Items , this.SelectedItem);
                ObservableCollection<DashboardItemViewModel> list = null;
                if (parent == null)
                { 
                    this.Items.Remove(this.SelectedItem);
                    list = this.Items;
                }
                else
                { 
                    parent.Items.Remove(this.SelectedItem);
                    list = parent.Items;
                }

                for (int i = 0; i < list.Count; i++)
                {list[i].Model.Ordre = i;}
                _dataService.DataContext.SaveChanges();
            }
        }

        private DashboardFolderViewModel GetParentFolder(ObservableCollection<DashboardItemViewModel> list, DashboardItemViewModel item)
        {
            foreach (DashboardItemViewModel i in list)
            {
                if (i is DashboardFolderViewModel)
                { 
                    DashboardFolderViewModel p = i as DashboardFolderViewModel;
                    if (p.Model.Id == item.Model.IdParent) return p;
                }
            }
            return null;
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


                if (child.InfCodeDashboard.Code.Equals("TABLE"))
                {
                    DashboardTableViewModel table = new DashboardTableViewModel();
                    table.Model = child;
                    table.DisplayName = child.Libelle;
                    parentList.Add(table);
                    
                }
            }
        }

        
    }
}

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
using System.Data.Entity.Validation;

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
        public ObservableCollection<ContextMenuItem> TreeContextMenuItems { get; private set; }

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
         //   this.AddItemCommand= new DelegateCommand(AddItem);
            this.RemoveItemCommand = new DelegateCommand(RemoveItem);
            this.Items = new ObservableCollection<DashboardItemViewModel>();
            _dispatcher = System.Windows.Application.Current.MainWindow.Dispatcher;
            this.OpenItemCommand = new DelegateCommand(OpenItem);
            this.TreeContextMenuItems = new ObservableCollection<ContextMenuItem>();
            ContextMenuItem contextMenuItemAddFolder = new ContextMenuItem();
            contextMenuItemAddFolder.DisplayName = "Ajouter un dossier";
            contextMenuItemAddFolder.Command = new DelegateCommand(AddFolder);
            contextMenuItemAddFolder.DashboardItem = null;
            this.TreeContextMenuItems.Add(contextMenuItemAddFolder);


            
             
          


        }

        public void AddTable(Object parentVm, Object entityTableInfoObj)
        {
            if (entityTableInfoObj != null && entityTableInfoObj is EntityTableInfo)
            {
                EntityTableInfo entityTableInfo = (entityTableInfoObj as EntityTableInfo);

                DbSet<InfCodeDashboard> datasCodeDashboard = _dataService.GetDbSet<InfCodeDashboard>();
                DbSet<InfDashboard> datasDashboard = _dataService.GetDbSet<InfDashboard>();
                InfDashboard dashboardTable = new InfDashboard();
                dashboardTable.Code = entityTableInfo.SchemaName+"."+entityTableInfo.TableName;
                dashboardTable.Libelle = entityTableInfo.DisplayName;
                if (parentVm != null && parentVm is DashboardFolderViewModel)
                {
                    DashboardFolderViewModel folder = parentVm as DashboardFolderViewModel;
                    dashboardTable.IdParent = folder.Model.Id;
                }
                else
                { dashboardTable.IdParent = -1; }
               
                dashboardTable.InfCodeDashboard = (from c in datasCodeDashboard where c.Code.Equals("TABLE") select c).FirstOrDefault();
                dashboardTable.Ordre = this.Items.Count + 1;
                datasDashboard.Add(dashboardTable);
                IEnumerable<DbEntityValidationResult> results = _dataService.DataContext.GetValidationErrors();
                _dataService.DataContext.SaveChanges();

                DashboardTableViewModel tableVm = new DashboardTableViewModel();
                tableVm.DisplayName = entityTableInfo.DisplayName;
                tableVm.Model = dashboardTable;
                if (parentVm != null && parentVm is DashboardFolderViewModel)
                {
                    DashboardFolderViewModel folder = parentVm as DashboardFolderViewModel;
                    folder.Items.Add(tableVm);
                    folder.IsExpanded = true;
                    tableVm.IsSelected = true;
                }
                else
                {
                    this.Items.Add(tableVm);
                    tableVm.IsSelected = true;
                }
               
                this.FillOrder();
            }
           
        }

        public void AddFolder()
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
                dashboardFolder.IdParent = -1;
                dashboardFolder.InfCodeDashboard = (from c in datasCodeDashboard where c.Code.Equals("FOLDER") select c).FirstOrDefault();
                dashboardFolder.Ordre = this.Items.Count +1;
                datasDashboard.Add(dashboardFolder);
                IEnumerable<DbEntityValidationResult> results =  _dataService.DataContext.GetValidationErrors();
                _dataService.DataContext.SaveChanges();

                DashboardFolderViewModel folder = new DashboardFolderViewModel();
                folder.DisplayName = vm.FolderName;
                folder.Model = dashboardFolder;
                this.Items.Add(folder);
                this.FillOrder();
            }
                
            
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
                    List<EntityTableInfo> tbls = (from t in schema.TableInfos orderby t.DisplayName  select t).ToList();
                    foreach (EntityTableInfo table in tbls)
                    {
                        ContextMenuItem contextMenuItemTable = new ContextMenuItem();
                        contextMenuItemTable.DisplayName = table.DisplayName;
                        contextMenuItemTable.DashboardItem = null;
                        contextMenuItemTable.Command = new DelegateCommand(new Action(delegate() {
                            this.AddTable(null, table);
                        }));
                        contextMenuItemSchema.Items.Add(contextMenuItemTable);
                    }

                }
            }));
           
         
        }

        
        private void LoadDashboard()
        {
            IQueryable<InfDashboard> datasDashboard = _dataService.GetDbSet<InfDashboard>();
            List<InfDashboard> items = (from i in datasDashboard select i).ToList();
           
            this.Items.Clear();
            this.RecurseLoadDashboard(items, this.Items, -1);
       
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


        public void RemoveTable(object table)
        {
            if (table != null && table is DashboardTableViewModel)
            {
                DashboardTableViewModel tableVm = (table as DashboardTableViewModel);
                DashboardFolderViewModel folderVmParent = this.FindParentFolder(null, this.Items, tableVm);
                DbSet<InfDashboard> set = _dataService.GetDbSet<InfDashboard>();
                set.Remove(tableVm.Model);
                _dataService.DataContext.SaveChanges();
                if (folderVmParent == null)
                { this.Items.Remove(tableVm); }
                else
                { folderVmParent.Items.Remove(tableVm); }
                this.FillOrder();
            }
        }

        public void RemoveFolder(object folder)
        {
            if (folder != null && folder is DashboardFolderViewModel)
            {
                DashboardFolderViewModel folderVm = folder as DashboardFolderViewModel;
                DashboardFolderViewModel folderVmParent = this.FindParentFolder(null,this.Items ,folderVm);


                List<InfDashboard> itemsToRemove = new List<InfDashboard>();
                this.CollectItemToRemove(folderVm.Model, itemsToRemove);
                itemsToRemove.Add(folderVm.Model);

                DbSet<InfDashboard> set = _dataService.GetDbSet<InfDashboard>();
                foreach (InfDashboard item in itemsToRemove)
                { set.Remove(item); }
                _dataService.DataContext.SaveChanges();
                if (folderVmParent == null)
                { this.Items.Remove(folderVm); }
                else
                { folderVmParent.Items.Remove(folderVm); }
               

            }
        }

        private void CollectItemToRemove(InfDashboard infDashboard, List<InfDashboard> itemsToRemove)
        {
            IQueryable<InfDashboard> query = _dataService.GetDbSet<InfDashboard>().AsQueryable<InfDashboard>();
            List<InfDashboard> childItems = (from i in query where i.IdParent == infDashboard.Id select i).ToList();
            foreach (InfDashboard childItem in childItems)
            {
                itemsToRemove.Add(childItem);
                this.CollectItemToRemove(childItem, itemsToRemove);
            }
        }

        private DashboardFolderViewModel FindParentFolder(DashboardFolderViewModel parent, ObservableCollection<DashboardItemViewModel> observableCollection, DashboardItemViewModel folderVm)
        {
            foreach (DashboardItemViewModel item in observableCollection)
            {
                if (item.Equals(folderVm))
                { return parent; }
                else
                {
                    if (item is DashboardFolderViewModel )
                    {
                        DashboardFolderViewModel subFolder = (item as DashboardFolderViewModel );
                        DashboardFolderViewModel result = this.FindParentFolder(subFolder, subFolder.Items, folderVm);
                        if (result != null) return result;
                    }
                  
                }
            }
            return null;
        
        }




        public void FillOrder()
        {
            this.RecurseFillOrder(this.Items);
            _dataService.DataContext.SaveChanges();
        }

        private void RecurseFillOrder(ObservableCollection<DashboardItemViewModel> observableCollection)
        {
            for (int i = 0; i < observableCollection.Count; i++)
            {
                observableCollection[i].Model.Ordre = i;
                if (observableCollection[i] is DashboardFolderViewModel)
                {
                    DashboardFolderViewModel folder = (observableCollection[i] as DashboardFolderViewModel);
                    this.RecurseFillOrder(folder.Items);
                }
            }
        }


      
    }
}

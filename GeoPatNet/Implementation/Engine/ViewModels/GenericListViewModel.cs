using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.ServiceLocation;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Engine.Infrastructure.ViewModels;
using System.Windows.Data;
using Emash.GeoPatNet.Engine.Infrastructure.Enums;
using System.ComponentModel;
using Emash.GeoPatNet.Engine.Infrastructure.ComponentModel;
using System.Windows;
namespace Emash.GeoPatNet.Engine.Implentation.ViewModels
{
    public class GenericListViewModel<M> : IGenericListViewModel, INotifyPropertyChanged, IRowEditableList
        where M : class, new()
       
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
       
        public String DisplayName { get; private set; }
        public IDataService DataService { get; private set; }
        private EntityTableInfo _entityTableInfo;
        public String DisplayRecordCount { get; private set; }
        public String DisplayRecordIndex { get; private set; }
        public DbSet<M> DbSet { get; private set; }
        public GenericDataListState   State { get; private set; }
        public DelegateCommand LockUnlockCommand { get; private set; }
        public DelegateCommand InsertCommand { get; private set; }
        public DelegateCommand DeleteCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand CommitCommand { get; private set; }
        public DelegateCommand ClearCommand { get; private set; }
        public DelegateCommand SearchCommand { get; private set; }
        public DelegateCommand QuitCommand { get; private set; }
        public ObservableCollection<String> FieldPaths { get; private set; }
        public ObservableCollection<GenericListItemViewModel<M>> Items { get; private set; }
        public ListCollectionView ItemsView { get; private set; }
        public GenericListItemViewModel<M> SearchItem { get; private set; }
        public GenericListItemViewModel<M> InsertingItem { get; private set; }
        public GenericListItemViewModel<M> UpdatingItem { get; private set; }
        public GenericListItemViewModel<M> DeletingItem { get; private set; }
        public Boolean IsLocked { get; private set; }

        public GenericListViewModel()
        {
            this.FieldPaths = new ObservableCollection<string>();
            DataService = ServiceLocator.Current.GetInstance<IDataService>();
            _entityTableInfo = DataService.GetEntityTableInfo(typeof(M));
            DbSet = DataService.DataContext.Set<M>();
            this.DisplayRecordCount = (from c in DbSet select c).Count().ToString();
            this.DisplayRecordIndex = "*";
            this.DisplayName = _entityTableInfo.DisplayName;
            this.LockUnlockCommand = new DelegateCommand(LockUnlockExecute, CanLockUnlockExecute);
            this.InsertCommand = new DelegateCommand(InsertExecute, CanInsertExecute);
            this.DeleteCommand = new DelegateCommand(DeleteExecute, CanDeleteExecute);
            this.CancelCommand = new DelegateCommand(CancelExecute, CanCancelExecute);
            this.CommitCommand = new DelegateCommand(CommitExecute, CanCommitExecute);
            this.ClearCommand = new DelegateCommand(ClearExecute, CanClearExecute);
            this.SearchCommand = new DelegateCommand(SearchExecute, CanSearchExecute);
            this.QuitCommand = new DelegateCommand(QuitExecute, CanQuitExecute);
            List<String> fieldPaths = this.DataService.GetTableFieldPaths(_entityTableInfo);
            this.Items = new ObservableCollection<GenericListItemViewModel<M>>();
            this.ItemsView = new ListCollectionView(this.Items);
            foreach (String fieldPath in fieldPaths)
            {this.FieldPaths.Add(fieldPath);}
            this.SearchItem = new GenericListItemViewModel<M>(this,null);
            this.Items.Add(this.SearchItem);
            this.State = GenericDataListState.Search;
            this.IsLocked = true;
            this.ItemsView.CurrentChanged += ItemsView_CurrentChanged;
        }

        void ItemsView_CurrentChanged(object sender, EventArgs e)
        {
            if (this.State == GenericDataListState.Search)
            { this.DisplayRecordIndex = "*"; }
            else
            { this.DisplayRecordIndex = (this.ItemsView.CurrentPosition+1).ToString(); }
            this.RaisePropertyChanged("DisplayRecordIndex");
        }

        private void UpdateDisplayRecordCount()
        { 
            this.DisplayRecordCount = (from c in DbSet select c).Count().ToString();
            this.RaisePropertyChanged("DisplayRecordCount");
        }

        public void BeginEdit(object obj)
        {
            if (this.ItemsView.CurrentItem != null && this.ItemsView.CurrentItem.Equals(obj))
            { 
                this.UpdatingItem = this.Items[this.ItemsView.IndexOf (obj)];
                this.State = GenericDataListState.Updating;
                this.RaiseCommandChange();
            }
        }


        private void QuitExecute()
        { }

        private Boolean CanQuitExecute()
        { return false; }

        private void SearchExecute()
        {
            this.Items.Clear();
            DbSet<M> dbSet = DataService.GetDbSet<M>();
            if (dbSet.Count() == 0)
            {
                MessageBox.Show("Aucune donnée à afficher, retour au mode recherche", "Plus de donnée à afficher", MessageBoxButton.OK, MessageBoxImage.Information);
                this.ClearExecute();
            }
            else
            {
                foreach (M model in dbSet)
                {
                    GenericListItemViewModel<M> vm = new GenericListItemViewModel<M>(this, model);
                    vm.LoadFromModel(this.FieldPaths.ToList());
                    this.Items.Add(vm);
                    this.State = GenericDataListState.Display;
                    this.ItemsView.MoveCurrentToFirst();
                    this.RaiseStateChange();

                }
            }
          
        }

        private Boolean CanSearchExecute()
        { return this.State == GenericDataListState.Search ; }

        private void ClearExecute()
        {
            this.Items.Clear();
            this.Items.Add(this.SearchItem);
            this.State = GenericDataListState.Search;
            this.RaiseStateChange();
            this.UpdateDisplayRecordCount();
            this.ItemsView.MoveCurrentToFirst();
        }

        private Boolean CanClearExecute()
        { return this.State == GenericDataListState.Display; }


        private void CommitExecute()        
        {
            if (this.State == GenericDataListState.InsertingEmpty)
            {
                this.InsertingItem.SaveToModel(this.FieldPaths.ToList ());
                this.DbSet.Add(this.InsertingItem.Model);
                this.DataService.DataContext.SaveChanges();
                this.State = GenericDataListState.Search;
                this.Items.Clear();
                this.Items.Add(this.SearchItem);
                this.InsertingItem = null;
                this.RaiseStateChange();
            }
            else if (this.State == GenericDataListState.Deleting)
            {

                this.DbSet.Remove(this.DeletingItem.Model);
                this.Items.Remove(this.DeletingItem);
                this.DataService.DataContext.SaveChanges();
                this.State = GenericDataListState.Display;
                this.DeletingItem = null;
                if (this.Items.Count == 0)
                {
                    MessageBox.Show("Aucune donnée à afficher, retour au mode recherche", "Plus de donnée à afficher", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.ClearExecute();
                }
                else { this.RaiseStateChange(); }
       
            }
            else if (this.State == GenericDataListState.Updating)
            {
                this.UpdatingItem.SaveToModel(this.FieldPaths.ToList ());
                this.DataService.DataContext.SaveChanges();
                this.State = GenericDataListState.Display;
                this.UpdatingItem = null;
                this.RaiseStateChange();
            }
            else if (this.State == GenericDataListState.InsertingDisplay)
            {
                this.InsertingItem.SaveToModel(this.FieldPaths.ToList());
                this.DbSet.Add(this.InsertingItem.Model);
                this.DataService.DataContext.SaveChanges();
                this.State = GenericDataListState.Display;
                this.InsertingItem = null;
                this.RaiseStateChange();
            }
        }

        private Boolean CanCommitExecute()
        { return this.State == GenericDataListState.InsertingEmpty || this.State == GenericDataListState.Deleting || this.State == GenericDataListState.Updating || this.State == GenericDataListState.InsertingDisplay; }

        private void CancelExecute()
        {
            if (this.State == GenericDataListState.InsertingEmpty)
            {
                this.Items.Clear();
                this.Items.Add(this.SearchItem);
                this.State = GenericDataListState.Search;
                this.InsertingItem = null;
                this.RaiseStateChange();
            }
            else if (this.State == GenericDataListState.Deleting)
            {
                this.State = GenericDataListState.Display;
                this.DeletingItem = null;
                this.RaiseStateChange();
            }
            else if (this.State == GenericDataListState.Updating)
            {                
                this.UpdatingItem.LoadFromModel(this.FieldPaths.ToList ());
                this.State = GenericDataListState.Display;
                this.UpdatingItem.RaiseValuesChanges();
                this.UpdatingItem = null;
                this.RaiseStateChange();
            }
            else if (this.State == GenericDataListState.InsertingDisplay)
            {
                this.Items.Remove(this.InsertingItem);
                this.InsertingItem = null;               
                this.State = GenericDataListState.Display;
                this.RaiseStateChange();
            }
        }

        private Boolean CanCancelExecute()
        { return this.State == GenericDataListState.InsertingEmpty || this.State == GenericDataListState.Deleting || this.State == GenericDataListState.Updating || this.State == GenericDataListState.InsertingDisplay;  }


        private void DeleteExecute()
        {
            if (this.ItemsView.CurrentItem != null)
            {
                GenericListItemViewModel<M> vm = (GenericListItemViewModel<M>)this.ItemsView.CurrentItem;
                this.DeletingItem = vm;
                this.State = GenericDataListState.Deleting;
                this.RaiseStateChange();
            }
        }

        private Boolean CanDeleteExecute()
        { return this.State == GenericDataListState.Display && !this.IsLocked ; }


        private void LockUnlockExecute()
        {
            this.IsLocked =!this.IsLocked;
            this.RaiseStateChange();
        }

        private Boolean CanLockUnlockExecute()
        { return this.State == GenericDataListState.Search || this.State == GenericDataListState.Display; }

        public void RaiseStateChange()
        {
            
            this.RaiseCommandChange();
            this.RaisePropertyChanged("State");
            this.RaisePropertyChanged("IsLocked");
            this.UpdateDisplayRecordCount();
     
        }

        private void RaiseCommandChange()
        {
            this.CancelCommand.RaiseCanExecuteChanged();
            this.CommitCommand.RaiseCanExecuteChanged();
            this.ClearCommand.RaiseCanExecuteChanged();
            this.DeleteCommand.RaiseCanExecuteChanged();
            this.InsertCommand.RaiseCanExecuteChanged();
            this.LockUnlockCommand.RaiseCanExecuteChanged();
            this.QuitCommand.RaiseCanExecuteChanged();
            this.SearchCommand.RaiseCanExecuteChanged();            
        }

        private void InsertExecute()
        {
            if (this.State == GenericDataListState.Search)
            {
                this.Items.Clear();
                M model = new M();
                GenericListItemViewModel<M> vm = new GenericListItemViewModel<M>(this,model);               
                this.Items.Add(vm);
                this.State = GenericDataListState.InsertingEmpty;
                this.InsertingItem = vm;
                this.InsertingItem.RaiseValuesChanges();
                this.RaiseStateChange();
            } else if (this.State == GenericDataListState.Display)
            {
               
                M model = new M();
                GenericListItemViewModel<M> vm = new GenericListItemViewModel<M>(this, model);
                this.Items.Insert(0,vm);
                this.State = GenericDataListState.InsertingDisplay;
                this.InsertingItem = vm;
                this.ItemsView.MoveCurrentToFirst();
                this.InsertingItem.RaiseValuesChanges();
                this.RaiseStateChange();
            }
         
        }

        private Boolean CanInsertExecute()
        { return !this.IsLocked && (this.State == GenericDataListState.Search || this.State == GenericDataListState.Display); }



        public bool CanEdit(IRowEditableItem rowEditableItem)
        {
            if (this.State == GenericDataListState.Search) return true;
            if (this.State == GenericDataListState.Deleting) return false;
            if (this.State == GenericDataListState.Display && !this.IsLocked)
            {return true;   }
      
            if (this.State == GenericDataListState.InsertingEmpty) return !this.IsLocked;
            if (this.State == GenericDataListState.InsertingDisplay && !this.IsLocked)
            {
                if (this.InsertingItem.Equals(rowEditableItem))
                { return true; }
            }
            if (this.State == GenericDataListState.Updating && !this.IsLocked)
            {
                if (this.UpdatingItem != null && this.UpdatingItem.Equals(rowEditableItem))
                {
                   
                    return true;
                }
            }
            return false;
        }








       
    }
}

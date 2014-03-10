using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.Commands;
namespace Emash.GeoPatNet.Engine.ViewModels
{
    public class CustomSortViewModel<M> : INotifyPropertyChanged
        where M : new()
    {
        private CustomSortablePropertyViewModel _selectedSortableProperty;


        public CustomSortablePropertyViewModel SelectedSortableProperty
        {
            get { return _selectedSortableProperty; }
            set { _selectedSortableProperty = value; this.RaisePropertyChanged("SelectedSortableProperty"); }
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        public DelegateCommand<CustomSortablePropertyViewModel> AddColumnCommand { get; private set; }
        public DelegateCommand<CustomSortablePropertyViewModel> RemoveColumnCommand { get; private set; }
        public DelegateCommand<CustomSortablePropertyViewModel> SetSortModeAscendingCommand { get; private set; }
        public DelegateCommand<CustomSortablePropertyViewModel> SetSortModeDescendingCommand { get; private set; }
        public ObservableCollection<CustomSortablePropertyViewModel> SortedProperties { get; private set; }
        public ObservableCollection<CustomSortablePropertyViewModel> UnsortedProperties { get; private set; }
        public DelegateCommand<CustomSortablePropertyViewModel> MoveColumnToTopCommand { get; private set; }
        public DelegateCommand<CustomSortablePropertyViewModel> MoveColumnToUpCommand { get; private set; }
        public DelegateCommand<CustomSortablePropertyViewModel> MoveColumnToDownCommand { get; private set; }
        public DelegateCommand<CustomSortablePropertyViewModel> MoveColumnToBottomCommand { get; private set; }
        public CustomSortViewModel(Dictionary<String, Nullable<ListSortDirection>> sorters) 
        {
            this.SortedProperties = new ObservableCollection<CustomSortablePropertyViewModel>();
            this.UnsortedProperties = new ObservableCollection<CustomSortablePropertyViewModel>();
            /*
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            EntityTableInfo tableInfo = dataService.GetEntityTableInfo(typeof(M));
             List<String> basicFieldPaths =   dataService.GetTableFieldPaths(tableInfo);

            foreach (String fieldPath in sorters.Keys)
            {
                CustomSortablePropertyViewModel vm = new CustomSortablePropertyViewModel();
                EntityColumnInfo columnInfo = dataService.GetTopColumnInfo(typeof(M), fieldPath);
                vm.FieldPath = fieldPath;

                if (basicFieldPaths.Contains(fieldPath))
                {
                    if (fieldPath.IndexOf(".") == -1)
                    { vm.DisplayName = columnInfo.DisplayName; }
                    else
                    { vm.DisplayName = columnInfo.TableInfo.DisplayName; }
                }
                else
                {
                    vm.DisplayName = columnInfo.TableInfo.DisplayName + " - " + columnInfo.DisplayName;
                }
                vm.SortDirection = sorters[fieldPath];
                if (vm.SortDirection.HasValue)
                { this.SortedProperties.Add(vm); }
                else
                { this.UnsortedProperties.Add(vm); }
            }

            this.AddColumnCommand = new DelegateCommand<CustomSortablePropertyViewModel>(AddColumnExecute);
            this.RemoveColumnCommand = new DelegateCommand<CustomSortablePropertyViewModel>(RemoveColumnExecute);
            this.SetSortModeAscendingCommand = new DelegateCommand<CustomSortablePropertyViewModel>(SetSortModeAscendingExecute);
            this.SetSortModeDescendingCommand = new DelegateCommand<CustomSortablePropertyViewModel>(SetSortModeDescendingExecute);
            this.MoveColumnToBottomCommand = new DelegateCommand<CustomSortablePropertyViewModel>(MoveColumnToBottomExecute);
            this.MoveColumnToDownCommand = new DelegateCommand<CustomSortablePropertyViewModel>(MoveColumnToDownExecute);
            this.MoveColumnToTopCommand = new DelegateCommand<CustomSortablePropertyViewModel>(MoveColumnToTopExecute);
            this.MoveColumnToUpCommand = new DelegateCommand<CustomSortablePropertyViewModel>(MoveColumnToUpExecute);      
             * */
        }

        private void MoveColumnToTopExecute(CustomSortablePropertyViewModel prop)
        {
            int index = this.SortedProperties.IndexOf(prop);
            this.SortedProperties.Remove(prop);
            this.SortedProperties.Insert(0, prop);
            this.SelectedSortableProperty = prop;
        }

        private void MoveColumnToUpExecute(CustomSortablePropertyViewModel prop)
        {
            int index = this.SortedProperties.IndexOf(prop);
            index--;
            if (index >= 0)
            {
                this.SortedProperties.Remove(prop);
                this.SortedProperties.Insert(index, prop);
                this.SelectedSortableProperty = prop;
            }
        }

        private void MoveColumnToDownExecute(CustomSortablePropertyViewModel prop)
        {
            int index = this.SortedProperties.IndexOf(prop);
            index++;
            if (index <= (SortedProperties.Count -1))
            {
                this.SortedProperties.Remove(prop);
                this.SortedProperties.Insert(index, prop);
                this.SelectedSortableProperty = prop;
            }
        }

        private void MoveColumnToBottomExecute(CustomSortablePropertyViewModel prop)
        {
            int index = this.SortedProperties.IndexOf(prop);
            this.SortedProperties.Remove(prop);
            this.SortedProperties.Add(prop);
            this.SelectedSortableProperty = prop;
        }

        private void SetSortModeAscendingExecute(CustomSortablePropertyViewModel prop)
        {
            prop.SortDirection = ListSortDirection.Ascending;           
        }

        private void SetSortModeDescendingExecute(CustomSortablePropertyViewModel prop)
        { prop.SortDirection = ListSortDirection.Descending; }
        private void AddColumnExecute(CustomSortablePropertyViewModel prop)
        {
            prop.SortDirection = ListSortDirection.Ascending;
            this.UnsortedProperties.Remove(prop);
            this.SortedProperties.Add(prop);
        }

        private void RemoveColumnExecute(CustomSortablePropertyViewModel prop)
        {
            prop.SortDirection = null;
            this.SortedProperties.Remove(prop);
            this.UnsortedProperties.Add(prop);
        }
    }
}

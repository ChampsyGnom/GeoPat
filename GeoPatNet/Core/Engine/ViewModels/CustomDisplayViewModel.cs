using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Attributes;
using Microsoft.Practices.Prism.Commands;
using System.ComponentModel;
namespace Emash.GeoPatNet.Engine.ViewModels
{
    public class CustomDisplayViewModel<M> : INotifyPropertyChanged
        where M : new()
    {
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
        private CustomDisplayablePropertyViewModel<M> _selectedVisibleProperty;


        public CustomDisplayablePropertyViewModel<M> SelectedVisibleProperty
        {
            get { return _selectedVisibleProperty; }
            set { _selectedVisibleProperty = value; this.RaisePropertyChanged("SelectedVisibleProperty"); }
        }
        public ObservableCollection<CustomDisplayablePropertyViewModel<M>> VisibleFields { get; private set; }
        public ObservableCollection<CustomDisplayableEntityViewModel<M>> Entities { get; private set; }
        public DelegateCommand<CustomDisplayablePropertyViewModel<M>> AddPropertyCommand { get; private set; }
        public DelegateCommand<CustomDisplayablePropertyViewModel<M>> RemovePropertyCommand { get; private set; }
        public DelegateCommand<CustomDisplayableEntityViewModel<M>> AddEntityPropertiesCommand { get; private set; }

        public DelegateCommand<CustomDisplayablePropertyViewModel<M>> MoveColumnToTopCommand { get; private set; }
        public DelegateCommand<CustomDisplayablePropertyViewModel<M>> MoveColumnToUpCommand { get; private set; }
        public DelegateCommand<CustomDisplayablePropertyViewModel<M>> MoveColumnToDownCommand { get; private set; }
        public DelegateCommand<CustomDisplayablePropertyViewModel<M>> MoveColumnToBottomCommand { get; private set; }
        private void AddEntityPropertiesExecute(CustomDisplayableEntityViewModel<M> entity)
        {
            List<CustomDisplayablePropertyViewModel<M>> props = (from p in entity.Fields select p).ToList();
            foreach (CustomDisplayablePropertyViewModel<M> prop in props)
            {
                VisibleFields.Add(prop);
                prop.Entity.Fields.Remove(prop);
            }
        }

        private void AddPropertyExecute(CustomDisplayablePropertyViewModel<M> prop)
        {
            VisibleFields.Add(prop);
            prop.Entity.Fields.Remove(prop);
        }

        private void RemovePropertyExecute(CustomDisplayablePropertyViewModel<M> prop)
        {
             if (prop.CanRemove)
            {
                VisibleFields.Remove(prop);
                prop.Entity.Fields.Add(prop);
            }
           
            
        }

        private void MoveColumnToTopExecute(CustomDisplayablePropertyViewModel<M> prop)
        {
            int index = this.VisibleFields.IndexOf(prop);
            this.VisibleFields.Remove(prop);
            this.VisibleFields.Insert(0, prop);
            this.SelectedVisibleProperty = prop;
        }

        private void MoveColumnToUpExecute(CustomDisplayablePropertyViewModel<M> prop)
        {
            int index = this.VisibleFields.IndexOf(prop);
            index--;
            if (index >= 0)
            {
                this.VisibleFields.Remove(prop);
                this.VisibleFields.Insert(index, prop);
                this.SelectedVisibleProperty = prop;
            }
        }

        private void MoveColumnToDownExecute(CustomDisplayablePropertyViewModel<M> prop)
        {
            int index = VisibleFields.IndexOf(prop);
            index++;
            if (index <= (VisibleFields.Count - 1))
            {
                VisibleFields.Remove(prop);
                this.VisibleFields.Insert(index, prop);
                this.SelectedVisibleProperty = prop;
            }
        }

        private void MoveColumnToBottomExecute(CustomDisplayablePropertyViewModel<M> prop)
        {
            int index = this.VisibleFields.IndexOf(prop);
            this.VisibleFields.Remove(prop);
            this.VisibleFields.Add(prop);
            this.SelectedVisibleProperty = prop;
        }


        public CustomDisplayViewModel(List<String> fieldPaths)
        {
            this.VisibleFields = new ObservableCollection<CustomDisplayablePropertyViewModel<M>>();
            this.Entities = new ObservableCollection<CustomDisplayableEntityViewModel<M>>();
            this.AddPropertyCommand = new DelegateCommand<CustomDisplayablePropertyViewModel<M>>(AddPropertyExecute);
            this.AddEntityPropertiesCommand = new DelegateCommand<CustomDisplayableEntityViewModel<M>>(AddEntityPropertiesExecute);
            this.RemovePropertyCommand = new DelegateCommand<CustomDisplayablePropertyViewModel<M>>(RemovePropertyExecute);
            this.MoveColumnToBottomCommand = new DelegateCommand<CustomDisplayablePropertyViewModel<M>>(MoveColumnToBottomExecute);
            this.MoveColumnToDownCommand = new DelegateCommand<CustomDisplayablePropertyViewModel<M>>(MoveColumnToDownExecute);
            this.MoveColumnToTopCommand = new DelegateCommand<CustomDisplayablePropertyViewModel<M>>(MoveColumnToTopExecute);
            this.MoveColumnToUpCommand = new DelegateCommand<CustomDisplayablePropertyViewModel<M>>(MoveColumnToUpExecute);            
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            EntityTableInfo tableInfo = dataService.GetEntityTableInfo(typeof(M));
            List<EntityTableInfo> parentTables = new List<EntityTableInfo>();
            List<String> basicFieldPaths = dataService.GetTableFieldPaths(tableInfo);
            List<CustomDisplayablePropertyViewModel<M>> allProperties = new List<CustomDisplayablePropertyViewModel<M>>();
            List<EntityColumnInfo> hiddenColumnInfos = new List<EntityColumnInfo>();
            foreach (String fieldPath in fieldPaths)
            {
                CustomDisplayablePropertyViewModel<M> vm = new CustomDisplayablePropertyViewModel<M>();
                EntityColumnInfo topColumnInfo = dataService.GetTopColumnInfo(typeof(M), fieldPath);
                vm.ColumnInfo = topColumnInfo;
                vm.FieldPath = fieldPath;
                EntityColumnInfo columnInfoBottom = dataService.GetBottomColumnInfo(typeof(M), vm.FieldPath);
                if (basicFieldPaths.Contains(fieldPath))
                {
                    if (columnInfoBottom.PrimaryKeyName == null && columnInfoBottom.UniqueKeyNames.Count == 0)
                    { vm.CanRemove = true; }
                    else
                    {
                        vm.CanRemove = false;
                    }
                }
                else
                { vm.CanRemove = true; }
             

                if (basicFieldPaths.Contains(fieldPath))
                {
                    if (vm.FieldPath.IndexOf(".") == -1)
                    { vm.DisplayName = topColumnInfo.DisplayName; }
                    else
                    { vm.DisplayName = topColumnInfo.TableInfo.DisplayName; }
                }
                else
                {vm.DisplayName = topColumnInfo.TableInfo.DisplayName+ " - "+topColumnInfo.DisplayName;}
                this.VisibleFields.Add(vm);
                allProperties.Add(vm);
                
            }
            parentTables = dataService.GetAllParentEntityTableInfo(typeof(M));
            parentTables.Insert(0, tableInfo);
            foreach (EntityTableInfo parentTableInfo in parentTables)
            {
                CustomDisplayableEntityViewModel<M> vmEntity = new CustomDisplayableEntityViewModel<M>();
                vmEntity.DisplayName = parentTableInfo.DisplayName;

                foreach (EntityColumnInfo columnInfo in parentTableInfo.ColumnInfos)
                {
                    if (columnInfo.ControlType != ControlType.None && columnInfo.PrimaryKeyName == null && columnInfo.UniqueKeyNames.Count ==0)
                    {

                        String path = dataService.GetPath(parentTableInfo, tableInfo);
                        if (!String.IsNullOrEmpty(path))
                        { path = path + "." + columnInfo.PropertyName; }
                        else
                        { path = columnInfo.PropertyName; }
                        if (!fieldPaths.Contains(path))
                        {

                            CustomDisplayablePropertyViewModel<M> vm = new CustomDisplayablePropertyViewModel<M>();
                            vm.CanRemove = true;
                            vm.FieldPath = path;
                            vm.ColumnInfo = columnInfo;
                            if (basicFieldPaths.Contains(path))
                            {
                                if (vm.FieldPath.IndexOf(".") == -1)
                                { vm.DisplayName = columnInfo.DisplayName; }
                                else
                                { vm.DisplayName = columnInfo.TableInfo.DisplayName; }
                            }
                            else
                            { vm.DisplayName = columnInfo.TableInfo.DisplayName + " - " + columnInfo.DisplayName; }
                            vmEntity.Fields.Add(vm);
                            vm.Entity = vmEntity;
                            allProperties.Add(vm);
                        }
                    }
                    
                    
                }
                this.Entities.Add(vmEntity);
            }
            CustomDisplayableEntityViewModel<M> mainCustomDisplayableEntityViewModel = (from vm in Entities where vm.DisplayName.Equals (tableInfo.DisplayName ) select vm ).FirstOrDefault ();
            foreach (CustomDisplayablePropertyViewModel<M> vm in allProperties)
            {               
                if (vm.Entity == null) vm.Entity = mainCustomDisplayableEntityViewModel;
                vm.RaiseChange();
            }
        }
    }
}

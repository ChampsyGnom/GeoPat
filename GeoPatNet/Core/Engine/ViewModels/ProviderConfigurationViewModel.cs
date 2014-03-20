using Emash.GeoPatNet.Infrastructure.Models;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Infrastructure.ViewModels;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Emash.GeoPatNet.Engine.ViewModels
{
    public class ProviderConfigurationViewModel : IProviderConfigurationViewModel
    {
        public DelegateCommand AddProviderItemCommand { get; private set; }
        public DelegateCommand<Object> SetDefaultProviderItemCommand { get; private set; }
        public DelegateCommand<ProviderConfigurationItem> RemoveProviderItemCommand { get; private set; }
        private ObservableCollection<ProviderConfigurationItem> _items;

        public ObservableCollection<ProviderConfigurationItem> Items
        {
            get { return _items; }
            private set { _items = value; }
        }
        private IDataService DataService { get; set; }
        private IDialogService DialogService { get; set; }
        public ProviderConfigurationViewModel(IDataService dataService,IDialogService dialogService)
        {
            this.DataService = dataService;
            this.DialogService = dialogService;
            this._items = new ObservableCollection<ProviderConfigurationItem>();
            foreach (ProviderConfigurationItem item in dataService.ProviderConfiguration.Items)
            { this._items.Add(item); }
            this.AddProviderItemCommand = new DelegateCommand(AddProviderItemExecute);
            this.RemoveProviderItemCommand = new DelegateCommand<ProviderConfigurationItem>(RemoveProviderItemExecute);
            this.SetDefaultProviderItemCommand = new DelegateCommand<object>(SetDefaultProviderItemExecute);
            this.LoadConfiguration();
        }

        private void RemoveProviderItemExecute(ProviderConfigurationItem item)
        {
            this.DataService.ProviderConfiguration.Items.Remove(item);
            this.DataService.ProviderConfiguration.Save();
            this.LoadConfiguration();
        }

        private void SetDefaultProviderItemExecute(Object item)
        {
            if (item != null && item is ProviderConfigurationItem)
            {
                ProviderConfigurationItem providerConfigurationItem = item as ProviderConfigurationItem;
                foreach (ProviderConfigurationItem i in this.DataService.ProviderConfiguration.Items)
                { i.IsDefault = false; }
                providerConfigurationItem.IsDefault = true;
                this.DataService.ProviderConfiguration.Save();
            }
        }
        private void LoadConfiguration()
        {
            this.DataService.ProviderConfiguration.Load();
            this.Items.Clear();
            foreach (ProviderConfigurationItem item in this.DataService.ProviderConfiguration.Items)
            {this.Items.Add(item);}

        }

        private void AddProviderItemExecute()
        {
            Window window = DialogService.CreateDialog("ProviderConfigurationCreateRegion", "Ajout d'une base decimal données");
            Nullable<Boolean> result = window.ShowDialog();
            if (result.HasValue && result.Value == true)
            {
                ProviderConfigurationCreateViewModel vm = window.FindChildDataContext<ProviderConfigurationCreateViewModel>();
                if (vm != null)
                {
                    ProviderConfigurationItem item = new ProviderConfigurationItem();
                    item.DisplayName = vm.DisplayName;
                    item.IsDefault = false;
                    item.ProviderFactoryTypeFullName = vm.SelectedProviderConfigurationType.ProviderType.FullName;
                    item.Parameters.AddRange(vm.ProviderParameters);
                    this.DataService.ProviderConfiguration.Items.Add(item);
                    this.DataService.ProviderConfiguration.Save();
                    this.LoadConfiguration();
                }
            }
        }
    }
}

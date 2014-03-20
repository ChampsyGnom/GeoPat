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
        }

        private void AddProviderItemExecute()
        {
            Window window = DialogService.CreateDialog("ProviderConfigurationCreateRegion", "Ajout d'une base decimal données");
            Nullable<Boolean> result = window.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel ;
using Emash.GeoPatNet.Infrastructure.Models;
using Microsoft.Practices.Prism.Commands;
namespace Emash.GeoPatNet.Infrastructure.ViewModels
{
    public interface IProviderConfigurationViewModel
    {
        ObservableCollection<ProviderConfigurationItem> Items { get; }
        DelegateCommand AddProviderItemCommand { get; }
    }
}

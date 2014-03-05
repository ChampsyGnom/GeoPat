using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Modules.Stat.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace Emash.GeoPatNet.Modules.Stat.Services
{
    public class StatService : IStatService
    {
        public bool IsAvailable
        {
            get { return true; }
        }

        public void ShowStatWizzard(EntityTableInfo entityTableInfo,List<String> fieldPaths)
        {
            StatWizzardViewModel vm = new StatWizzardViewModel(entityTableInfo, fieldPaths);
            IDialogService dialogService = ServiceLocator.Current.GetInstance<IDialogService>();
            Window dialog = dialogService.CreateDialog("StatWizzardRegion", "Assisstant de statistiques");
            dialog.DataContext = vm;
            Nullable<Boolean> result = dialog.ShowDialog();
            if (result.HasValue && result.Value == true)
            { }
        }
    }
}

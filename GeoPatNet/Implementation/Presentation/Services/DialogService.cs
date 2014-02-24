using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Emash.GeoPatNet.Presentation.Implementation.Views;
using Emash.GeoPatNet.Presentation.Infrastructure.Services;

namespace Emash.GeoPatNet.Presentation.Implementation.Services
{
    public class DialogService : IDialogService
    {
        public Window CreateDialog(string regionName,String title)
        {
            RegionDialog dialog = new RegionDialog(regionName);
            dialog.Owner = Application.Current.Windows.Cast<Window>().SingleOrDefault(x => x.IsActive);
            dialog.Title = title;
            return dialog;
        }
    }
}

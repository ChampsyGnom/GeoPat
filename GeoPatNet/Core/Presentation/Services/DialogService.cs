using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Presentation.Views;
using System.Windows.Controls;



namespace Emash.GeoPatNet.Presentation.Services
{
    public class DialogService : IDialogService
    {
        public Window CreateDialog(string regionName,String title)
        {
            RegionDialog dialog = new RegionDialog(regionName);
            dialog.Owner = Application.Current.Windows.Cast<Window>().SingleOrDefault(x => x.IsActive);
            if (dialog.Owner == null)
            { dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen; }
            else
            { dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner; }
            dialog.Title = title;
            return dialog;
        }


       
    }
}

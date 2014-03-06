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
            dialog.Title = title;
            return dialog;
        }


        public bool? ShowDialog(Control view)
        {
            Window window = new Window();
            window.Content = view;
            window.Owner = Application.Current.Windows.Cast<Window>().SingleOrDefault(x => x.IsActive);
            window.DataContext = view.DataContext;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.WindowStyle = WindowStyle.ToolWindow;
            Nullable<Boolean> result = window.ShowDialog();
            return result;
        }
    }
}

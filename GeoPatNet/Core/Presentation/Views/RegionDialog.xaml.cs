using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Emash.GeoPatNet.Presentation.Implementation.Views
{
    /// <summary>
    /// Logique d'interaction pour RegionDialog.xaml
    /// </summary>
    public partial class RegionDialog : Window
    {
        public RegionDialog(String regionName)
        {
            InitializeComponent();
            this.contentControl.SetValue(Microsoft.Practices.Prism.Regions.RegionManager.RegionNameProperty, regionName);
        }
    }
}

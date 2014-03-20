using Emash.GeoPatNet.Modules.Synoptic.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Emash.GeoPatNet.Modules.Synoptic.Views
{
    /// <summary>
    /// Logique d'interaction pour SynopticBrowserView.xaml
    /// </summary>
    public partial class SynopticBrowserView : UserControl
    {
        public SynopticBrowserView(SynopticBrowserViewModel vm)
        {
            this.DataContext = vm;
            InitializeComponent();
        }
    }
}

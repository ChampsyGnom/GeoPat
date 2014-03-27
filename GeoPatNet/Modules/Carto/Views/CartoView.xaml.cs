using Emash.GeoPatNet.Modules.Carto.ViewModels;
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

namespace Emash.GeoPatNet.Modules.Carto.Views
{
    /// <summary>
    /// Logique d'interaction pour CartoView.xaml
    /// </summary>
    public partial class CartoView : UserControl
    {
        public CartoView()
        {
            
            InitializeComponent();
        }

        private void treeViewTemplate_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.treeViewTemplate.Focus();

        }

       
    }
}

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
using Emash.GeoPatNet.Modules.Carto.ViewModels;
using System.Collections.ObjectModel;
using DotSpatial.Controls;
using Emash.GeoPatNet.Modules.Carto.Layers;
using DotSpatial.Data;
using DotSpatial.Projections;
using DotSpatial.Topology;
namespace Emash.GeoPatNet.Modules.Carto.Views
{
    /// <summary>
    /// Logique d'interaction pour CartoControl.xaml
    /// </summary>
    public partial class CartoControl : UserControl
    {
      
        public CartoControl()
        {

            InitializeComponent();
            
           
        }

      
       
    }
}

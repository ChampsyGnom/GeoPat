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
            this.mapHost.SizeChanged += mapHost_SizeChanged;
            this.DataContextChanged += CartoControl_DataContextChanged;
        }

        void mapHost_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.DataContext != null && this.DataContext is CartoViewModel)
            {
                CartoViewModel cartoViewModel = this.DataContext as CartoViewModel;
                cartoViewModel.Map.Size = new System.Drawing.Size((int)mapHost.ActualWidth, (int)mapHost.ActualHeight);
            }
        }

        void CartoControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.SetMap();
            
        }

        private void SetMap()
        {
            if (this.mapHost != null &&  this.DataContext != null && this.DataContext is CartoViewModel && this.mapHost.Child == null)
            {
                
                CartoViewModel cartoViewModel = this.DataContext as CartoViewModel;
                this.mapHost.Child = cartoViewModel.Map;
            }
        }

        private void mapHost_Loaded(object sender, RoutedEventArgs e)
        {
            this.SetMap();
        }

        
      

      

       
       
    }
}

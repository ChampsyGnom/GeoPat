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
        private DotSpatial.Controls.Map _map;
        public IEnumerable<MapLayerViewModel> Layers
        {
            get { return (IEnumerable<MapLayerViewModel>)GetValue(LayersProperty); }
            set { SetValue(LayersProperty, value); }
        }

        public static readonly DependencyProperty LayersProperty =
            DependencyProperty.Register("Layers", typeof(IEnumerable<MapLayerViewModel>), typeof(CartoControl), new PropertyMetadata(new PropertyChangedCallback (OnLayersChange)));
        private static void OnLayersChange(DependencyObject source, DependencyPropertyChangedEventArgs arg)
        {
           
            if (source != null && source is CartoControl)
            {
                CartoControl cartoControl = source as CartoControl;
                cartoControl.OnLayersChange(arg.OldValue as IEnumerable<MapLayerViewModel>, arg.NewValue as IEnumerable<MapLayerViewModel>);

            }
           
        }

        private void OnLayersChange(IEnumerable<MapLayerViewModel> oldLayers, IEnumerable<MapLayerViewModel> newLayers)
        {
          
            if (oldLayers != null && oldLayers is ObservableCollection<MapLayerViewModel>)
            {
                (oldLayers as ObservableCollection<MapLayerViewModel>).CollectionChanged -= CartoControl_CollectionChanged;
            }

            if (newLayers != null && newLayers is ObservableCollection<MapLayerViewModel>)
            {
                (newLayers as ObservableCollection<MapLayerViewModel>).CollectionChanged += CartoControl_CollectionChanged;
            }
            this.UpdateLayers();
          
        }

        void CartoControl_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.UpdateLayers();
        }

        private void UpdateLayers()
        {
            Console.WriteLine("Update Layers");
            if (this.Layers != null && this.mapHost != null && this.mapHost.Child != null && this.mapHost.Child is DotSpatial.Controls.Map)
            {
                DotSpatial.Controls.Map map = this.mapHost.Child as DotSpatial.Controls.Map;
                this._map = map;
              
                this._map.FunctionMode = FunctionMode.ZoomIn;
           
                Console.WriteLine("Width : " + this._map.Width + ", Height : " + this._map.Height);
                foreach (MapLayerViewModel layerVm in this.Layers)
                {
                    //double[] xy = new double[] { 1.84864D, 45.7736D, 7.60549, 48.37909 };
                  //  double[] z = new double[] { 0D, 0D };
                   // this.map.Projection = ProjectionInfo.FromEpsgCode(3785);
                  //  ProjectionInfo dst =   ProjectionInfo.FromEpsgCode(3785);
                  //  ProjectionInfo source = KnownCoordinateSystems.Geographic.World.WGS1984;
                  //  DotSpatial.Projections.Reproject.ReprojectPoints(xy, z, source, dst, 0, 2);
                 //   this.map.ViewExtents = new Extent(xy);
                    this.map.MapFrame.SuspendEvents();
                    if (layerVm.Node.Model.SigLayer.SigCodeLayer.Code == "Google")
                    {
                        BruTileLayer bruTileLayer = BruTileLayer.CreateGoogleMapLayer();
                        layerVm.Node.Layer = bruTileLayer;
                        layerVm.Node.Map = map;
                        this.map.Layers.Add(bruTileLayer);
                        this.map.MapFrame.ResumeEvents();
                        this.map.ZoomToMaxExtent();
                        this.map.RedrawLayersWhileResizing = false;
                        

                    }
                }

            }
        }

       
       



        public CartoControl()
        {
            InitializeComponent();            
        }

        private void btModeZoom_Click(object sender, RoutedEventArgs e)
        {
            if (this.Layers != null && this.mapHost != null && this.mapHost.Child != null && this.mapHost.Child is DotSpatial.Controls.Map)
            {
                DotSpatial.Controls.Map map = this.mapHost.Child as DotSpatial.Controls.Map;
                map.FunctionMode = FunctionMode.ZoomIn;
            }
        }

        private void btModeMove_Click(object sender, RoutedEventArgs e)
        {
            if (this.Layers != null && this.mapHost != null && this.mapHost.Child != null && this.mapHost.Child is DotSpatial.Controls.Map)
            {
                DotSpatial.Controls.Map map = this.mapHost.Child as DotSpatial.Controls.Map;
                map.FunctionMode = FunctionMode.Pan;
            }
        }

        
      

      

       
       
    }
}

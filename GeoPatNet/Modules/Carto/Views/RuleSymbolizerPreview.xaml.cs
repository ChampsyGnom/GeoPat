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
using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Topology;
using Emash.GeoPatNet.Modules.Carto.ViewModels;

namespace Emash.GeoPatNet.Modules.Carto.Views
{
    /// <summary>
    /// Logique d'interaction pour RuleSymbolizerPreview.xaml
    /// </summary>
    public partial class RuleSymbolizerPreview : UserControl
    {

        public IStyleRuleSymbolizer Symbolizer
        {
            get { return (IStyleRuleSymbolizer)GetValue(SymbolizerProperty); }
            set { SetValue(SymbolizerProperty, value); }
        }
       private   FeatureSet featureSetPoint = new FeatureSet(FeatureType.Point);
       private FeatureSet featureSetLine = new FeatureSet(FeatureType.Line);
       private FeatureSet featureSetPolygon = new FeatureSet(FeatureType.Polygon);

       private MapPointLayer layerPoint;
       private MapLineLayer layerLine;
     private   MapPolygonLayer layerPolygon;


        public static readonly DependencyProperty SymbolizerProperty = DependencyProperty.Register("Symbolizer", typeof(IStyleRuleSymbolizer), typeof(RuleSymbolizerPreview), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OnSymbolizerChange)));
        private static void OnSymbolizerChange(DependencyObject source, DependencyPropertyChangedEventArgs arg)
        {
            if (source != null && source is RuleSymbolizerPreview)
            {
                RuleSymbolizerPreview ruleSymbolizerPreview = source as RuleSymbolizerPreview;
                ruleSymbolizerPreview.OnSymbolizerChange(arg.OldValue as IStyleRuleSymbolizer, arg.NewValue as IStyleRuleSymbolizer);

            }
        }

        private void OnSymbolizerChange(IStyleRuleSymbolizer styleRuleSymbolizerOld, IStyleRuleSymbolizer styleRuleSymbolizerNew)
        {
            if (styleRuleSymbolizerOld != null)
            {
                styleRuleSymbolizerOld.PropertyChanged -= styleRuleSymbolizerNew_PropertyChanged;
            }
            if (styleRuleSymbolizerNew != null)
            {
                styleRuleSymbolizerNew.PropertyChanged += styleRuleSymbolizerNew_PropertyChanged;
            }
            this.UpdateSymbolisers();
        }

        void styleRuleSymbolizerNew_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.UpdateSymbolisers();
           
        }

        private void UpdateSymbolisers()
        {
            if (this.Symbolizer != null)
            {
                if (layerPoint != null)
                {
                    layerPoint.Symbolizer = this.Symbolizer.ToPointSymbolizer();
                }
                if (layerLine != null)
                {
                    layerLine.Symbolizer = this.Symbolizer.ToLineSymbolizer();
                }
                if (layerPolygon != null)
                {
                    layerPolygon.Symbolizer = this.Symbolizer.ToPolygonSymbolizer();
                }
            }
        }
        public RuleSymbolizerPreview()
        {
            InitializeComponent();
            mapPreview.Projection = DotSpatial.Projections.KnownCoordinateSystems.Geographic.World.WGS1984;
            featureSetPoint.Projection = DotSpatial.Projections.KnownCoordinateSystems.Geographic.World.WGS1984;
            featureSetLine.Projection = DotSpatial.Projections.KnownCoordinateSystems.Geographic.World.WGS1984;
            featureSetPolygon.Projection = DotSpatial.Projections.KnownCoordinateSystems.Geographic.World.WGS1984;
            DotSpatial.Topology.LineString ls = new DotSpatial.Topology.LineString(new Coordinate[] { new Coordinate(-45D, 0D), new Coordinate(45D, 0D) });
            featureSetLine.AddFeature(ls);
            DotSpatial.Topology.Polygon polygon = new DotSpatial.Topology.Polygon(new LinearRing(new Coordinate[] {
                new Coordinate(90, -25), new Coordinate(135, -25), new Coordinate(135,25),new Coordinate(90, 25),new Coordinate(90, -25)
            }));
            featureSetPolygon.AddFeature(polygon);

            DotSpatial.Topology.Point point = new DotSpatial.Topology.Point(new Coordinate(-90D, 0D));
            featureSetPoint.AddFeature(point);
            

           
            layerPoint = new MapPointLayer(featureSetPoint);
            layerLine = new MapLineLayer(featureSetLine);
            layerPolygon = new MapPolygonLayer(featureSetPolygon);
           // layerPoint.Symbolizer = new DotSpatial.Symbology.PointSymbolizer(System.Drawing.Color.DarkBlue, DotSpatial.Symbology.PointShape.Triangle, 20);

       
            mapPreview.Layers.Add(layerLine);
            mapPreview.Layers.Add(layerPolygon);
            mapPreview.Layers.Add(layerPoint);
            this.SizeChanged += RuleSymbolizerPreview_SizeChanged;
            mapPreview.ViewExtents = new Extent(-180, -180, 180, 180);
            mapPreview.ViewExtents.SetCenter(new Coordinate(0, 0));
        }

        void RuleSymbolizerPreview_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            mapPreview.ViewExtents.SetCenter(new Coordinate(0, 0));
           // mapPreview.ZoomToMaxExtent();
            mapPreview.ViewExtents = new Extent(-180, -180, 180, 180);
        }

     
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Controls;
using DotSpatial.Projections;
using Emash.GeoPatNet.Data.Models;
using Emash.GeoPatNet.Modules.Carto.Layers;

namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public class CartoNodeLayerWebViewModel : CartoNodeLayerViewModel
    {

        public override  LayerGroup LayerGroup { get; protected  set; }

        public CartoNodeLayerWebViewModel(SigNode node,Map map)
            : base(node)
        {
            this.LayerGroup = new LayerGroup();
            if (this.Model.SigLayer.SigCodeLayer.Code.Equals("GoogleMap"))
            {
                this.Map = map;
                this.Map.Projection = KnownCoordinateSystems.Projected.World.WebMercator;
                IMapLayer layer = BruTileLayer.CreateGoogleMapLayer();
                this.LayerGroup.Add(layer);
                this.Map.Layers.Add(layer);
            }
            else if (this.Model.SigLayer.SigCodeLayer.Code.Equals("GoogleSatellite"))
            {
                this.Map = map;
                this.Map.Projection = KnownCoordinateSystems.Projected.World.WebMercator;
                IMapLayer layer = BruTileLayer.CreateGoogleSatelliteLayer();
                this.LayerGroup.Add(layer);
                this.Map.Layers.Add(layer);
            }
            else if (this.Model.SigLayer.SigCodeLayer.Code.Equals("GoogleTerrain"))
            {
                this.Map = map;
                this.Map.Projection = KnownCoordinateSystems.Projected.World.WebMercator;
                IMapLayer layer = BruTileLayer.CreateGoogleTerrainLayer();
                this.LayerGroup.Add(layer);
                this.Map.Layers.Add(layer);
            }
            else if (this.Model.SigLayer.SigCodeLayer.Code.Equals("BingRoads"))
            {
                this.Map = map;
                IMapLayer layer = BruTileLayer.CreateBingRoadsLayer();
                this.LayerGroup.Add(layer);
                this.Map.Layers.Add(layer);
            }
            else if (this.Model.SigLayer.SigCodeLayer.Code.Equals("BingHybrid"))
            {
                this.Map = map;
                IMapLayer layer = BruTileLayer.CreateBingHybridLayer();
                this.LayerGroup.Add(layer);
                this.Map.Layers.Add(layer);
            }
            else if (this.Model.SigLayer.SigCodeLayer.Code.Equals("BingAerial"))
            {
                this.Map = map;
                IMapLayer layer = BruTileLayer.CreateBingAerialLayer();
                this.LayerGroup.Add(layer);
                this.Map.Layers.Add(layer);
            }
            else if (this.Model.SigLayer.SigCodeLayer.Code.Equals("Osm"))
            {
                this.Map = map;
                IMapLayer layer = BruTileLayer.CreateOsmLayer();
                this.LayerGroup.Add(layer);
                this.Map.Layers.Add(layer);
            }
        }

       
    }
}

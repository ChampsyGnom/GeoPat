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
        public CartoNodeLayerWebViewModel(SigNode node)
            : base(node)
        { }
        public override void CreateLayer(DotSpatial.Controls.Map map)
        {

            if (this.Model.SigLayer.SigCodeLayer.Code.Equals("GoogleMap"))
            {
                this.Map = map;
                this.Map.Projection = KnownCoordinateSystems.Projected.World.WebMercator;
                IMapLayer layer = BruTileLayer.CreateGoogleMapLayer();
                this.Layers.Add(layer);
                this.Map.Layers.Add(layer);
            }
            else if (this.Model.SigLayer.SigCodeLayer.Code.Equals("GoogleSatellite"))
            {
                this.Map = map;
                this.Map.Projection = KnownCoordinateSystems.Projected.World.WebMercator;
                IMapLayer layer = BruTileLayer.CreateGoogleSatelliteLayer();
                this.Layers.Add(layer);
                this.Map.Layers.Add(layer);
            }
            else if (this.Model.SigLayer.SigCodeLayer.Code.Equals("GoogleTerrain"))
            {
                this.Map = map;
                this.Map.Projection = KnownCoordinateSystems.Projected.World.WebMercator;
                IMapLayer layer = BruTileLayer.CreateGoogleTerrainLayer();
                this.Layers.Add(layer);
                this.Map.Layers.Add(layer);
            }
            else if (this.Model.SigLayer.SigCodeLayer.Code.Equals("BingRoads"))
            {
                this.Map = map;
                IMapLayer layer = BruTileLayer.CreateBingRoadsLayer();
                this.Layers.Add(layer);
                this.Map.Layers.Add(layer);
            }
            else if (this.Model.SigLayer.SigCodeLayer.Code.Equals("BingHybrid"))
            {
                this.Map = map;
                IMapLayer layer = BruTileLayer.CreateBingHybridLayer();
                this.Layers.Add(layer);
                this.Map.Layers.Add(layer);
            }
            else if (this.Model.SigLayer.SigCodeLayer.Code.Equals("BingAerial"))
            {
                this.Map = map;
                IMapLayer layer = BruTileLayer.CreateBingAerialLayer();
                this.Layers.Add(layer);
                this.Map.Layers.Add(layer);
            }
            else if (this.Model.SigLayer.SigCodeLayer.Code.Equals("Osm"))
            {
                this.Map = map;
                IMapLayer layer = BruTileLayer.CreateOsmLayer();
                this.Layers.Add(layer);
                this.Map.Layers.Add(layer);
            }
          

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Data.Models;
using DotSpatial.Controls;
using Emash.GeoPatNet.Modules.Carto.Layers;
using DotSpatial.Projections;

namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public class CartoNodeLayerViewModel : CartoNodeViewModel
    {
        public DotSpatial.Controls.Map Map { get; set; }
        public IMapLayer Layer { get;private  set; }


        public void CreateLayer(DotSpatial.Controls.Map map)
        {
           
            if (this.Model.SigLayer.SigCodeLayer.Code.Equals("GoogleMap"))
            {
                this.Map = map;
                this.Map.Projection = KnownCoordinateSystems.Projected.World.WebMercator;
                this.Layer = BruTileLayer.CreateGoogleMapLayer();
                this.Map.Layers.Add(this.Layer);
            }
            else if (this.Model.SigLayer.SigCodeLayer.Code.Equals("GoogleSatellite"))
            {
                this.Map = map;
                this.Map.Projection = KnownCoordinateSystems.Projected.World.WebMercator;
                this.Layer = BruTileLayer.CreateGoogleSatelliteLayer();
                this.Map.Layers.Add(this.Layer);
            }
            else if (this.Model.SigLayer.SigCodeLayer.Code.Equals("GoogleTerrain"))
            {
                this.Map = map;
                this.Map.Projection = KnownCoordinateSystems.Projected.World.WebMercator;
                this.Layer = BruTileLayer.CreateGoogleTerrainLayer();
                this.Map.Layers.Add(this.Layer);
            }
            else if (this.Model.SigLayer.SigCodeLayer.Code.Equals("BingRoads"))
            {
                this.Map = map;               
                this.Layer = BruTileLayer.CreateBingRoadsLayer();
                this.Map.Layers.Add(this.Layer);
            }
            else if (this.Model.SigLayer.SigCodeLayer.Code.Equals("BingHybrid"))
            {
                this.Map = map;
                this.Layer = BruTileLayer.CreateBingHybridLayer();
                this.Map.Layers.Add(this.Layer);
            }
            else if (this.Model.SigLayer.SigCodeLayer.Code.Equals("BingAerial"))
            {
                this.Map = map;
                this.Layer = BruTileLayer.CreateBingAerialLayer();
                this.Map.Layers.Add(this.Layer);
            }
            else if (this.Model.SigLayer.SigCodeLayer.Code.Equals("Osm"))
            {
                this.Map = map;
                this.Layer = BruTileLayer.CreateOsmLayer();
                this.Map.Layers.Add(this.Layer);
            }
          
              
        }

        private Boolean _isChecked = true;

        public Boolean IsChecked
        {
            get { return _isChecked; }
            set 
            { 
                _isChecked = value;
                if (this.Map != null && this.Layer != null)
                {
                    this.Map.MapFrame.SuspendEvents();
                    if (_isChecked && !this.Map.Layers.Contains (this.Layer ))
                    {this.Map.Layers.Add(this.Layer);  }
                    else if (!_isChecked && this.Map.Layers.Contains (this.Layer ))
                    { this.Map.Layers.Remove(this.Layer); }
                    this.Map.MapFrame.ResumeEvents();
                }
                this.Layer.IsVisible = _isChecked;
                this.RaisePropertyChanged("IsChecked");
                
                
            }
        }
        public CartoNodeLayerViewModel(SigNode model)
            : base(model)
        {
           
        }
    }
}

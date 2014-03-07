using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Data.Models;
using DotSpatial.Controls;
using Emash.GeoPatNet.Modules.Carto.Layers;

namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public class CartoNodeLayerViewModel : CartoNodeViewModel
    {
        public DotSpatial.Controls.Map Map { get; set; }
        public IMapLayer Layer { get;private  set; }


        public void CreateLayer(DotSpatial.Controls.Map map)
        {
            this.Map = map;
            this.Layer = BruTileLayer.CreateGoogleMapLayer();
            this.Map.Layers.Add(this.Layer);
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

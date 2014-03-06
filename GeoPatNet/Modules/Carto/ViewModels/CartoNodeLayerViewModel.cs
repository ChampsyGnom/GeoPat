using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Data.Models;
using DotSpatial.Controls;

namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public class CartoNodeLayerViewModel : CartoNodeViewModel
    {
        public DotSpatial.Controls.Map Map { get; set; }
        public IMapLayer Layer { get; set; }
        private Boolean _isChecked = true;

        public Boolean IsChecked
        {
            get { return _isChecked; }
            set 
            { 
                _isChecked = value;
                this.Map.MapFrame.SuspendEvents();
                this.Layer.IsVisible = _isChecked;
                /*
                if (_isChecked)
                {
             
                    this.Map.Layers.Add(this.Layer);
                }
                else
                { this.Map.Layers.Remove(this.Layer); }
                 * */
                this.RaisePropertyChanged("IsChecked");
                this.Map.Refresh();
                this.Map.MapFrame.InvalidateLayers();
                this.Map.MapFrame.ResumeEvents();
            }
        }
        public CartoNodeLayerViewModel(SigNode model)
            : base(model)
        {
           
        }
    }
}

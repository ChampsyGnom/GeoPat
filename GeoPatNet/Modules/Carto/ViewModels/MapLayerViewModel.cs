using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Data.Models;
using DotSpatial.Controls;

namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public class MapLayerViewModel
    {
        public Boolean IsVisible { get; set; }
        
        public CartoNodeLayerViewModel Node { get; set; }
       
        public MapLayerViewModel(CartoNodeLayerViewModel node)
        {
            // TODO: Complete member initialization
            this.Node = node;
        }
      
        
    }
}

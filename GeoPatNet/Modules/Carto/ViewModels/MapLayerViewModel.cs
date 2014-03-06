using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Data.Models;

namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public class MapLayerViewModel
    {
       

        public MapLayerViewModel(SigLayer model)
        {
            // TODO: Complete member initialization
            this.Model = model;
        }
        public SigLayer Model { get; set; }
        
    }
}

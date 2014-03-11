using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Controls;
using DotSpatial.Symbology;

namespace Emash.GeoPatNet.Modules.Carto.Layers
{
    public  class LayerGroup : List<IMapLayer>
    {
        public virtual  void Load()
        { }
    }
}

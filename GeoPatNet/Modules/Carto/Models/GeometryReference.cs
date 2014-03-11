using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Topology;

namespace Emash.GeoPatNet.Modules.Carto.Models
{
    public class GeometryReference<T>
    {
        public Geometry Geometry { get; set; }
        public T Data { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Symbology;

namespace Emash.GeoPatNet.Modules.Carto.Layers
{
    public class MetierCategory : LineCategory
    {
        
        protected override bool OnMatch(IMatchable other, List<string> mismatchedProperties)
        {
            return base.OnMatch(other, mismatchedProperties);
        }
    }
}

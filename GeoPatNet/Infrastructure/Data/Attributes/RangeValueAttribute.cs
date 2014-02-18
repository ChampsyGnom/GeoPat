using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Data.Infrastructure.Attributes
{
    public class RangeValueAttribute : Attribute
    {
        public Double MinValue { get;private set; }
        public Double MaxValue { get;private set; }

        public RangeValueAttribute(Double minValue, Double maxValue)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

    }
}

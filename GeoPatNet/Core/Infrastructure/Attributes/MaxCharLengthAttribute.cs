using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Attributes
{
    public class MaxCharLengthAttribute : Attribute
    {
        public int MaxCharLength { get; private set; }

        public MaxCharLengthAttribute(int maxCharLength)
        {
            this.MaxCharLength = maxCharLength;
        }
    }
}

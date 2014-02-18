using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Data.Infrastructure.Attributes
{
    public class AllowNullAttribute : Attribute
    {
        public Boolean AllowNull { get; private set; }

        public AllowNullAttribute(Boolean allowNull)
        {
            this.AllowNull = allowNull;
        }
    }
}

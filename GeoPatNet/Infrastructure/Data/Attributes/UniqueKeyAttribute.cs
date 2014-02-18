using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Data.Infrastructure.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class UniqueKeyAttribute : Attribute 
    {
        public String UniqueKeyName { get; private set; }

        public UniqueKeyAttribute(string uniqueKeyName)
        {
            this.UniqueKeyName = uniqueKeyName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PrimaryKeyAttribute : Attribute 
    {
        public String PrimaryKeyName { get; private set; }

        public PrimaryKeyAttribute(string primaryKeyName)
        {
            this.PrimaryKeyName = primaryKeyName;
        }
    }
}

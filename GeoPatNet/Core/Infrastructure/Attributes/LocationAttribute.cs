using Emash.GeoPatNet.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class LocationAttribute : Attribute 
    {
        public LocationAttributeType LocationAttributeType { get; private set; }

        public LocationAttribute(LocationAttributeType locationAttributeType)
        { this.LocationAttributeType = locationAttributeType; }
    }

    
}

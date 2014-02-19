using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Presentation.Infrastructure.Attributes
{

    public enum ControlType
    { 
        Integer,
        Decimal,
        Text,
        Check,
        Combo,
        Date,
        Pr,
        None
    }


    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ControlTypeAttribute : Attribute
    {
        public ControlType ControlType { get; private set; }

        public ControlTypeAttribute(ControlType controlType)
        {
            this.ControlType = controlType;
        }
    }
}

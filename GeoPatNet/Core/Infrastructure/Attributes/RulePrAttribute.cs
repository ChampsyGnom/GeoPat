using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Attributes
{
    public class RulePrAttribute : Attribute 
    {
        public String ChauseeColumnName { get;private  set; }

        public RulePrAttribute(String chauseeColumnName)
        {
            this.ChauseeColumnName = chauseeColumnName;
        }
    }
}

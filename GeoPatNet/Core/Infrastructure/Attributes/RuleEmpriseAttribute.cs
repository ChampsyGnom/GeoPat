using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Attributes
{
    public class RuleEmpriseAttribute : Attribute 
    {
        public String ChauseeColumnName { get;private  set; }

        public RuleEmpriseAttribute(String chauseeColumnName)
        {
            this.ChauseeColumnName = chauseeColumnName;
        }
    }
}

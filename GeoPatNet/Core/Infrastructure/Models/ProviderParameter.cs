using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Models
{
    public class ProviderParameter
    {
       

        public ProviderParameter(string displayName, string code, string value)
        {
            // TODO: Complete member initialization
            this.DisplayName = displayName;
            this.Code = code;
            this.Value = value;
        }
        public String DisplayName { get;private  set; }
        public String Code { get; private set; }
        public String Value { get;  set; }


        public ProviderParameter Clone()
        {
            ProviderParameter parameter = new ProviderParameter(this.DisplayName, this.Code, this.Value);
            return parameter;
        }
    }
}

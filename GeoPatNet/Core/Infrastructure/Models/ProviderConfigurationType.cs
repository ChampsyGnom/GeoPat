using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Models
{
    public class ProviderConfigurationType
    {
        public String DisplayName { get; set; }
        public Type ProviderType { get; set; }
        public List<ProviderParameter> ProviderParameters { get; set; }
        public ProviderConfigurationType(Type providerType, String displayName)
        {
            this.DisplayName = displayName;
            this.ProviderType = providerType;
            this.ProviderParameters = new List<ProviderParameter>();
        }

        public void AddParameter(String displayName, String code,String defaultValue)
        {
            ProviderParameter parameter = new ProviderParameter(displayName, code, defaultValue);
            this.ProviderParameters.Add(parameter);
        }
    }
}

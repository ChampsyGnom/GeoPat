using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Models
{
    public class ProviderConfigurationItem
    {
        public List<ProviderParameter> Parameters { get;private  set; }
        public String DisplayName { get; set; }
        public Boolean IsDefault { get; set; }
        public String ProviderFactoryTypeFullName { get; set; }

        public ProviderConfigurationItem()
        {
            this.Parameters = new List<ProviderParameter>();
        }
    }
}

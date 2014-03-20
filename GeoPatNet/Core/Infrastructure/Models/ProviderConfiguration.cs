using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Models
{
    public class ProviderConfiguration
    {
        public List<ProviderConfigurationItem> Items { get; set; }
        public ProviderConfigurationItem DefaultItem
        {

            get {
                return (from i in Items where i.IsDefault == true select i).FirstOrDefault();
            
            }
        }
        public ProviderConfiguration()
        {
            this.Items = new List<ProviderConfigurationItem>();
        }
    }
}

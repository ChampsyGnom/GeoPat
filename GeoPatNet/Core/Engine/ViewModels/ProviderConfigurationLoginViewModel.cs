using Emash.GeoPatNet.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Engine.ViewModels
{
    public class ProviderConfigurationLoginViewModel : IProviderConfigurationLoginViewModel
    {
        public String Login { get; set; }
        public String Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.ViewModels
{
    public interface IProviderConfigurationLoginViewModel
    {
        String Login { get; set; }
        String Password { get; set; }
    }
}

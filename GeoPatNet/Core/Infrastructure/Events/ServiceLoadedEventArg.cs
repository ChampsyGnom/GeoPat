using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Services;

namespace Emash.GeoPatNet.Infrastructure.Events
{
    public class ServiceLoadedEventArg : EventArgs
    {
        public IAvailableService Service { get; private set; }

        public ServiceLoadedEventArg(IAvailableService service)
        {
            this.Service = service;
        }
    }
}

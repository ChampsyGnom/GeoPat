using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Microsoft.Practices.Prism.Events;

namespace Emash.GeoPatNet.Infrastructure.Events
{
    public class OpenEntityEvent : CompositePresentationEvent<EntityTableInfo>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Services
{
    public interface ISynopticService
    {
        void ShowSynoptic(Type entityType, object entityObject);
    }
}

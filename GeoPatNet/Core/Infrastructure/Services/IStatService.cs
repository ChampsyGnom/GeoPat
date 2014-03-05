using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Reflection;

namespace Emash.GeoPatNet.Infrastructure.Services
{
    public interface IStatService : IAvailableService
    {
       

        void ShowStatWizzard(EntityTableInfo entityTableInfo, List<string> fieldPaths);
    }
}

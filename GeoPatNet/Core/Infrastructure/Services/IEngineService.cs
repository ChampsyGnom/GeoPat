using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Services
{
    public interface IEngineService
    {
        T1 ShowAddDialog<T1>() where T1 : class, new();

        T1 ShowEditDialog<T1>(T1 model) where T1 : class, new();

       
        T1 ShowAddDialog<T1>(T1 node, string[] fieldPaths) where T1 : class, new();
    }
}

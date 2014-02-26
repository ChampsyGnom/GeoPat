using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Atom.Infrastructure.Services
{
    public interface IReperageService
    {
        void Initialize();

        string AbsToPr(long valueIdChaussee, long? valueAbs);
    }
}

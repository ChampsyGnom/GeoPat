using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Services
{
    public interface IReperageService
    {
        void Initialize();

        string AbsToPr(long chausseeId, long? valueAbs);
        long? PrToAbs(long chausseeId, string valuePr);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Data;

namespace Emash.GeoPatNet.Infrastructure.Services
{
    public interface ICartoService
    {
        void ShowCarto();
        void Initialize();
        DotSpatial.Topology.Geometry Geocode(long chausseeId, long absDeb);
        DotSpatial.Topology.Geometry Geocode(long chausseeId, long absDeb, long absFin);
    }
}

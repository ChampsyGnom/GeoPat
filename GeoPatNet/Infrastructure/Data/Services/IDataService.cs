using Emash.GeoPatNet.Atom.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Emash.GeoPatNet.Data.Infrastructure.Services
{
    public interface IDataService : IAvailableService
    {
        void Initialize(string connectionString);
        IQueryable<T> GetQueryable<T>() where T : class;
    }
}

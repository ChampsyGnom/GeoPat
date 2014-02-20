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
        DbContext DataContext { get; }
        void Initialize(string connectionString);
        DbSet<T> GetDbSet<T>() where T : class;
        T CreateItem<T>() where T : class;
    }
}

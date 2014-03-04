using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Services
{
    public abstract class IDataContext : DbContext
    {
        public abstract DbModelBuilder ModelBuilder { get;  }
        public IDataContext(System.Data.Common.DbConnection  connection)
            : base(connection,true)
        { }
    }
}

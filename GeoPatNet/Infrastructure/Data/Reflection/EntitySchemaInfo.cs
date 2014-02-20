using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Data.Infrastructure.Reflection
{
    public class EntitySchemaInfo
    {
        public List<EntityTableInfo> TableInfos { get;private  set; }
        public String SchemaName { get; set; }
        public EntitySchemaInfo()
        {
            this.TableInfos = new List<EntityTableInfo>();
        }
    }
}

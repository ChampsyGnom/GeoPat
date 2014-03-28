using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPat.Generator.Models
{
    public class DbSchema
    {
        public List<DbKeyPrimary> PrimaryKeys { get; private set; }
        public List<DbKeyUnique> UniqueKeys { get; private set; }
        public List<DbKeyForeign> ForeignKeys { get; private set; }

      
        public List<DbTable> Tables { get; private set; }
        public String DisplayName { get; set; }
        public String Name { get; set; }
        public String Id { get; set; }
        public DbSchema()
        {
            this.Tables = new List<DbTable>();
            this.PrimaryKeys = new List<DbKeyPrimary>();
            this.UniqueKeys = new List<DbKeyUnique>();
            this.ForeignKeys = new List<DbKeyForeign>();
        }
    }
}

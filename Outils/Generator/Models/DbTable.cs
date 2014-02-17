using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Generator.Models
{
    public class DbTable
    {
        public List<DbUniqueKey> UniqueKeys { get; set; }
        public List<DbForeignKey> ForeignKeys { get; set; }
        public DbPrimaryKey PrimaryKey { get; set; }
        public List<DbColumn> Columns { get; set; }
        public String DisplayName { get; set; }
        public String Name { get; set; }
        public String Id { get; set; }

        public DbTable()
        {
            this.UniqueKeys = new List<DbUniqueKey>();
            this.ForeignKeys = new List<DbForeignKey>();
            this.PrimaryKey = null;
            this.Columns = new List<DbColumn>();
        }
    }
}

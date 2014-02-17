using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Generator.Models
{
    public class DbView
    {
        public List<DbUniqueKey> UniqueKeys { get; set; }
        public List<DbForeignKey> ForeignKeys { get; set; }
        public List<DbPrimaryKey> PrimaryKeys { get; set; }
        public List<DbColumn> Columns { get; set; }

        public DbView()
        {
            this.UniqueKeys = new List<DbUniqueKey>();
            this.ForeignKeys = new List<DbForeignKey>();
            this.PrimaryKeys = new List<DbPrimaryKey>();
            this.Columns = new List<DbColumn>();
        }
    }
}

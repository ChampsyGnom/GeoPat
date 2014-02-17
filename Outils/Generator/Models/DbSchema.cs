using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Generator.Models
{
    public class DbSchema
    {
        public List<DbTable> Tables { get; set; }
        public List<DbView> Views { get; set; }
        public String DisplayName { get; set; }
        public String Name { get; set; }
        public String Id { get; set; }

        public DbSchema()
        {
            this.Tables = new List<DbTable>();
            this.Views = new List<DbView>();
        }
    }
}

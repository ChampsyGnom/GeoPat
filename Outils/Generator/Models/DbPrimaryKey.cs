using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Generator.Models
{
    public class DbPrimaryKey
    {
        public String DisplayName { get; set; }
        public String Name { get; set; }
        public String Id { get; set; }
        public List<String> ColumnIds { get; set; }

        public DbPrimaryKey()
        {
            this.ColumnIds = new List<string>();
        }
    }
}

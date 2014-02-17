using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Generator.Models
{
    public class DbUniqueKey
    {
        public String DisplayName { get; set; }
        public String Name { get; set; }
        public String Id { get; set; }
        public List<String> ColumnIds { get; set; }

        public DbUniqueKey()
        {
            this.ColumnIds = new List<string>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPat.Generator.Models
{
    public class DbKeyPrimary
    {
        public String DisplayName { get; set; }
        public String Name { get; set; }
        public String Id { get; set; }
        public String TableId { get; set; }
        public List<String> ColumnIds { get; set; }
        public DbKeyPrimary()
        {
            this.ColumnIds = new List<string>();
        }
    }
}

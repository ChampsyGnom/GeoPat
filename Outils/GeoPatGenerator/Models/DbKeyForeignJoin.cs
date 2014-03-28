using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPat.Generator.Models
{
    public class DbKeyForeignJoin
    {
        public String Id { get; set; }
        public String ColumnIdParent { get; set; }
        public String ColumnIdChild { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Generator.Models
{
    public class DbForeignKeyJoin
    {
        public String Id { get; set; }
        public String ChildColumnId { get; set; }
        public String ParentColumnId { get; set; }
    }
}

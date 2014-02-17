using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Generator.Models
{
    public class DbForeignKey
    {
        public String DisplayName { get; set; }
        public String Name { get; set; }
        public String Id { get; set; }
        public String ParentTableId { get; set; }
        public String ChildTableId { get; set; }
        public Boolean DeleteOnCascade { get; set; }
        public Boolean UpdateOnCascade { get; set; }
        public List<DbForeignKeyJoin> Joins { get; set; }

        public DbForeignKey()
        {
            this.Joins = new List<DbForeignKeyJoin>();
        }

    }
}

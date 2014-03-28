using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPat.Generator.Models
{
    public class DbKeyForeign
    {
        public String DisplayName { get; set; }
        public String Name { get; set; }
        public String Id { get; set; }
        public String TableIdParent { get; set; }
        public String TableIdChild { get; set; }
        public Boolean UpdateOnCascade { get; set; }
        public Boolean DeleteOnCascade { get; set; }
        public List<DbKeyForeignJoin> Joins { get; set; }

        public DbKeyForeign()
        {
            this.Joins = new List<DbKeyForeignJoin>();
        }
    }
}

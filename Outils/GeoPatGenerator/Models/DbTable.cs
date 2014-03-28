using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPat.Generator.Models
{
    public  class DbTable
    {
        public List<DbColumn> Columns { get; private set; }
        public String DisplayName { get; set; }
        public String Name { get; set; }
        public String Id { get; set; }

        public DbTable()
        {
            this.Columns = new List<DbColumn>();
        }
    }
}

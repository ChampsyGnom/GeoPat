using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPat.Generator.Models
{
    public class Project
    {
        public List<DbSchema> Schemas { get; private set; }

        public Project()
        {
            this.Schemas = new List<DbSchema>();
        }
    }
}

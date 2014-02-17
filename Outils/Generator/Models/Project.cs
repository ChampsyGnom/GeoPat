using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Generator.Models
{
    public class Project
    {
        public List<DbSchema> Schemas { get; set; }
        public String GeneratorCSharpDataNamespace { get; set; }
        public String GeneratorCSharpDataPath { get; set; }

        public String GeneratorCSharpBuisnessNamespace { get; set; }
        public String GeneratorCSharpBuisnessPath { get; set; }
        public Project()
        {
            this.Schemas = new List<DbSchema>();
        }
    }
}

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
        public String DataNamespace { get; set; }
        public String DataPath { get; set; }

        public String BuisnessNamespace { get; set; }
        public String BuisnessPath { get; set; }

        public String DataInfraNamespace { get; set; }
        public String DataInfraPath { get; set; }
        public String BuisnessInfraNamespace { get; set; }
        public String BuisnessInfraPath { get; set; }
        public Project()
        {
            this.Schemas = new List<DbSchema>();
        }
    }
}

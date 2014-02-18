using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Data.Infrastructure.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class SchemaNameAttribute : Attribute
    {
        public String SchemaName { get; private set; }

        public SchemaNameAttribute(string schemaName)
        {
            this.SchemaName = schemaName;
        }
    }
}

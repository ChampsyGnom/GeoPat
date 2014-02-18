using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Generator.IO
{
    public class TemplateProperty
    {
        public String TypeName { get; set; }
        public String PropertyName { get; set; }
        public List<String> Attributes { get; set; }

        public TemplateProperty(String typeName, String propertyName)
        {
            this.TypeName = typeName;
            this.PropertyName = propertyName;
            this.Attributes = new List<string>();
        }
    }
}

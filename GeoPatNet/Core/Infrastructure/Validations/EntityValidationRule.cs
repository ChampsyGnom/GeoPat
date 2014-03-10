using Emash.GeoPatNet.Infrastructure.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Validations
{
    public abstract class EntityValidationRule
    {
        public abstract  Boolean Validate(Object entityObject, Dictionary<String, String> valueStrings, EntityTableInfo tableInfo, out String message);
    }
}

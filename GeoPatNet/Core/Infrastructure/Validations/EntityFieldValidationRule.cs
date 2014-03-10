using Emash.GeoPatNet.Infrastructure.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Validations
{
    public abstract  class EntityFieldValidationRule
    {
        public abstract bool ValidateString(EntityFieldInfo fieldInfo, string valueString, out string message, out object result);
    }
}

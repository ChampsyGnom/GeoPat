using Emash.GeoPatNet.Infrastructure.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Validations
{
    public  class EntityFieldValidationRuleNotEmpty : EntityFieldValidationRule
    {
        public override bool ValidateString(EntityFieldInfo fieldInfo, string valueString, out string message, out object result)
        {
            if (String.IsNullOrEmpty (valueString ))
            {
                message = "valeur vide non autorisé";
                result = null;
                return false ;
            }
            else
            {
                message =null;
                result = valueString;
                return true;
            }
        }
    }
}

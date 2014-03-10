using Emash.GeoPatNet.Infrastructure.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Validations
{
    public class EntityFieldValidationRuleDataType : EntityFieldValidationRule
    {
        public override bool ValidateString(EntityFieldInfo fieldInfo, string valueString, out string message, out object result)
        {
            if (fieldInfo.ParentColumnInfo == null)
            {
                if (fieldInfo.ControlType == Attributes.ControlType.Pr)
                {
                    if (Validator.ValidateDataType(valueString, typeof (String), out message, out result))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (fieldInfo.ControlType == Attributes.ControlType.Pr)
                    {
                        if (Validator.ValidateDataType(valueString, typeof(String), out message, out result))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (Validator.ValidateDataType(valueString, fieldInfo.ColumnInfo.PropertyType, out message, out result))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                   
                }
               
            }
            else
            {
                if (fieldInfo.ControlType == Attributes.ControlType.Pr)
                {
                    if (Validator.ValidateDataType(valueString, typeof(string), out message, out result))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (Validator.ValidateDataType(valueString, fieldInfo.ParentColumnInfo.PropertyType, out message, out result))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
               
                
            }
            
        }
    }
}

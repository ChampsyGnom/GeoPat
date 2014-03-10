using Emash.GeoPatNet.Infrastructure.Attributes;
using Emash.GeoPatNet.Infrastructure.Reflection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Validations
{
    public class EntityFieldValidationRuleControlType : EntityFieldValidationRule
    {
        public override bool ValidateString(EntityFieldInfo fieldInfo, string valueString, out string message, out object value)
        {
            Int64 valueInt32 = 0;
            Double valueDouble = 0;
            DateTime valueDateTime = DateTime.Now;

            if (fieldInfo.ColumnInfo != null && fieldInfo.ParentColumnInfo == null)
            {
                EntityColumnInfo columnInfo = fieldInfo.ColumnInfo;
                
                    if (columnInfo.ControlType == ControlType.Check)
                    {
                        if (!columnInfo.AllowNull && valueString.Equals(CultureConfiguration.BooleanNullString))
                        {
                            value = null;
                            message = "valeur " + CultureConfiguration.BooleanNullString + " non autorisée";
                            return false;
                        }
                        else if (valueString.Equals(CultureConfiguration.BooleanNullString))
                        {
                            value = null;
                            message = null;
                            return true;
                        }
                        else if (valueString.Equals(CultureConfiguration.BooleanTrueString))
                        {
                            value = true;
                            message = null;
                            return true;
                        }
                        else if (valueString.Equals(CultureConfiguration.BooleanFalseString))
                        {
                            value = false;
                            message = null;
                            return true;
                        }
                        else
                        {
                            value = null;
                            message = null;
                            return true;
                        }
                    }
                    else if (columnInfo.ControlType == ControlType.Text)
                    {
                        if (valueString == null)
                        {
                            value = null;
                            message = "valeur vide non autorisé";
                            return false;
                        }
                        else
                        {
                            if (valueString.Length > columnInfo.MaxCharLength)
                            {
                                value = null;
                                message = "le texte de doit pas dépasser " + columnInfo.MaxCharLength + " caractères";
                                return false;
                            }
                            else
                            {
                                value = valueString;
                                message = null;
                                return true;
                            }
                        }
                       

                    }
                    else if (columnInfo.ControlType == ControlType.Color)
                    {
                        value = valueString;
                        message = null;
                        return true;
                    }
                    else if (columnInfo.ControlType == ControlType.Integer)
                    {
                        valueInt32 = Int64.Parse(valueString);
                        if (valueInt32 > columnInfo.MaxNumericValue)
                        {
                            message = "la valeur doit être inférieur à  " + columnInfo.MaxNumericValue;
                            value = null;
                            return false;
                        }
                        else if (valueInt32 < columnInfo.MinNumericValue)
                        {
                            message = "la valeur doit être supérieur à  " + columnInfo.MaxNumericValue;
                            value = null;
                            return false;
                        }
                        else
                        {
                            value = valueInt32;
                            message = null;
                            return true;
                        }


                    }
                    else if (columnInfo.ControlType == ControlType.Decimal)
                    {
                        valueDouble = Double.Parse(valueString.Replace(",", "."), NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture);
                        if (valueDouble > columnInfo.MaxNumericValue)
                        {
                            message = "la valeur doit être inférieur à  " + columnInfo.MaxNumericValue;
                            value = null;
                            return false;
                        }
                        else if (valueDouble < columnInfo.MinNumericValue)
                        {
                            message = "la valeur doit être supérieur à  " + columnInfo.MaxNumericValue;
                            value = null;
                            return false;
                        }
                        else
                        {
                            value = valueDouble;
                            message = null;
                            return true;
                        }


                    }
                    else if (columnInfo.ControlType == ControlType.Date)
                    {

                        if (columnInfo.AllowNull)
                        {
                            Nullable<DateTime> valNullableDateTime = null;
                            if (!Validator.ValidateNullableDateTime(valueString, out message, out valNullableDateTime))
                            {
                                value = null;
                                message = null;
                                return false;
                            }
                            else
                            {
                                value = valNullableDateTime;
                                message = null;
                                return true;
                            }
                        }
                        else
                        {
                            DateTime valDateTime = DateTime.Now;
                            if (!Validator.ValidateDateTime(valueString, out message, out valDateTime))
                            {
                                message = valueString + " n'est pas une date au format " + CultureConfiguration.DateFormatString;
                                value = null;
                                return false;
                            }
                            else
                            {
                                value = valDateTime;
                                message = null;
                                return true;
                            }
                        }
                    }
                    if (columnInfo.ControlType == ControlType.None)
                    {
                        value = valueString;
                        message = null;
                        return true;
                    }
                    else if (columnInfo.ControlType == ControlType.Pr)
                    {
                        Int64 dplt = 10;
                        Int64 num = 0;
                        if (valueString.IndexOf("+") != -1)
                        {
                            String[] prItems = valueString.Split("+".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            if (prItems.Length == 2)
                            {
                                if (!Int64.TryParse(prItems[0].Trim(), out num) || !Int64.TryParse(prItems[1].Trim(), out dplt))
                                {
                                    value = null;
                                    message = valueString + " n'est pas un PR au format 12+852";
                                    return false;
                                }
                                else
                                {
                                    value = num.ToString() + " +" + dplt.ToString("0000");
                                    message = null;
                                    return true;
                                }
                            }
                            else
                            {
                                value = null;
                                message = valueString + " n'est pas un PR au format 12+852";
                                return false;
                            }
                        }
                        else
                        {
                            if (!Int64.TryParse(valueString.Trim(), out num))
                            {
                                value = null;
                                message = valueString + " n'est pas un PR au format 12+852";
                                return false;
                            }
                            else
                            {
                                value = num.ToString() + " +0000";
                                message = null;
                                return true;
                            }
                        }
                    }
                }

            value = null;
            message = null;
            return true;

           

               
            
            
        }
    }
}

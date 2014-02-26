using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Data.Infrastructure.Validations
{
    public enum DatePart
    {
        Day,
        Month,
        Year,
        None
    }
    public class Validator
    {
        public static Boolean ValidateObject(Object valueObject, EntityColumnInfo dbProp, out String message, out Object value)
        {
            String valueString = "";
            if (valueObject != null)
            { valueString = valueObject.ToString(); }
            message = null;
            value = null;
            if ((!dbProp.AllowNull && valueObject == null) || (!dbProp.AllowNull && valueObject != null && String.IsNullOrEmpty(valueObject.ToString())))
            {
                value = null;
                message = "valeur vide non autorisée";
                return false;
            }
            Type dataType = dbProp.Property.PropertyType;
            if (dataType.Equals(typeof(String)))
            {
                value = valueString;
                message = null;
                return true;
            }
            else if (dataType.Equals(typeof(Boolean)))
            {
                bool valBool = false;
                if (Validator.ValidateBoolean(valueString, out message, out valBool))
                {
                    value = valBool;
                    message = null;
                    return true;
                }
                else
                {
                    value = null;
                    return false;
                }
            }
            else if (dataType.Equals(typeof(Double)))
            {
                Double valDouble = 0;
                if (Validator.ValidateDouble(valueString, out message, out valDouble))
                {
                    value = valDouble;
                    message = null;
                    return true;
                }
                else
                {
                    value = null;
                    return false;
                }
            }
            else if (dataType.Equals(typeof(Int64)))
            {
                if (dbProp.ControlType == Presentation.Infrastructure.Attributes.ControlType.Pr)
                {
                    value = valueString;
                    message = null;
                    return true;
                }
                else
                {
                    Int64 valInt64 = 0;
                    if (Validator.ValidateInt64(valueString, out message, out valInt64))
                    {
                        value = valInt64;
                        message = null;
                        return true;
                    }
                    else
                    {
                        value = null;
                        return false;
                    }
                }
                
            }
            else if (dataType.Equals(typeof(DateTime)))
            {
                DateTime valDateTime = DateTime.Now;
                if (Validator.ValidateDateTime(valueString, out message, out valDateTime))
                {
                    value = valDateTime;
                    message = null;
                    return true;
                }
                else
                {
                    value = null;
                    return false;
                }
            }
            else if (dataType.Equals(typeof(Nullable<Boolean>)))
            {
                Nullable<bool> valBool = false;
                if (Validator.ValidateNullableBoolean(valueString, out message, out valBool))
                {
                    value = valBool;
                    message = null;
                    return true;
                }
                else
                {
                    value = null;
                    return false;
                }
            }
            else if (dataType.Equals(typeof(Nullable<Double>)))
            {
                Nullable<Double> valDouble = 0;
                if (Validator.ValidateNullableDouble(valueString, out message, out valDouble))
                {
                    value = valDouble;
                    message = null;
                    return true;
                }
                else
                {
                    value = null;
                    return false;
                }
            }
            else if (dataType.Equals(typeof(Nullable<Int64>)))
            {
                if (dbProp.ControlType == Presentation.Infrastructure.Attributes.ControlType.Pr)
                {
                    value = valueString;
                    message = null;
                    return true;
                }
                else
                {
                    Nullable<Int64> valInt64 = 0;
                    if (Validator.ValidateNullableInt64(valueString, out message, out valInt64))
                    {
                        value = valInt64;
                        message = null;
                        return true;
                    }
                    else
                    {
                        value = null;
                        return false;
                    }
                }
               
            }
            else if (dataType.Equals(typeof(Nullable<DateTime>)))
            {
                Nullable<DateTime> valDateTime = DateTime.Now;
                if (Validator.ValidateNullableDateTime(valueString, out message, out valDateTime))
                {
                    value = valDateTime;
                    message = null;
                    return true;
                }
                else
                {
                    value = null;
                    return false;
                }
            }
            value = null;
            message = "Type de donnée non gérée";
            return false;
        }

        public static bool ValidateInt64(String str, out string message, out Int64 valueInt64)
        {
            valueInt64 = -1;
            if (!Int64.TryParse(str, out valueInt64))
            {
                message = str + " n'est pas un entier valide";
                return false;
            }
            message = null;
            return true;
        }

        public static bool ValidateDouble(String str, out string message, out Double valueDouble)
        {
            valueDouble = -1;
            if (!Double.TryParse(str.Replace(",", "."), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out valueDouble))
            {
                message = str + " n'est pas un nombre à virgule valide";
                return false;
            }
            message = null;
            return true;
        }

        public static bool ValidateNullableInt64(string str, out string message, out long? valueNullableInt64)
        {
            valueNullableInt64 = null;
            Int64 valueInt64 = 0;
            if (!String.IsNullOrEmpty(str))
            {
                if (!Int64.TryParse(str, out valueInt64))
                {
                    message = str + " n'est pas un entier valide";

                    return false;
                }
                else
                {
                    valueNullableInt64 = valueInt64;
                }
            }
            message = null;
            return true;
        }
        /// <summary>
        /// Alors la le parsing des parties de date suivant la langue c'est pas évident ....
        /// On peut considéré que seul des / et des - sont utilisé pour séparé les parties
        /// On peut considérer que l'année est toujours supérieur à 31 (pas de patrimoine en 31 après jesus christ :) )
        /// Si on as aucun séparateur  c'est une année , c'est sur
        /// Si on as un séparateur , l'anné c'est celui qui est supérieur à 31, le mois est l'autre
        /// Si on as deux séparateur, on tente un parsing de date normal avec CultureConfiguration.DateTimeFormat
        /// Du coup sa marche dans tout les cas :)
        /// Pour les test on prend pas 31 mais 1000 c'est plus lisible
        /// </summary>
        /// <param name="str"></param>
        /// <param name="message"></param>
        /// <param name="date"></param>
        /// <param name="datePart"></param>
        /// <returns></returns>
        public static bool ValidateDatePart(string str, out string message, out DateTime date, out DatePart datePart)
        {
            date = DateTime.Now;
            datePart = DatePart.None;
            message = null;
            if (!String.IsNullOrEmpty(str))
            {
                int countSeparator = str.Count(f => f == '/' || f == '-');
                if (countSeparator == 0)
                {
                    Int64 year = -1;
                    if (ValidateInt64(str, out message, out  year))
                    {
                        datePart = DatePart.Year;
                        date = new DateTime((int)year, 1, 1);
                        return true;
                    }
                }
                else if (countSeparator == 1)
                {
                    // on traite tous les séparateur ...
                    String[] itemsSplash = str.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    String[] itemsTiret = str.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    List<String> items = new List<string>();
                    items.AddRange(itemsSplash);
                    items.AddRange(itemsTiret);
                    Int64 value1 = -1;
                    Int64 value2 = -1;
                    Int64 valueMonth = -1;
                    Int64 valueYear = -1;
                    if (ValidateInt64(items[0], out message, out  value1) && ValidateInt64(items[1], out message, out  value2))
                    {
                        if (value1 > 1000 && value2 <= 12 && value2 > 0)
                        {
                            valueYear = value1;
                            valueMonth = value2;
                        }
                        else if (value2 > 1000 && value1 <= 12 && value2 > 0)
                        {
                            valueYear = value2;
                            valueMonth = value2;
                        }
                        datePart = DatePart.Month;
                        date = new DateTime((int)valueYear, (int)valueMonth, 1);
                        return true;

                    }
                }
                else if (countSeparator == 2)
                {
                    if (DateTime.TryParseExact(str, CultureConfiguration.DateFormatString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date))
                    {
                        datePart = DatePart.Day;
                        return true;
                    }
                }

            }

            return false;
        }
        public static bool ValidateDateTime(string str, out string message, out DateTime valueDateTime)
        {
            message = null;
            valueDateTime = DateTime.Now;
            if (String.IsNullOrEmpty(str))
            {
                message = str + " n'est pas une date au format " + CultureConfiguration.DateFormatString;
                return false;
            }
            else if (DateTime.TryParseExact(str, CultureConfiguration.DateFormatString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out valueDateTime))
            {

                return true;
            }
            else
            {
                message = str + " n'est pas une date au format " + CultureConfiguration.DateFormatString;
                return false;
            }

        }

        public static bool ValidateBoolean(string str, out string message, out bool valueBoolean)
        {

            valueBoolean = false;
            message = "";
            if (String.IsNullOrEmpty(str))
            {
                message = str + " n'est pas une valeur Oui/Non";
                return false;
            }
            else if (str.ToLower().Equals(CultureConfiguration.BooleanTrueString.ToLower()))
            {
                message = null;
                valueBoolean = true;
                return true;
            }
            else if (str.ToLower().Equals(CultureConfiguration.BooleanFalseString.ToLower()))
            {
                message = null;
                valueBoolean = false;
                return true;
            }
            else
            {
                message = str + " n'est pas une valeur Oui/Non";
                return false;
            }
        }

        public static bool ValidateNullableBoolean(string str, out string message, out bool? valueBoolean)
        {

            valueBoolean = null;
            if (String.IsNullOrEmpty(str))
            {
                message = str + " n'est pas une valeur Oui/Non";
                return false;
            }
            else if (str.ToLower().Equals(CultureConfiguration.BooleanNullString.ToLower()))
            {
                message = null;
                valueBoolean = null;
                return true;
            }
            else if (str.ToLower().Equals(CultureConfiguration.BooleanTrueString.ToLower()))
            {
                message = null;
                valueBoolean = true;
                return true;
            }
            else if (str.ToLower().Equals(CultureConfiguration.BooleanFalseString.ToLower()))
            {
                message = null;
                valueBoolean = false;
                return true;
            }
            else
            {
                message = str + " n'est pas une valeur Oui/Non";
                return false;
            }

        }

        public static bool ValidateNullableDateTime(string str, out string message, out DateTime? valueDateTime)
        {
            message = null;
            valueDateTime = DateTime.Now;
            DateTime parsedDate = DateTime.Now;
            if (String.IsNullOrEmpty(str))
            {
                valueDateTime = null;
                return true;
            }
            else if (DateTime.TryParseExact(str, CultureConfiguration.DateFormatString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
            {
                valueDateTime = parsedDate;
                return true;
            }
            else
            {
                message = str + " n'est pas une date au format " + CultureConfiguration.DateFormatString;
                return false;
            }
        }

        public static bool ValidateNullableDouble(string str, out string message, out double? valueNullableDouble)
        {
            valueNullableDouble = null;
            double valueDouble = 0;
            if (!String.IsNullOrEmpty(str))
            {
                if (!Double.TryParse(str.Replace(",", "."), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out valueDouble))
                {
                    message = str + " n'est pas un nombre à virgule valide";
                    return false;
                }
                else
                {
                    valueNullableDouble = valueDouble;
                }

            }
            message = null;
            return true;
        }
    }
}

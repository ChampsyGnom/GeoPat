
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Attributes;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Infrastructure.Reflection;

namespace Emash.GeoPatNet.Infrastructure.Validations
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
       
      

        public static Boolean ValidateDataType(String valueString, Type dataType, out String message, out Object value)
        {

            message = null;
            value = null;
            Int64 valueInt32 = 0;
            Double valueDouble = 0;
            Boolean valueBoolean = false;
            DateTime valueDateTime = DateTime.Now;
            



            if (dataType.Equals (typeof (String)))
            {
                message = null;
                value = valueString;
                return true;
            }
            else if (dataType.Equals(typeof(Int64)))
            {
                if (String.IsNullOrEmpty(valueString))
                {
                    message = "valeur vide non autoriséeé";
                    return false;
                }
                else
                {
                    if (Int64.TryParse(valueString, out valueInt32))
                    {
                        value = valueInt32;
                        message = null;
                        return true;
                    }
                    else
                    {
                        message = valueString+" n'est pas un nombre entier valide";
                        return false;
                    }
                }
            }
            else if (dataType.Equals(typeof(Double)))
            {
                if (String.IsNullOrEmpty(valueString))
                {
                    message = "valeur vide non autoriséeé";
                    return false;
                }
                else
                {
                    if (Double.TryParse(valueString.Replace(",", "."),System.Globalization.NumberStyles.AllowDecimalPoint,System.Globalization.CultureInfo.InvariantCulture, out valueDouble))
                    {
                        message = null;
                        return true;
                    }
                    else
                    {
                        message = valueString + " n'est pas un nombre à virgule flottante valide";
                        return false;
                    }
                }
            }
            else if (dataType.Equals(typeof(Boolean)))
            {
                if (String.IsNullOrEmpty(valueString))
                {
                    message = "valeur vide non autoriséeé";
                    return false;
                }
                else
                {
                    if (valueString.Equals(CultureConfiguration.BooleanTrueString))
                    {
                  
                        value = true;
                        message = null;
                        return true;
                    }
                    else if (valueString.Equals("OUI"))
                    {
                        value = true;
                        message = null;
                        return true;
                    }
                    else if (valueString.Equals("NON"))
                    {
                        value = false;
                        message = null;
                        return true;
                    }
                    else if (valueString.Equals(CultureConfiguration.BooleanFalseString))
                    {
                        value = false;
                        message = null;
                        return true;
                    }
                    if (Boolean.TryParse(valueString, out valueBoolean))
                    {
                        value = valueBoolean;
                        message = null;
                        return true;
                    }
                    else
                    {
                        message = valueString + " n'est pas une valeur oui/non valide";
                        return false;
                    }
                }
            }           
            else if (dataType.Equals(typeof(DateTime)))
            {
                if (String.IsNullOrEmpty(valueString))
                {
                    message = "valeur vide non autoriséeé";
                    return false;
                }
                else
                {
                    if (valueString.IndexOf(" ") != -1)
                    {
                        valueString = valueString.Substring(0, valueString.IndexOf(" "));
                    }
                    if (DateTime.TryParseExact(valueString,CultureConfiguration.DateFormatString,System.Globalization.CultureInfo.InvariantCulture ,System.Globalization.DateTimeStyles.None ,out valueDateTime ))
                    {
                        value = valueDateTime;
                        message = null;
                        return true;
                    }
                    else
                    {
                        message = valueString + " n'est pas une date au format "+CultureConfiguration.DateFormatString;
                        return false;
                    }
                }
            }
            else if (dataType.Equals(typeof(Nullable<Int64>)))
            {
                if (String.IsNullOrEmpty(valueString))
                {
                    message = null;
                    return true;
                }
                else
                {
                    if (Int64.TryParse(valueString, out valueInt32))
                    {
                        message = null;
                        return true;
                    }
                    else
                    {
                        message = valueString + " n'est pas un nombre entier valide";
                        return false;
                    }
                }
                
            }
            else if (dataType.Equals(typeof(Nullable<Double>)))
            {
                if (String.IsNullOrEmpty(valueString))
                {
                    message = null;
                    return true;
                }
                else
                {
                    if (Double.TryParse(valueString.Replace(",", "."),System.Globalization.NumberStyles.AllowDecimalPoint,System.Globalization.CultureInfo.InvariantCulture, out valueDouble))
                    {
                        message = null;
                        return true;
                    }
                    else
                    {
                        message = valueString + " n'est pas un nombre à virgule flottante valide";
                        return false;
                    }
                }
            }
            else if (dataType.Equals(typeof(Nullable<Boolean>)))
            {
                if (String.IsNullOrEmpty(valueString) || valueString.Equals ("VIDE"))
                {
                    value = null;
                    message = null;
                    return true;
                }
                else
                {
                    if (valueString.Equals(CultureConfiguration.BooleanTrueString))
                    {
                        value = true;
                        message = null;
                        return true;
                    }
                    else if (valueString.Equals("OUI"))
                    {
                        value = true;
                        message = null;
                        return true;
                    }
                    else if (valueString.Equals("NON"))
                    {
                        value = false;
                        message = null;
                        return true;
                    }
                    else if (valueString.Equals(CultureConfiguration.BooleanFalseString))
                    {
                        value = false;
                        message = null;
                        return true;
                    }
                    if (Boolean.TryParse(valueString, out valueBoolean))
                    {
                        message = null;
                        value = valueBoolean;
                        return true;
                    }
                    else
                    {
                        message = valueString + " n'est pas une valeur oui/non valide";
                        return false;
                    }
                }
            }
            else if (dataType.Equals(typeof(Nullable<DateTime>)))
            {
                if (String.IsNullOrEmpty(valueString))
                {
                    message = null;
                    return true;
                }
                else
                {
                    if (DateTime.TryParseExact(valueString, CultureConfiguration.DateFormatString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out valueDateTime))
                    {
                        message = null;
                        return true;
                    }
                    else
                    {
                        message = valueString + " n'est pas une date au format " + CultureConfiguration.DateFormatString;
                        return false;
                    }
                }
            }
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
                            valueMonth = value1;
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
            else
            {
                if (str.IndexOf(" ") != -1)
                { str = str.Substring(0, str.IndexOf(" ")); }
                if (DateTime.TryParseExact(str, CultureConfiguration.DateFormatString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out valueDateTime))
                {
                    valueDateTime = valueDateTime;
                    return true;
                }
                else
                {
                    message = str + " n'est pas une date au format " + CultureConfiguration.DateFormatString;
                    return false;
                }
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
            else
            {
                if (str.IndexOf(" ") != -1)
                { str = str.Substring(0, str.IndexOf(" ")); }

                if (DateTime.TryParseExact(str, CultureConfiguration.DateFormatString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
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

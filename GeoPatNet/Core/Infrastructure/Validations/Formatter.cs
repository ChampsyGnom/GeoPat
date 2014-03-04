using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Validations
{
    public class Formatter
    {
        public static string FormatValue(Type type, object value)
        {
            if (value == null) return "";
            if (type.Equals(typeof(String)))
            {
                return value.ToString();
            }
            else if (type.Equals(typeof(Boolean)))
            {
                bool val = (Boolean)value;
                if (val)
                { return CultureConfiguration.BooleanTrueString; }
                else
                { return CultureConfiguration.BooleanFalseString; }
            }
            else if (type.Equals(typeof(Int64)))
            {
                Int64 val = (Int64)value;
                return val.ToString();

            }
            else if (type.Equals(typeof(Double)))
            {
                Double val = (Double)value;
                return val.ToString().Replace(",", ".");
            }
            else if (type.Equals(typeof(DateTime)))
            {
                DateTime val = (DateTime)value;
                return val.ToString(CultureConfiguration.DateFormatString);
            }
            else if (type.Equals(typeof(Nullable<Boolean>)))
            {
                Nullable<Boolean> val = (Nullable<Boolean>)value;
                if (val.HasValue)
                {
                    if (val.Value)
                    { return CultureConfiguration.BooleanTrueString; }
                    else
                    { return CultureConfiguration.BooleanFalseString; }
                }
                else return null;
            }
            else if (type.Equals(typeof(Nullable<Int64>)))
            {
                Nullable<Int64> val = (Nullable<Int64>)value;
                if (val.HasValue)
                {
                    return val.Value.ToString();
                }
                else return null;
            }
            else if (type.Equals(typeof(Nullable<Double>)))
            {
                Nullable<Double> val = (Nullable<Double>)value;
                if (val.HasValue)
                {
                    return val.Value.ToString().Replace(",", ".");
                }
                else return null;
            }
            else if (type.Equals(typeof(Nullable<DateTime>)))
            {
                Nullable<DateTime> val = (Nullable<DateTime>)value;
                if (val.HasValue)
                {
                    return val.Value.ToString(CultureConfiguration.DateFormatString);
                }
                else return null;
            }

            return value.ToString();
        }
    }
}

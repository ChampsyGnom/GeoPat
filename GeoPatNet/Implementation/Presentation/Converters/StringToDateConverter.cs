using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Emash.GeoPatNet.Data.Infrastructure.Validations;

namespace Emash.GeoPatNet.Presentation.Implementation.Converters
{
    public class StringToDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value is String)
            { 
                  DateTime dt =DateTime.Now;
                  if (DateTime.TryParseExact(value.ToString(), CultureConfiguration.DateFormatString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                  {
                      return dt;
                  }
                  else return null;
            }
            return null;
         
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value is DateTime)
            {
                DateTime dt =(DateTime) value;
                return dt.ToString(CultureConfiguration.DateFormatString);
            }
            else return null;
           
        }
    }
}

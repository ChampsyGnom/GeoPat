using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Emash.GeoPatNet.Presentation.Implementation.Converters
{
    public class StringToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;
            String valueString = value.ToString();
            String[] items = valueString.Split("#".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (items.Length == 4)
            {
                byte r, g, b, a;
                if (Byte.TryParse(items[0], out r) && Byte.TryParse(items[1], out g) && Byte.TryParse(items[2], out b) && Byte.TryParse(items[3], out a))
                { return new SolidColorBrush(Color.FromArgb(a, r, g, b)); }
            }
            return Brushes.Gray;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;
            if (value is SolidColorBrush)
            {
                SolidColorBrush brush = (SolidColorBrush)value;
                return brush.Color.R.ToString() + "#" + brush.Color.G.ToString() + "#" + brush.Color.B.ToString() + "#" + brush.Color.A.ToString();
            }
            return null;
        }
    }
}

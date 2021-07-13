using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Cinemanote.Converters
{
    class RateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal rate = (decimal)value;
            return rate.ToString("C", culture);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string rate = value.ToString();
            decimal result;
            if (Decimal.TryParse(rate, NumberStyles.Any, culture, out result)) return result; 
            return value;
        }
    }
}

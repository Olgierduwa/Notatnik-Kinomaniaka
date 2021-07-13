using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Cinemanote
{
    class ListWidthConverter : IValueConverter
    {
        public GridLength MaxWidth { get; set; }
        public GridLength DefaultWidth { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var movie = (Movie)value;
            if (movie != null) return DefaultWidth;
            else return MaxWidth;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

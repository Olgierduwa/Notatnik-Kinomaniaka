﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Cinemanote
{
    class PremiereToBackgroundConverter : IValueConverter
    {
        public Brush HighlightBrush { get; set; }
        public Brush DefaultBrush { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool Premiere = (bool)value;
            if (Premiere == true) return HighlightBrush;
            else return DefaultBrush;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

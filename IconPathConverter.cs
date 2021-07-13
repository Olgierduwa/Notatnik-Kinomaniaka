using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Cinemanote
{
    class IconPathConverter : IValueConverter
    {
        public IconPathConverter()
        {
            string dir = null, imgdir;
            do
            {
                if (dir == null) dir = Directory.GetCurrentDirectory();
                else dir = Directory.GetParent(dir).ToString();
                imgdir = System.IO.Path.Combine(dir, "icons");
            } while (!Directory.Exists(imgdir));
            IconDirectory = imgdir;
        }
        public string IconDirectory { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string imagePath = "xd.jpg";
                if ((bool)value == true)
                    imagePath = System.IO.Path.Combine(IconDirectory, "watch.jpg");
                return new BitmapImage(new Uri(imagePath));
            }
            catch
            {
                return Binding.DoNothing;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Enhanced_Guild_Wars_2.User_Controls.Converter
{
    public class ImagePathConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {

            // Concatenate the values.
            string filename = Path.Combine(values[0].ToString(), values[1].ToString());

            // You can either use an ImageSourceConverter
            // to create your image source from the path.
            //ImageSourceConverter imageConverter = new ImageSourceConverter();
            //return imageConverter.ConvertFromString(filename);

            // ...or you can create a new bitmap with the combined path.
            return new BitmapImage(new Uri(filename, UriKind.RelativeOrAbsolute));

            //string location = @"..\..\Assets\Images\";

            //var path = location + values.OfType<string>().ToArray();
            //var bi = new BitmapImage();
            //bi.BeginInit();
            //bi.UriSource = new Uri(path, UriKind.Absolute);
            //bi.EndInit();
            //return bi;
        }

        public object[] ConvertBack(
            object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace NewsDashboard.ValueConverters
{
    public class ColorToUIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //Receive hex #, return Int
            var colorString = value.ToString();
            int hexColorR = int.Parse(colorString.Substring(0,2));
            int hexColorG = int.Parse(colorString.Substring(2, 2));
            int hexColorB = int.Parse(colorString.Substring(4, 2));

            var color = System.Drawing.Color.FromArgb(hexColorR,hexColorG,hexColorB);

            return (uint)((color.A << 24) | (color.R << 16) | (color.G << 8) | (color.B << 0));
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace BindingDemo
{
    [ValueConversion(typeof(Int32),typeof(Brush))]
    public class CisloToBarvaConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int cislo = (int)value;
            if (cislo < 100)
                return Brushes.Green;
            if (cislo < 1000)
                return Brushes.Yellow;
            return Brushes.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

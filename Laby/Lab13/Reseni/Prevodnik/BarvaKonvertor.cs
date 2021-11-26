using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Prevodnik
{
    [ValueConversion(typeof(double),typeof(Brush))]
    class BarvaKonvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double hodnota = (double) value;
            if (hodnota < 100)
                return Brushes.Black;
            if (hodnota < 500)
                return Brushes.Green;
            return Brushes.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

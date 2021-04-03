using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prevodnik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PrevodCnaF(object sender, RoutedEventArgs e)
        {
            if (!Double.TryParse(TextRadek1.Text, out double hodnota))
                return;

            double vysledek = 1.8 * hodnota + 32;
            VysledekRadek1.Content = vysledek.ToString();
        }

        private void PrevodFnaC(object sender, RoutedEventArgs e)
        {
            if (!Double.TryParse(TextRadek2.Text, out double hodnota))
                return;

            double vysledek =  (hodnota - 32)/1.8;
            VysledekRadek2.Content = vysledek.ToString();
        }

        private void PrevodMtoS(object sender, RoutedEventArgs e)
        {
            if (!Double.TryParse(TextRadek3.Text, out double hodnota))
                return;

            double vysledek = hodnota * 3.280839895;
            VysledekRadek3.Content = vysledek.ToString();
        }

        private void PrevodStoM(object sender, RoutedEventArgs e)
        {
            if (!Double.TryParse(TextRadek4.Text, out double hodnota))
                return;

            double vysledek = hodnota / 3.280839895;
            VysledekRadek4.Content = vysledek.ToString();
        }
    }
}

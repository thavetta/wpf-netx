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

        private void Prevod(object sender, RoutedEventArgs e)
        {
            if (!(e.Source is Button tlacitko))
                return;
            TextBox vstup;
            Label vystup;
            Func<double, double> vypocet;

            switch (tlacitko.Tag)
            {
                case "CnaF":
                    vstup = TextRadek1;
                    vystup = VysledekRadek1;
                    vypocet = x => 1.8 * x + 32;
                    break;
                case "FnaC":
                    vstup = TextRadek2;
                    vystup = VysledekRadek2;
                    vypocet = x => (x - 32) / 1.8;
                    break;
                case "MnaS":
                    vstup = TextRadek3;
                    vystup = VysledekRadek3;
                    vypocet = x => x * 3.280839895;
                    break;
                case "SnaM":
                    vstup = TextRadek4;
                    vystup = VysledekRadek4;
                    vypocet = x => x / 3.280839895;
                    break;
                default:
                    return;
            }

            if (!Double.TryParse(vstup.Text, out double hodnota))
                return;

            double vysledek = vypocet(hodnota);
            vystup.Content = vysledek.ToString();
        }
    }
}

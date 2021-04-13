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
using System.Windows.Threading;

namespace Prevodnik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RoutedCommand PrevodCommand = new RoutedCommand();

        public MainWindow()
        {
            InitializeComponent();
            this.Dispatcher.UnhandledException += AkceOnUnhandledException;
        }

        private void AkceOnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString(),"Dispatcher handler");
            //Nastavenim na true zabrani padu aplikace = jako by vyjimku vzal catch blok
            //Nastavenim false se bere vyjimka jako neosetrena a postupuje dal
            e.Handled = false; 
        }

        private void CanExecutePrevod(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!(e.Source is TextBox vstup))
                return;
            e.CanExecute = vstup.Text.Length > 0;
        }

        private void ExecutedPrevod(object sender, ExecutedRoutedEventArgs e)
        {
            if (!(e.Source is TextBox vstup))
                return;
            Label vystup;
            Func<double, double> vypocet;

            switch (e.Parameter.ToString())
            {
                case "CnaF":
                    vystup = VysledekRadek1;
                    vypocet = x => 1.8 * x + 32;
                    break;
                case "FnaC":
                    vystup = VysledekRadek2;
                    vypocet = x => (x - 32) / 1.8;
                    break;
                case "MnaS":
                    vystup = VysledekRadek3;
                    vypocet = x => x * 3.280839895;
                    break;
                case "SnaM":
                    vystup = VysledekRadek4;
                    vypocet = x => x / 3.280839895;
                    break;
                default:
                    return;
            }

            //if (!Double.TryParse(vstup.Text, out double hodnota))
            //    return;
            double hodnota = double.Parse(vstup.Text);

            double vysledek = vypocet(hodnota);
            vystup.Content = vysledek.ToString();
        }
    }
}

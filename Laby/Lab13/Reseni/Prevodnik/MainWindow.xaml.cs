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
        public MainWindow()
        {
            InitializeComponent();
            NastavLabel();
        }

        private void NastavLabel()
        {
            SuperLabel.Barvy = Properties.Settings.Default.Barvicky;
            SuperLabel.Hranice = Properties.Settings.Default.Hranice;
        }

        private void AkceCnaF(object sender, RoutedEventArgs e)
        {
            VypocetPrevodu prevodnik = this.Resources["VypocetPrevodu"] as VypocetPrevodu;
            prevodnik.Prevod = x => 1.8 * x + 32;
            prevodnik.Vypocet();
        }

        private void AkceFnaC(object sender, RoutedEventArgs e)
        {
            VypocetPrevodu prevodnik = this.Resources["VypocetPrevodu"] as VypocetPrevodu;
            prevodnik.Prevod = x => (x - 32) / 1.8;
            prevodnik.Vypocet();
        }

        private void AkceMnaS(object sender, RoutedEventArgs e)
        {
            VypocetPrevodu prevodnik = this.Resources["VypocetPrevodu"] as VypocetPrevodu;
            prevodnik.Prevod = x => x * 3.280839895;
            prevodnik.Vypocet();
        }

        private void AkceSnaM(object sender, RoutedEventArgs e)
        {
            VypocetPrevodu prevodnik = this.Resources["VypocetPrevodu"] as VypocetPrevodu;
            prevodnik.Prevod = x => x / 3.280839895;
            prevodnik.Vypocet();
        }

        private void Konec(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Nastaveni(object sender, RoutedEventArgs e)
        {
            Nastaveni nastaveni = new();
            nastaveni.ShowDialog();
            NastavLabel();
        }
    }
}

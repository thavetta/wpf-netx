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

namespace KolekceDemo
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SeznamOsob seznam = this.Resources["Seznam"] as SeznamOsob;

            seznam.Add(new Osoba() { Jmeno = "Petr", Mesto = "Jihlava" });

            var query = from x in seznam
                        where x.Jmeno.StartsWith("J") || x.Jmeno.StartsWith("T")
                        select new { Name = x.Jmeno, City = x.Mesto };

            var cislo = seznam.Sum(x => x.Jmeno.Length);

            HlavniGrid.DataContext = query;

        }
    }
}

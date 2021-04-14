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

namespace Vlakna
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

        private async void Akce(object sender, RoutedEventArgs e)
        {
            InfoLabel.Content = "Pracuji";
            var pracant = new Pracant();
            Progress<int> progress = new Progress<int>(x => HlavniProgress.Value = x);

            string vysledek = await Task.Factory.StartNew((() => pracant.DlouhaAkce(100,progress)));

            InfoLabel.Content = vysledek;
        }
    }
}

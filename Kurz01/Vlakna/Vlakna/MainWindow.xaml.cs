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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            InfoLabel.Content = "Pracuji...";

            var progress = new Progress<int>(x => InfoProgress.Value = x);

            var pracant = new Pracant();
            string vysledek = await Task.Factory.StartNew(() => pracant.DlouhaAkce(15,progress));
            
            InfoLabel.Content = vysledek;
        }
    }
}

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
using System.Windows.Shapes;

namespace Prevodnik
{
    /// <summary>
    /// Interaction logic for Nastaveni.xaml
    /// </summary>
    public partial class Nastaveni : Window
    {
        public Nastaveni()
        {
            InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Reload();
            this.Close();
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Reset();
            this.Close();
        }
    }
}

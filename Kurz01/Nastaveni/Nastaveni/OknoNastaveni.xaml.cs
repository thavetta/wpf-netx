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

namespace Nastaveni
{
    /// <summary>
    /// Interaction logic for OknoNastaveni.xaml
    /// </summary>
    public partial class OknoNastaveni : Window
    {
        public OknoNastaveni()
        {
            InitializeComponent();
        }

        private void OKAkce(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void CancelAkce(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Reload();
            this.Close();
        }
    }
}

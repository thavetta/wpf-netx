using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Prevodnik
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //Po odkomentování bude UI ve slovenštině

            //CultureInfo localization = new CultureInfo("sk-sk");
            //Thread.CurrentThread.CurrentCulture = localization;
            //Thread.CurrentThread.CurrentUICulture = localization;

        }
        
    }
}

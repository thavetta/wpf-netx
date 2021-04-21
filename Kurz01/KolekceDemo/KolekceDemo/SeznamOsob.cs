using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolekceDemo
{
    public class SeznamOsob : ObservableCollection<Osoba>
    {
        public SeznamOsob()
        {
            Add(new Osoba() { Jmeno = "Tomas", Mesto = "Brno" });
            Add(new Osoba() { Jmeno = "Jana", Mesto = "Ostrava" });
            Add(new Osoba() { Jmeno = "Marek", Mesto = "Prerov" });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoby
{
    public class SeznamOsob : ObservableCollection<Osoba>
    {
        public SeznamOsob()
        {
            Add(new Osoba(){Jmeno = "Martin", Prijmeni = "Kuba", Mesto = "Brno", Plat = 35000});
            Add(new Osoba() { Jmeno = "Jana", Prijmeni = "Mala", Mesto = "Praha", Plat = 40000 });
            Add(new Osoba() { Jmeno = "Eva", Prijmeni = "Novotna", Mesto = "Prerov", Plat = 38000 });
            Add(new Osoba() { Jmeno = "Karel", Prijmeni = "Kral", Mesto = "Ostrava", Plat = 28000 });
            Add(new Osoba() { Jmeno = "Jiri", Prijmeni = "Kovar", Mesto = "Liberec", Plat = 52000 });

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMStart.Models;

namespace MVVMStart.Data
{
    public class DataSource
    {
        public static IEnumerable<Osoba> GetListOsob()
        {
            var response = new List<Osoba>();

            response.Add(new Osoba() {Meno = "Tomas",Mesto = "Brno", DatumNarozeni = new DateTime(1965,1,1), PocetDeti = 1});
            response.Add(new Osoba() { Meno = "Pavel", Mesto = "Ostrava", DatumNarozeni = new DateTime(1970, 1, 1), PocetDeti = 2 });
            response.Add(new Osoba() { Meno = "Jana", Mesto = "Zlin", DatumNarozeni = new DateTime(1977, 1, 1), PocetDeti = 2 });
            response.Add(new Osoba() { Meno = "Petra", Mesto = "Prerov", DatumNarozeni = new DateTime(1990, 1, 1), PocetDeti = 0 });


            return response;
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolekceDemo
{
    public class Osoba
    {
        private string jmeno;

        public string Jmeno
        {
            get { return jmeno; }
            set { jmeno = value; }
        }

        private string mesto;

        public string Mesto
        {
            get { return mesto; }
            set { mesto = value; }
        }

        public override string ToString()
        {
            return Jmeno + " - " + Mesto;
        }

    }
}

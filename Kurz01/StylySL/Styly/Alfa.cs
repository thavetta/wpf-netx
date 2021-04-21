using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Styly
{
    class Alfa
    {
        public void Akce(IMakej b)
        {
            b.Makej();
        }
    }

    interface IMakej
    {
        void Makej();
    }

    public class Beta : IMakej
    {
        public void Makej()
        {
            // neco
        }
    }

    class Gama : IMakej 
    {
        public void Makej()
        {
            // neco jineho
        }
    }
}

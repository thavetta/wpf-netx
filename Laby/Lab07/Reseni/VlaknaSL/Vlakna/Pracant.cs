using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vlakna
{
    class Pracant
    {
        public string DlouhaAkce(int data,IProgress<int> progress = null)
        {
            for (int i = 1; i < 11; i++)
            {
                Thread.Sleep(500);
                progress?.Report(i*10);
            }

            return "HOTOVO " + data;
        }
    }
}

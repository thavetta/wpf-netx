using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrikladPocitadlo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrikladPocitadlo.Tests
{
    [TestClass()]
    public class PocitadloTests
    {
        [TestMethod()]
        public void SectiTest()
        {
            int a = 10;
            int b = 20;
            int ocekavam = 30;
            Pocitadlo pocitadlo = new Pocitadlo();
            int vysledek = pocitadlo.Secti(a, b);
            Assert.AreEqual(ocekavam, vysledek);
        }

        [TestMethod()]
        public void OdectiTest()
        {
            int a = 10;
            int b = 20;
            int ocekavam = -11;
            Pocitadlo pocitadlo = new Pocitadlo();
            int vysledek = pocitadlo.Odecti(a, b);
            Assert.AreEqual(ocekavam, vysledek);
        }
    }
}
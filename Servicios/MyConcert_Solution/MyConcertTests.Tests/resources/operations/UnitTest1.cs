using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyConcert.resources.operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert.resources.operations.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void checkDolarsTest()
        {
            DolarStrategy dolar = new DolarStrategy();
            List<int> lista = new List<int>();
            lista.Add(20);
            lista.Add(46);
            lista.Add(20);
            lista.Add(30);

            Assert.IsFalse(dolar.checkDolars(lista));

            List<int> lista2 = new List<int>();
            lista2.Add(25);
            lista2.Add(25);
            lista2.Add(25);
            lista2.Add(25);

            Assert.IsTrue(dolar.checkDolars(lista2));
        }
    }
}
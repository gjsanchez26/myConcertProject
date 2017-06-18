using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MyConcert.resources.operations.Tests
{
    [TestClass()]
    public class DolarStrategyTest
    {
        [TestMethod()]
        public void checkDolarsTest()
        {
            //ARANGE
            DolarStrategy dolar = new DolarStrategy();
            List<int> lista = new List<int>();
            //ACT
            lista.Add(20);
            lista.Add(46);
            lista.Add(20);
            lista.Add(30);
            //ASSERT
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
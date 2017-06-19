using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyConcert.Tests
{
    [TestClass()]
    public class FacadeDBTests
    {
        FacadeDB fac = new FacadeDB();
        /**
         * Metodo de prueba de conexion con la 
         * base de datos.
         * */
        [TestMethod()]
        public void conexionBDTest()
        {
            bool flag = fac.conexionBD();
            //Assert.IsNull(flag);

        }
    }
}
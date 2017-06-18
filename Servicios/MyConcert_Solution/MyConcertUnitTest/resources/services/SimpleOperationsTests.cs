using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyConcert_WebService.resources.security.Tests
{
    /**
    * @class SimpleOperationsTests
    * @brief  Clase que maneja las pruebas unitarias respecto a la clase
    * SimpleOperations de MyConcert.  */
    [TestClass()]
    public class SimpleOperationsTests
    {
        /* Arrange */
        SimpleOperations _op = new SimpleOperations();

        /**
         * @brief Verifica si las cantidades ingresadas
         * por parametro son iguales.
         */
        [TestMethod()]
        public void isAmountItemsTest()
        {
            /* Act */
            bool x = _op.isAmountItems(10,10);

            /* Assert */
            Assert.IsTrue(x);

        }

        /**
         * @brief Verifica si las cantidades ingresadas
         * por parametro son diferentes.
         */
        [TestMethod()]
        public void isNotAmountItemsTest()
        {
            /* Act */
            bool x = _op.isAmountItems(3, 10);

            /* Assert */
            Assert.IsFalse(x);

        }


        /**
        * @brief Verifica si el valor absoluto da el 
        * resultado correcto.
        */
        [TestMethod()]
        public void double_absTest()
        {
            /* Act */
            double val_abs = _op.double_abs(-15);

            /* Assert */
            Assert.AreEqual(val_abs, 15);
        }

        /**
        * @brief Prueba si el valor absoluto da el 
        * resultado incorrecto.
        */
        [TestMethod()]
        public void double_absErrorTest()
        {
            /* Act */
            double val_abs = _op.double_abs(-35.9);

            /* Assert */
            Assert.AreNotEqual(val_abs, -35.9);
        }
    }
}
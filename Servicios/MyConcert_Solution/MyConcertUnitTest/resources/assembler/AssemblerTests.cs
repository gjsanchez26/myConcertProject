using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyConcert.resources.assembler;
using MyConcert.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert.resources.assembler.Tests
{
    /**
    * @class SerialHelperTests
    * @brief  Clase que maneja las pruebas unitarias respecto a la clase
    * AssemblerTests de MyConcert.  */
    [TestClass()]
    public class AssemblerTests
    {
        Assembler _assembler = new Assembler();
        /**
         * @brief Verifica si crea objetos integrantes con los nombres 
         * insertados en la lista parámetro.
         */
        [TestMethod()]
        public void updateintegrantesTest()
        {
            /* Arrange */
            string[] integrantes = {"Javier","Fabian","Gabriel","Ernesto"};

            /* Act */
            List<integrantes> resp = _assembler.updateintegrantes(integrantes);

            /* Assert */
            Assert.AreEqual(integrantes[0], resp[0].nombreInt);
            Assert.AreEqual(integrantes[1], resp[1].nombreInt);
            Assert.AreEqual(integrantes[2], resp[2].nombreInt);
            Assert.AreEqual(integrantes[3], resp[3].nombreInt);
        }

        

        /**
         * @brief Verifica si crea objetos canciones con los nombres 
         * insertados en la lista parámetro.
         */
        [TestMethod()]
        public void updatecancionesTest()
        {
            /* Arrange */
            string[] canciones = { "DNA.", "HUMBLE."};

            /* Act */
            List<canciones> resp = _assembler.updatecanciones(canciones);

            /* Assert */
            Assert.AreEqual(canciones[0], resp[0].cancion);
            Assert.AreEqual(canciones[1], resp[1].cancion);
        }

    }
}
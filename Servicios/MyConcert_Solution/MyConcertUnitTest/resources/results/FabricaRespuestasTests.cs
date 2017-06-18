using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;

namespace MyConcert.resources.results.Tests
{
    /**
    * @class FabricaRespuestasTests
    * @brief  Clase que maneja las pruebas unitarias respecto a la clase
    * FabricaRespuestas de MyConcert.  */
    [TestClass()]
    public class FabricaRespuestasTests
    {
        FabricaRespuestas _fac = new FabricaRespuestas();

        /**
         * @brief Verifica las entradas de la fabrica de respuestas
         * */
        [TestMethod()]
        public void crearRespuestaObjetoTest()
        {
            /* Arrange */
            JObject obj = new JObject();            

            /* Act */
            Respuesta resp = _fac.crearRespuesta(true, obj);

            /* Assert */
            Assert.IsInstanceOfType(resp, typeof(ResultadoObjeto));

        }

        /**
         * @brief Verifica las entradas de la fabrica de respuestas
         * */
        [TestMethod()]
        public void crearRespuestaStringTest()
        {
            /* Arrange */
            string msg = "My concert";

            /* Act */
            Respuesta resp = _fac.crearRespuesta(true, msg);

            /* Assert */
            Assert.IsInstanceOfType(resp, typeof(ResultadoString));

        }

        /**
         * @brief Verifica las entradas de la fabrica de respuestas
         * */
        [TestMethod()]
        public void crearRespuestaArregloTest()
        {
            /* Arrange */
            JObject obj1 = new JObject();
            JObject obj2 = new JObject();
            JObject obj3 = new JObject();
            JObject[] _arr = {obj1,obj2,obj3};

            /* Act */
            Respuesta resp = _fac.crearRespuesta(true, _arr);

            /* Assert */
            Assert.IsInstanceOfType(resp, typeof(ResultadoArreglo));

        }

        /**
         * @brief Verifica las entradas de la fabrica de respuestas
         * */
        [TestMethod()]
        public void crearRespuestaDetalleTest()
        {
            /* Arrange */
            string contenido = "a";
            string detail = "b";

            /* Act */
            Respuesta resp = _fac.crearRespuesta(true, contenido, detail);

            /* Assert */
            Assert.IsInstanceOfType(resp, typeof(ResultadoDetalle));

        }

        /**
         * @brief Verifica las entradas de la fabrica de respuestas
         * */
        [TestMethod()]
        public void crearRespuestaUsuarioTest()
        {
            /* Arrange */
            JObject obj = new JObject();
            JObject[] x = {obj };

            /* Act */
            Respuesta resp = _fac.crearRespuesta(true, obj, x);

            /* Assert */
            Assert.IsInstanceOfType(resp, typeof(ResultadoUsuario));

        }

        /**
         * @brief Verifica las entradas de la fabrica de respuestas
         * */
        [TestMethod()]
        public void crearRespuestaBandaTest()
        {
            /* Arrange */
            JObject obj = new JObject();
            JObject[] x = { obj };
            JObject[] y = { obj };

            /* Act */
            Respuesta resp = _fac.crearRespuesta(true, obj, x, y, x, y);

            /* Assert */
            Assert.IsInstanceOfType(resp, typeof(ResultadoBanda));

        }

        /**
         * @brief Verifica las entradas de la fabrica de respuestas
         * */
        [TestMethod()]
        public void crearRespuestaEventoTest()
        {
            /* Arrange */
            JObject obj = new JObject();
            JObject[] x = { obj };

            /* Act */
            Respuesta resp = _fac.crearRespuesta(true, x, obj);

            /* Assert */
            Assert.IsInstanceOfType(resp, typeof(ResultadoEvento));

        }
    }
}
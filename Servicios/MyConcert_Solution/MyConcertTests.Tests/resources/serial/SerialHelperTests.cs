﻿using MyConcert.resources.serial;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using MyConcert.viewModels;

namespace MyConcert.resources.serial.Tests
{
    /**
    * @class SerialHelperTests
    * @brief  Clase que maneja las pruebas unitarias respecto a la clase
    * SerialHelper de MyConcert.  */
    [TestClass()]
    public class SerialHelperTests
    {
        private SerialHelper _help = new SerialHelper();

        /**
         * @brief Verifica si el JSON se convirtió en arreglo con 
         * los mismos valores int.
         */
        [TestMethod()]
        public void getArrayIntTest()
        {
            /* Arrange */
            string x = @"[1,2,3]";

            /* Act */
            JArray _arr = JArray.Parse(x);
            int[] _test = _help.getArrayInt(_arr);

            /* Assert */
            Assert.AreEqual(_test[0], _arr[0]);
            Assert.AreEqual(_test[1], _arr[1]);
            Assert.AreEqual(_test[2], _arr[2]);
        }

        /**
         * @brief Verifica si el JSON se convirtió en arreglo con 
         * los mismos valores string.
         */
        [TestMethod()]
        public void getArrayStringTest()
        {
            /* Arrange */
            string x = @"['Goku','Vegeta','Trunks','Piccoro']";

            /* Act */
            JArray _arr = JArray.Parse(x);
            string[] _test = _help.getArrayString(_arr);

            /* Assert */
            Assert.AreEqual(_test[0], _arr[0]);
            Assert.AreEqual(_test[1], _arr[1]);
            Assert.AreEqual(_test[2], _arr[2]);
            Assert.AreEqual(_test[3], _arr[3]);
        }

        /**
         * @brief Verifica si los generos musicales se 
         * convierten en un objeto JSON dentro de un JSON
         */
        [TestMethod()]
        public void agruparGenerosTest()
        {
            /* Arrange */
            GeneroMusical g1 = new GeneroMusical(1, "Progressive Rock");
            GeneroMusical g2 = new GeneroMusical(2, "Reggae Roots");
            GeneroMusical[] _gens = { g1, g2 };

            /* Act */
            JObject[] _objs = _help.agruparGeneros(_gens);
            int id1 = (int)_objs[0]["Id"];
            int id2 = (int)_objs[1]["Id"];

            /* Assert */
            Assert.AreEqual(id1, g1.Id);
            Assert.AreEqual(id2, g2.Id);

        }

        [TestMethod()]
        public void parseFechaTest()
        {
            
        }

        /**
         * @brief Verifica si los generos musicales se 
         * convierten en un objeto JSON dentro de un JSON
         */

    }
}
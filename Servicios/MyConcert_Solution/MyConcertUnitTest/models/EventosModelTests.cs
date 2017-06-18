using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyConcert.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert.models.Tests
{
    [TestClass()]
    public class EventosModelTests
    {
        private EventosModel _model = new EventosModel();

        [TestMethod()]
        public void existeEnListaTest()
        {
            List<categorias> lista = new List<categorias>();
            categorias categoria1 = new categorias();
            categorias categoria2 = new categorias();
            categorias categoria3 = new categorias();
            categoria1.PK_categorias = 1;
            categoria2.PK_categorias = 2;
            categoria3.PK_categorias = 3;
            categoria1.categoria = "Nacionales";
            categoria2.categoria = "Bailables";
            categoria3.categoria = "Teloneros";
            lista.Add(categoria1);
            lista.Add(categoria2);
            lista.Add(categoria3);

            categorias categoriaPrueba = new categorias();
            categoriaPrueba.PK_categorias = 1;
            categoriaPrueba.categoria = "Nacionales";


            bool estadoOperacion = _model.existeEnLista(lista, categoriaPrueba);

            Assert.IsTrue(estadoOperacion);
        }

        [TestMethod()]
        public void generarCategoriasTest()
        {
            List<categorias> lista = new List<categorias>();
            categorias categoria1 = new categorias();
            categorias categoria2 = new categorias();
            categorias categoria3 = new categorias();
            categoria1.PK_categorias = 1;
            categoria2.PK_categorias = 2;
            categoria3.PK_categorias = 3;
            categoria1.categoria = "Nacionales";
            categoria2.categoria = "Bailables";
            categoria3.categoria = "Nacionales";
            lista.Add(categoria1);
            lista.Add(categoria2);
            lista.Add(categoria3);

            List<categorias> listaComprobar = new List<categorias>();
            categorias categoria4 = new categorias();
            categorias categoria5 = new categorias();
            categoria4.PK_categorias = 4;
            categoria5.PK_categorias = 5;
            categoria4.categoria = "Nacionales";
            categoria5.categoria = "Bailables";
            listaComprobar.Add(categoria4);
            listaComprobar.Add(categoria5);

            List<categorias> listaRespuesta = _model.generarCategorias(lista);
            foreach (categorias cat in listaComprobar)
            {
                foreach (categorias cat2 in listaRespuesta)
                {
                    StringAssert.Equals(cat.categoria, cat2.categoria);
                }
            }
        }

        [TestMethod()]
        public void bandasToStringTest()
        {
            List<bandas> lista = new List<bandas>();
            bandas banda1 = new bandas();
            bandas banda2 = new bandas();
            banda1.nombreBan = "Romare";
            banda2.nombreBan = "Nicolas Jaar";
            lista.Add(banda1);
            lista.Add(banda2);
            bandas[] arrayBanda = lista.ToArray();

            List<string> listaRespuesta = _model.bandasToString(lista);
            string[] arrayString = listaRespuesta.ToArray();

            for (int i = 0; i < arrayBanda.Length; i++)
            {
                StringAssert.Equals(arrayBanda[i], arrayString[i]);
            }
        }

        [TestMethod()]
        public void extraerBandasNoSeleccionadasTest()
        {
            List<bandas> listaTotal = new List<bandas>();
            bandas banda1 = new bandas();
            bandas banda2 = new bandas();
            banda1.nombreBan = "Romare";
            banda2.nombreBan = "Nicolas Jaar";
            listaTotal.Add(banda1);
            listaTotal.Add(banda2);

            List<bandas> listaGanadores = new List<bandas>();
            bandas banda3 = new bandas();
            banda3.nombreBan = "Romare";
            listaGanadores.Add(banda3);

            List<bandas> listaPerdedores = _model.extraerBandasNoSeleccionadas(listaGanadores, listaTotal);
            
            Assert.AreEqual(listaPerdedores[0].nombreBan, banda2.nombreBan);
        }
    }
}
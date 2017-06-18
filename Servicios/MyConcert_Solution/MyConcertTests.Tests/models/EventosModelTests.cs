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
            categoria3.PK_categorias = 1;
            categoria1.categoria = "Nacionales";
            categoria2.categoria = "Bailables";
            categoria3.categoria = "Nacionales";
            lista.Add(categoria1);
            lista.Add(categoria2);
            lista.Add(categoria3);

            List<categorias> listaComprobar = new List<categorias>();
            categorias categoria4 = new categorias();
            categorias categoria5 = new categorias();
            categoria4.PK_categorias = 1;
            categoria5.PK_categorias = 2;
            categoria4.categoria = "Nacionales";
            categoria5.categoria = "Bailables";
            listaComprobar.Add(categoria4);
            listaComprobar.Add(categoria5);

            List<categorias> listaRespuesta = _model.generarCategorias(lista);

            Assert.AreEqual<List<categorias>>(listaComprobar, listaRespuesta);
        }
    }
}
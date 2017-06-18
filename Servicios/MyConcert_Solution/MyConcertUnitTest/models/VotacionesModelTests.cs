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
    public class VotacionesModelTests
    {
        private VotacionesModel _model = new VotacionesModel();

        [TestMethod()]
        public void mapearVotacionesPorCategoriaTest()
        {
            List<votos> votaciones = new List<votos>();
            votos voto1 = new votos();
            voto1.FK_VOTOS_CATEGORIAS = 1;
            votaciones.Add(voto1);
            votos voto2 = new votos();
            voto2.FK_VOTOS_CATEGORIAS = 2;
            votaciones.Add(voto2);
            votos voto3 = new votos();
            voto3.FK_VOTOS_CATEGORIAS = 1;
            votaciones.Add(voto3);
            votos voto4 = new votos();
            voto4.FK_VOTOS_CATEGORIAS = 3;
            votaciones.Add(voto4);
            votos voto5 = new votos();
            voto5.FK_VOTOS_CATEGORIAS = 1;
            votaciones.Add(voto5);

            List<List<votos>> matrizVotos = _model.mapearVotacionesPorCategoria(votaciones);

            List<List<votos>> matrizVotosEsperada = new List<List<votos>>();
            List<votos> listaCat1 = new List<votos>();
            listaCat1.Add(voto1);
            listaCat1.Add(voto3);
            listaCat1.Add(voto5);
            List<votos> listaCat2 = new List<votos>();
            listaCat2.Add(voto2);
            List<votos> listaCat3 = new List<votos>();
            listaCat3.Add(voto4);

            matrizVotosEsperada.Add(listaCat1);
            matrizVotosEsperada.Add(listaCat2);
            matrizVotosEsperada.Add(listaCat3);

            Assert.AreEqual(matrizVotosEsperada, matrizVotos);
        }
    }
}
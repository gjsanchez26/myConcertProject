using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyConcert.resources.services;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace MyConcert.models.Tests
{
    [TestClass()]
    public class BandaModelTests
    {
        [TestMethod()]
        public void agruparCancionesTest()
        {
            // arange
            BandaModel _model = new BandaModel();
            SpotifyUtils _spotify = new SpotifyUtils();
            List<canciones> lista = new List<canciones>();
            canciones cancion1 = new canciones();
            canciones cancion2 = new canciones();
            canciones cancion3 = new canciones();
            cancion1.cancion = "Rainbow";
            cancion2.cancion = "All Night";
            cancion3.cancion = "Motherless Child";
            lista.Add(cancion1);
            lista.Add(cancion2);
            lista.Add(cancion3);
            string artista = "Romare";

            JObject[] esperado = new JObject[3];
            dynamic song1 = new JObject();
            dynamic song2 = new JObject();
            dynamic song3 = new JObject();
            song1.song_name = "Rainbow";
            song2.song_name = "All Night";
            song3.song_name = "Motherless Child";
            song1.url_sound_test = _spotify.searchURLTrack("Rainbow", artista);
            song1.url_sound_test = _spotify.searchURLTrack("All Night", artista);
            song1.url_sound_test = _spotify.searchURLTrack("Motherless Child", artista);
            esperado[0] = song1;
            esperado[1] = song2;
            esperado[2] = song3;
            // act
            JObject[] respuesta = _model.agruparCanciones(lista, artista);

            // assert
            Assert.AreSame(esperado, respuesta);
        }
    }
}
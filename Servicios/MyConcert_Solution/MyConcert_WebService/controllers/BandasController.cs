using MyConcert_WebService.models;
using MyConcert_WebService.res.resultados;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert_WebService.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BandasController : ApiController
    {
        private BandaModel _model = new BandaModel();

        //Obtener todas las bandas disponibles.
        public JObject Get()
        {
            Respuesta respuesta = null;

            respuesta = _model.getCatalogoBandas();
            
            return JObject.FromObject(respuesta);
        }

        //Obtener banda especifica.
        public JObject Get(int id)
        {
            Respuesta respuesta = null;

            respuesta = _model.getBanda(id);

            return JObject.FromObject(respuesta);
        }

        //Crear banda nueva.    
        public JObject Post(JObject pPeticion)
        {
            dynamic peticion = pPeticion;
            string datosBanda = (string) peticion.band_data;
            JArray listaMiembros = (JArray) peticion.members;
            JArray listaCanciones = (JArray) peticion.songs;
            JArray listaGenerosMusicales = (JArray) peticion.genres;

            Respuesta respuesta = new Respuesta();

            respuesta = _model.nuevaBanda(datosBanda, listaMiembros, listaCanciones, listaGenerosMusicales);

            return JObject.FromObject(respuesta);
        }
    }
}

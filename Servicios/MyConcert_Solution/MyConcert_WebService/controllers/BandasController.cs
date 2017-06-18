using MyConcert.models;
using MyConcert.resources.results;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert.controllers
{
    /**
     * Bandas Controller
     * */
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

        public JObject Get(string name)
        {
            Respuesta respuesta = null;

            respuesta = _model.getBandaPorNombre(name);

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

            Respuesta respuesta = null;

            respuesta = _model.nuevaBanda(datosBanda, listaMiembros, listaCanciones, listaGenerosMusicales);

            return JObject.FromObject(respuesta);
        }

        //Crear nuevo comentario para banda
        public JObject Put(JObject pPeticion)
        {
            Respuesta respuesta = null;
            
            dynamic peticion = pPeticion;
            int idBand = peticion.band;
            string user = peticion.user;
            string comment = peticion.comment;
            float calification = peticion.calification;

            respuesta = _model.generarComentario(idBand, user, comment, calification);

            return JObject.FromObject(respuesta);
        }
    }
}

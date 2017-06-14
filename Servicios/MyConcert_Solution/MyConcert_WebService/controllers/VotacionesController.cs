using MyConcert_WebService.models;
using MyConcert_WebService.res.resultados;
using Newtonsoft.Json.Linq;
using System.Web.Http.Cors;

namespace MyConcert_WebService.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VotacionesController
    {
        private VotacionesModel _model = new VotacionesModel();

        //Crear votacion nueva. 
        public JObject Post(JObject pPeticion)
        {
            dynamic peticion = pPeticion;
            int eventoID = (int) peticion.event_id;
            string usuario = (string) peticion.user;
            JArray categorias = (JArray) peticion.categories; 

            Respuesta respuesta = _model.nuevaVotacion(eventoID, usuario, categorias);

            return JObject.FromObject(respuesta); 
        }
    }
}

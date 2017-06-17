using MyConcert.models;
using MyConcert.resources.results;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VotacionesController : ApiController
    {
        private VotacionesModel _model = new VotacionesModel();

        //Crear votacion nueva. 
        public JObject Post(JArray pPeticion)
        {
            dynamic peticion = pPeticion;
            JArray categorias = (JArray) peticion; 

            Respuesta respuesta = _model.nuevaVotacion(categorias);

            return JObject.FromObject(respuesta); 
        }
    }
}

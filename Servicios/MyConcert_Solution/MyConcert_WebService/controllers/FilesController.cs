using MyConcert.resources.results;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FilesController : ApiController
    {
        public Respuesta Post(JObject pPeticion)
        {
            dynamic peticion = pPeticion;

            return null;
        } 
    }
}

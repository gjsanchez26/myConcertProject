using MyConcert_WebService.res.resultados;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert_WebService.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FilesController : ApiController
    {
        public Respuesta Post(JObject pPeticion)
        {
            dynamic peticion = pPeticion;

            return new Respuesta();
        } 
    }
}

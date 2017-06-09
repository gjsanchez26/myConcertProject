using MyConcert_WebService.models;
using MyConcert_WebService.res.resultados;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert_WebService.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        private UsuariosModel _model = new UsuariosModel();

        public JObject Post(JObject pPeticion)
        {
            dynamic peticion = pPeticion;
            string pNombreUsuario = peticion.username;
            string pPassword = peticion.password;

            Respuesta respuesta = _model.comprobarInicioSesion(pNombreUsuario, pPassword);
            JObject respuestaPost = JObject.FromObject(respuesta);

            return respuestaPost;
        }
    }
}

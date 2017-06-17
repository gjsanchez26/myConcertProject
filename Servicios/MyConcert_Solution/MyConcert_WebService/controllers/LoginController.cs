using MyConcert.models;
using MyConcert.resources.results;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert.controllers
{
    /**
     * Login controller
     * */
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        private UsuariosModel _model = new UsuariosModel();

        //Inicio de sesion en el sistema
        public JObject Post(JObject pPeticion)
        {
            dynamic peticion = pPeticion;
            string pNombreUsuario = peticion.username;
            string pPassword = peticion.password;

            //Pasa responsabilidad al model usuario
            Respuesta respuesta = _model.comprobarInicioSesion(pNombreUsuario, pPassword);
            JObject respuestaPost = JObject.FromObject(respuesta);

            return respuestaPost;
        }
    }
}

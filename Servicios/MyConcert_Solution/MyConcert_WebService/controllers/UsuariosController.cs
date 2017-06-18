using MyConcert.models;
using MyConcert.resources.results;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert.controllers
{
    /**
     * Usuarios Controller
     * */
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuariosController : ApiController
    {
        //Model para administrar datos
        private UsuariosModel _model = new UsuariosModel();

        //Obtener usuario especifico.
        public JObject Get(string username)
        {
            Respuesta respuesta = _model.getUsuario(username);

            return JObject.FromObject(respuesta);
        }

        //Crear usuario nuevo.
        public JObject Post(JObject pDatosUsuario)
        {
            dynamic peticion = pDatosUsuario;
            string tipoUsuario = peticion.role;
            dynamic datosUsuario = peticion.user_data;
            JArray listaGenerosFavoritos = peticion.genres;
            
            //Otorga responsabilidad al Model
            Respuesta respuesta = _model.registrarUsuario(tipoUsuario, datosUsuario, listaGenerosFavoritos);
            
            JObject respuestaPost = JObject.FromObject(respuesta);

            return respuestaPost;
        }

        //Modificar usuario específico
        public JObject Put(JObject pPeticion)
        {
            dynamic peticion = pPeticion;
            string tipoUsuario = peticion.role;
            dynamic datosUsuario = peticion.user_data;
            JArray listaGenerosFavoritos = peticion.genres;

            //Ortorga responsabilidad al Model
            Respuesta respuesta = _model.modificarUsuario(tipoUsuario, datosUsuario, listaGenerosFavoritos);

            return JObject.FromObject(respuesta);
        }
    }
}

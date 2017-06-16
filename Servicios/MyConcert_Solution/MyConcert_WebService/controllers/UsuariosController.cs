using MyConcert.models;
using MyConcert.res.resultados;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuariosController : ApiController
    {
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
            
            Respuesta respuesta = _model.registrarUsuario(tipoUsuario, datosUsuario, listaGenerosFavoritos);
            
            JObject respuestaPost = JObject.FromObject(respuesta);

            return respuestaPost;
        }
    }
}

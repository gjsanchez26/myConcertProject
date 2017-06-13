using MyConcert_WebService.models;
using MyConcert_WebService.res.resultados;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert_WebService.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuariosController : ApiController
    {
        private UsuariosModel _model = new UsuariosModel();

        //Obtener usuario especifico.
        public JObject Get(JObject pNombreUsuario)
        {
            dynamic peticion = pNombreUsuario;
            string nombreUsuario = peticion.username;

            return new JObject();
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

        private int[] getGenerosFavoritos(JArray pGenerosFavoritos)
        {
            dynamic generosFavoritos = pGenerosFavoritos;
            int[] lista = new int[pGenerosFavoritos.Count];
            int iterator = 0;

            foreach (dynamic i in generosFavoritos)
            {
                lista[iterator] = i;
                iterator++;
            }

            return lista;
        }

        //Actualiza usuario especifico.
        public JObject Put(JObject pDatosUsuario)
        {
            dynamic peticion = pDatosUsuario;
            ResultadoObjeto respuesta = new ResultadoObjeto();

            //Actualiza usuario en base de datos.
            return JObject.FromObject(respuesta); //Retorna estado de modificacion.
        }

        //Elimina usuario especifico.
        public JObject Delete(string pNombreUsuario)
        {
            ResultadoObjeto respuesta = new ResultadoObjeto();

            //Elimina usuario de base de datos.
            return JObject.FromObject(respuesta); //Retorna estado de eliminacion.
        }
    }
}

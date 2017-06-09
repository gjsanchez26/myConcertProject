using MyConcert_WebService.models;
using MyConcert_WebService.res;
using MyConcert_WebService.res.resultados;
using MyConcert_WebService.res.usr;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;

namespace MyConcert_WebService.controllers
{
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
            
            Respuesta respuesta = _model.registrarUsuario(tipoUsuario, datosUsuario);
            
            JObject respuestaPost = JObject.FromObject(respuesta);

            return respuestaPost;

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

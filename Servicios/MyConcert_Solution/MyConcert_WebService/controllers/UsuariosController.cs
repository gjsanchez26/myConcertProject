using MyConcert_WebService.res;
using MyConcert_WebService.res.usr;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;

namespace MyConcert_WebService.controllers
{
    public class UsuariosController : ApiController
    {
        //Obtener usuario especifico.
        public JObject Get(string pNombreUsuario)
        {
            Resultado respuesta = new Resultado();

            //Obtiene usuario de base de datos.
            return JObject.FromObject(respuesta); //Retorna objeto usuario.
        }

        //Crear usuario nuevo.
        public JObject Post(JObject pRequest)
        {
            dynamic request = pRequest;

            try
            {
                Usuario nuevoUsuario = request.user;
                bool response = true;
                return JObject.FromObject(response);
            } catch(Exception e) {
                string error = e.Message;
                return JObject.FromObject(error);
            }
        }

        //Actualiza usuario especifico.
        public JObject Put(JObject pPeticion)
        {
            dynamic peticion = pPeticion;
            Resultado respuesta = new Resultado();

            //Actualiza usuario en base de datos.
            return JObject.FromObject(respuesta); //Retorna estado de modificacion.
        }

        //Elimina usuario especifico.
        public JObject Delete(string pNombreUsuario)
        {
            Resultado respuesta = new Resultado();

            //Elimina usuario de base de datos.
            return JObject.FromObject(respuesta); //Retorna estado de eliminacion.
        }
    }
}

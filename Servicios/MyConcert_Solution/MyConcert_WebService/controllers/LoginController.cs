using MyConcert_WebService.res;
using MyConcert_WebService.res.usr;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert_WebService.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        public JObject Post(JObject pPeticion)
        {
            dynamic peticion = pPeticion;
            string pNombreUsuario = peticion.username;
            string pPassword = peticion.password;

            Resultado respuesta = new Resultado();

            //Mapea el nombre de usuario ingresado a un usuario del sistema.
            //pNombreUsuario
            Usuario usuarioActual = new Usuario();
            // --- Mapeo.

            string error;
            if (usuarioActual == null)                                  //Si no existe el nombre de usuario introducido.
            {
                respuesta.exito = false;
                error = "Usuario no existente.";
                respuesta.mensajeError = JObject.FromObject(error);
            } else
            {
                if (usuarioActual.Contrasena != pPassword)              //Si la contrasena es incorrecta.
                {
                    respuesta.exito = false;
                    error = "Contrasena incorrecta.";
                    respuesta.mensajeError = JObject.FromObject(error);
                } else                                                  //Si el usuario y contrasena son validos.
                {
                    respuesta.exito = true;
                    respuesta.mensajeError = JObject.FromObject(usuarioActual);
                }
            }

            return JObject.FromObject(respuesta);
        }
    }
}

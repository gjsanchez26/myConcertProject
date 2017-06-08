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
        UsuariosModel _model = new UsuariosModel();

        public JObject Post(JObject pPeticion)
        {
            dynamic peticion = pPeticion;
            string pNombreUsuario = peticion.username;
            string pPassword = peticion.password;

            FabricaRespuestas creador = new FabricaRespuestas();
            Respuesta respuesta;

            //Mapea el nombre de usuario ingresado a un usuario del sistema.
            //pNombreUsuario
            usuarios usuarioActual = _model.getUsuarioPorNombreDeUsuario(pNombreUsuario);
            // --- Mapeo.
            
            if (usuarioActual == null)                                  //Si no existe el nombre de usuario introducido.
            {
                respuesta = creador.crearRespuesta(false, "Usuario no existente.");
            }
            else
            {
                if (usuarioActual.contraseña != pPassword)              //Si la contrasena es incorrecta.
                {
                    respuesta = creador.crearRespuesta(false, "Usuario no existente.");
                }
                else                                                  //Si el usuario y contrasena son validos.
                {
                    respuesta = creador.crearRespuesta(false, JObject.FromObject(usuarioActual));
                }
            }

            return JObject.FromObject(respuesta);
        }
    }
}

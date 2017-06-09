using MyConcert_WebService.res.resultados;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.models
{
    public class UsuariosModel
    {
        private ManejadorBD _manejador;
        private FabricaRespuestas creador = new FabricaRespuestas();
        private Respuesta respuesta;

        public UsuariosModel()
        {
            _manejador = new ManejadorBD();
        }

        public Respuesta comprobarInicioSesion(string pUsername, string pPassword)
        {
            usuarios usuarioActual;
            try
            {
                usuarioActual = getUsuarioPorNombreDeUsuario(pUsername);
            } catch(Exception e)
            {
                return respuesta = creador.crearRespuesta(false, "Error en conexión con el servidor. Intente de nuevo.");
            }
            

            if (usuarioActual == null)                                  //Si no existe el nombre de usuario introducido.
            {
                respuesta = creador.crearRespuesta(false, "Usuario no existente.");
            }
            else
            {
                if (usuarioActual.contraseña != pPassword)              //Si la contrasena es incorrecta.
                {
                    respuesta = creador.crearRespuesta(false, "Contraseña incorrecta. Intente de nuevo.");
                }
                else                                                  //Si el usuario y contrasena son validos.
                {
                    respuesta = creador.crearRespuesta(false, JObject.FromObject(usuarioActual));
                }
            }

            return respuesta;
        }

        private usuarios getUsuarioPorNombreDeUsuario(string pUsuario)
        {
            usuarios user = null;
            try
            {
                user = _manejador.obtenerUsuario(pUsuario);
                return user;
            } catch(Exception e)
            {
                throw(e);
            }
            
        }
    }
}

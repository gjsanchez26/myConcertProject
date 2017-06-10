using MyConcert_WebService.objects;
using MyConcert_WebService.res;
using MyConcert_WebService.res.resultados;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
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
                usuarioActual = _manejador.obtenerUsuario(pUsername);
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

        public Respuesta registrarUsuario(string pRol, JObject pDatosUsuario)
        {
            SerializerJSON serial = new SerializerJSON();
            try
            {
                Usuario nuevoUsuario = serial.leerDatosUsuario(pRol, pDatosUsuario);

                _manejador.añadirUsuario(nuevoUsuario, ); //Se almacena el nuevo usuario
            }
            catch (Exception e)
            {
                respuesta = creador.crearRespuesta(false, e.ToString());
            }

            return respuesta;
        }

        private bool comprobarInputNuevoUsuario(JObject pDatosUsuario)
        {
            string esquemaNuevoUsuario = @"{
	                                        'description':'usuarios',
	                                        'type':'object',
	                                        'properties':
	                                        {
		                                        'name':{'type':'string'},
		                                        'last_name':{'type':'string'},
		                                        'username':{'type':'string'},
		                                        'password':{'type':'string'},
		                                        'email':{'type':'string'},
		                                        'state':{'type':'int'},
		                                        'registration_date':{'type':'string'},
		                                        'profile_pic':{'type':'string'},
		                                        'bith_date':{'type':'string'},
		                                        'phone':{'type':'string'},
		                                        'country':{'type':'int'},
		                                        'ubication':{'type':'string'},
		                                        'university':{'type':'int'},
		                                        'description':{'type':'string'}
	                                        }
                                           }";
#pragma warning disable CS0618 // Type or member is obsolete
            JsonSchema esquema = JsonSchema.Parse(esquemaNuevoUsuario);
            return pDatosUsuario.IsValid(esquema);
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}

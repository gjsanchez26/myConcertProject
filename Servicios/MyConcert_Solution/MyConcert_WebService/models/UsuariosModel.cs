using MyConcert_WebService.viewModels;
using MyConcert_WebService.res.resultados;
using MyConcert_WebService.res.serial;
using MyConcert_WebService.security;
using Newtonsoft.Json.Linq;
using System;
using MyConcert_WebService.res.assembler;

namespace MyConcert_WebService.models
{
    public class UsuariosModel
    {
        private Assembler _assembler = new Assembler();
        private ManejadorBD _manejador = new ManejadorBD();
        private FabricaRespuestas creador = new FabricaRespuestas();
        private Respuesta respuesta = null;
        private SHA256Encriptation _encriptador = new SHA256Encriptation();
        
        public Respuesta comprobarInicioSesion(string pUsername, string pPassword)
        {
            usuarios usuarioActual;
            string passwordEncriptado = _encriptador.sha256Encrypt(pPassword);

            try
            {
                usuarioActual = _manejador.obtenerUsuario(pUsername);
            }
            catch (Exception e)
            {
                return respuesta = creador.crearRespuesta(false, "Usuario incorrecto o no existente. Por favor intente de nuevo.");
                throw (e);
            }


            if (usuarioActual == null)                                  //Si no existe el nombre de usuario introducido.
            {
                respuesta = creador.crearRespuesta(false, "Usuario no existente.");
            }
            else
            {
                if (usuarioActual.contraseña != passwordEncriptado)              //Si la contrasena es incorrecta.
                {
                    respuesta = creador.crearRespuesta(false, "Contraseña incorrecta. Intente de nuevo.");
                }
                else                                                  //Si el usuario y contrasena son validos.
                {
                    Usuario usuarioViewModel = _assembler.createUsuario(usuarioActual);
                    respuesta = creador.crearRespuesta(true, JObject.FromObject(usuarioViewModel));
                }
            }

            return respuesta;
        }

        public Respuesta registrarUsuario(string pRol, JObject pDatosUsuario, int[] pListaGeneroFavoritos)
        {
            SerializerJSON serial = new SerializerJSON();
            try
            {
                Usuario nuevoUsuario = serial.leerDatosUsuario(pRol, pDatosUsuario);

                //if (pRol == "fanatico")
                //    _manejador.añadirUsuario(nuevoUsuario, pListaGeneroFavoritos); //Se almacena el nuevo usuario
                //else
                //    _manejador.añadirUsuario(nuevoUsuario); //Se almacena el nuevo usuario

                respuesta = creador.crearRespuesta(true, "Usuario creado exitosamente.");
            }
            catch (Exception )
            {
                respuesta = creador.crearRespuesta(false, "Usuario ya existente. Intentar de nuevo.");
            }

            return respuesta;
        }
    }
}

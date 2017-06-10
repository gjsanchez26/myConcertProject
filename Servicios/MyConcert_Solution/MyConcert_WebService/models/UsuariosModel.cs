using MyConcert_WebService.database;
using MyConcert_WebService.objects;
using MyConcert_WebService.res;
using MyConcert_WebService.res.resultados;
using MyConcert_WebService.security;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;

namespace MyConcert_WebService.models
{
    public class UsuariosModel
    {
        private UsuariosDB _usuariosDB;
        private FabricaRespuestas creador = new FabricaRespuestas();
        private Respuesta respuesta;
        private SHA256Encriptation _encriptador;

        public UsuariosModel()
        {
            _usuariosDB = new UsuariosDB();
            _encriptador = new SHA256Encriptation();
        }

        public Respuesta comprobarInicioSesion(string pUsername, string pPassword)
        {
            Usuario usuarioActual;
            string passwordEncriptado = _encriptador.sha256Encrypt(pPassword);
            try
            {
                usuarioActual = _usuariosDB.obtenerUsuario(pUsername);
            }
            catch (Exception e)
            {
                return respuesta = creador.crearRespuesta(false, e.ToString());
            }


            if (usuarioActual == null)                                  //Si no existe el nombre de usuario introducido.
            {
                respuesta = creador.crearRespuesta(false, "Usuario no existente.");
            }
            else
            {
                if (usuarioActual.Contrasena != passwordEncriptado)              //Si la contrasena es incorrecta.
                {
                    respuesta = creador.crearRespuesta(false, "Contraseña incorrecta. Intente de nuevo.");
                }
                else                                                  //Si el usuario y contrasena son validos.
                {

                    respuesta = creador.crearRespuesta(true, JObject.FromObject(usuarioActual));
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

                if (pRol == "fanatico")
                    _usuariosDB.añadirUsuario(nuevoUsuario, pListaGeneroFavoritos); //Se almacena el nuevo usuario
                else
                    _usuariosDB.añadirUsuario(nuevoUsuario); //Se almacena el nuevo usuario

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

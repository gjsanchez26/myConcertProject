using MyConcert_WebService.viewModels;
using MyConcert_WebService.res.resultados;
using MyConcert_WebService.security;
using Newtonsoft.Json.Linq;
using System;
using MyConcert_WebService.res.assembler;
using MyConcert_WebService.res.serial;
using System.Collections.Generic;

namespace MyConcert_WebService.models
{
    public class UsuariosModel
    {
        private Assembler _assembler = new Assembler();
        private ManejadorBD _manejador = new ManejadorBD();
        private FabricaRespuestas _creador = new FabricaRespuestas();
        private SHA256Encriptation _encriptador = new SHA256Encriptation();
        private SerialHelper _serial = new SerialHelper();
        
        public Respuesta comprobarInicioSesion(string pUsername, string pPassword)
        {
            Respuesta respuesta = null;
            usuarios usuarioActual;
            string passwordEncriptado = _encriptador.sha256Encrypt(pPassword);

            try
            {
                usuarioActual = _manejador.obtenerUsuario(pUsername);
            }
            catch (Exception e)
            {
                return respuesta = _creador.crearRespuesta(false, "Usuario incorrecto o no existente. Por favor intente de nuevo.");
                throw (e);
            }


            if (usuarioActual == null)                                  //Si no existe el nombre de usuario introducido.
            {
                respuesta = _creador.crearRespuesta(false, "Usuario no existente.");
            }
            else
            {
                if (usuarioActual.contraseña != passwordEncriptado)              //Si la contrasena es incorrecta.
                {
                    respuesta = _creador.crearRespuesta(false, "Contraseña incorrecta. Intente de nuevo.");
                }
                else                                                  //Si el usuario y contrasena son validos.
                {
                    Usuario usuarioViewModel = _assembler.createUsuario(usuarioActual);
                    respuesta = _creador.crearRespuesta(true, JObject.FromObject(usuarioViewModel));
                }
            }

            return respuesta;
        }

        public Respuesta registrarUsuario(string pRol, JObject pDatosUsuario, JArray pListaGeneroFavoritos)
        {
            Respuesta respuesta = null;
            usuarios usuarioCreado = null;
            try
            {
                if (pRol == "fanatico")
                {
                    Fanatico nuevoFanatico = new Fanatico();
                    nuevoFanatico.deserialize(pDatosUsuario);
                    nuevoFanatico.Estado = _manejador.obtenerEstado(1).estado;
                    nuevoFanatico.TipoUsuario = _manejador.obtenerTipoUsuario(2).tipo;

                    int[] arregloGenerosFavoritos = _serial.getArrayInt(pListaGeneroFavoritos);
                    List<generos> listaGenerosFavoritos = new List<generos>();
                    try
                    {
                        for (int i=0; i < arregloGenerosFavoritos.Length; i++)
                        {
                            listaGenerosFavoritos.Add(_manejador.obtenerGenero(arregloGenerosFavoritos[i]));
                        }
                    } catch(Exception)
                    {
                        return _creador.crearRespuesta(false, "Fallo al seleccionar los generos favoritos.");
                    }

                    usuarioCreado = _manejador.añadirUsuario(_assembler.updateusuarios(nuevoFanatico),
                                listaGenerosFavoritos); //Se almacena el nuevo usuario
                    nuevoFanatico = (Fanatico)_assembler.createUsuario(usuarioCreado);

                    respuesta = _creador.crearRespuesta(true, nuevoFanatico.serialize());
                }
                    
                if (pRol == "colaborador")
                {
                    Colaborador nuevoColaborador = new Colaborador();
                    nuevoColaborador.deserialize(pDatosUsuario);
                    nuevoColaborador.Estado = _manejador.obtenerEstado(1).estado;
                    nuevoColaborador.TipoUsuario = _manejador.obtenerTipoUsuario(1).tipo;

                    usuarioCreado = _manejador.añadirUsuario(_assembler.updateusuarios(nuevoColaborador)); //Se almacena el nuevo usuario
                    nuevoColaborador = (Colaborador) _assembler.createUsuario(usuarioCreado);
                    respuesta = _creador.crearRespuesta(true, nuevoColaborador.serialize());
                }
            }
            catch (Exception e)
            {
                respuesta = _creador.crearRespuesta(false, "Error al ingresar usuario nuevo.");
            }

            return respuesta;
        }
    }
}

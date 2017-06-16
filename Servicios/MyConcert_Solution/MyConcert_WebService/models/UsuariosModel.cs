using MyConcert.viewModels;
using MyConcert.resources.results;
using Newtonsoft.Json.Linq;
using System;
using MyConcert.resources.assembler;
using MyConcert.resources.serial;
using System.Collections.Generic;
using MyConcert.resources.security;

namespace MyConcert.models
{
    public class UsuariosModel : AbstractModel
    {
        private SHA256Encriptation _encriptador = new SHA256Encriptation();
        private SerialHelper _serial = new SerialHelper();
        
        public Respuesta getUsuario(string pUsername)
        {
            Respuesta respuesta = null;

            usuarios userActual = _manejador.obtenerUsuario(pUsername);
            List<generos> listaGenerosFavoritos = _manejador.obtenerGenerosUsuario(userActual);
            GeneroMusical[] arreglogenerosFavoritos = _convertidor.createListaGenero(listaGenerosFavoritos);
            JObject[] jsonArregloGenerosFavoritos = _serial.agruparGeneros(arreglogenerosFavoritos);
            Usuario viewUserActual = _convertidor.createUsuario(userActual);
            viewUserActual.Contrasena = "XXXXXXXX";

            respuesta = _fabricaRespuestas.crearRespuesta(true, JObject.FromObject(viewUserActual), jsonArregloGenerosFavoritos);
            return respuesta;
        }

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
                return respuesta = _fabricaRespuestas.crearRespuesta(false, "Usuario incorrecto o no existente. Por favor intente de nuevo.", e.ToString());
                throw (e);
            }


            if (usuarioActual == null)                                  //Si no existe el nombre de usuario introducido.
            {
                respuesta = _fabricaRespuestas.crearRespuesta(false, "Usuario no existente.");
            }
            else
            {
                if (usuarioActual.contraseña != passwordEncriptado)              //Si la contrasena es incorrecta.
                {
                    respuesta = _fabricaRespuestas.crearRespuesta(false, "Contraseña incorrecta. Intente de nuevo.");
                }
                else                                                  //Si el usuario y contrasena son validos.
                {
                    Usuario usuarioViewModel = _convertidor.createUsuario(usuarioActual);
                    usuarioViewModel.Contrasena = "XXXXXXX";
                    respuesta = _fabricaRespuestas.crearRespuesta(true, JObject.FromObject(usuarioViewModel));
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
                        return _fabricaRespuestas.crearRespuesta(false, "Fallo al seleccionar los generos favoritos.");
                    }

                    usuarioCreado = _manejador.añadirUsuario(_convertidor.updateusuarios(nuevoFanatico),
                                listaGenerosFavoritos); //Se almacena el nuevo usuario
                    nuevoFanatico = (Fanatico)_convertidor.createUsuario(usuarioCreado);

                    respuesta = _fabricaRespuestas.crearRespuesta(true, nuevoFanatico.serialize());
                }
                    
                if (pRol == "colaborador")
                {
                    Colaborador nuevoColaborador = new Colaborador();
                    nuevoColaborador.deserialize(pDatosUsuario);
                    nuevoColaborador.Estado = _manejador.obtenerEstado(1).estado;
                    nuevoColaborador.TipoUsuario = _manejador.obtenerTipoUsuario(1).tipo;

                    usuarioCreado = _manejador.añadirUsuario(_convertidor.updateusuarios(nuevoColaborador)); //Se almacena el nuevo usuario
                    nuevoColaborador = (Colaborador) _convertidor.createUsuario(usuarioCreado);
                    respuesta = _fabricaRespuestas.crearRespuesta(true, nuevoColaborador.serialize());
                }
            }
            catch (Exception e)
            {
                //respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al ingresar usuario nuevo.");
                respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al ingresar usuario nuevo.", e.ToString());
            }

            return respuesta;
        }
    }
}

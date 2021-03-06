﻿using MyConcert.viewModels;
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
        
        //Constructor para inicializar variables del AbstractModel
        public UsuariosModel()
        {
            _manejador = new FacadeDB();
            _convertidor = new Assembler();
            _fabricaRespuestas = new FabricaRespuestas();
        }

        //Obtener usuario especifico
        public Respuesta getUsuario(string pUsername)
        {
            Respuesta respuesta = null;

            try
            {
                usuarios userActual = _manejador.obtenerUsuario(pUsername); //Obtiene datos usuario
                if (userActual == null)
                    return _fabricaRespuestas.crearRespuesta(false, "Usuario no encontrado. Intente de nuevo por favor.");

                List<generos> listaGenerosFavoritos = _manejador.obtenerGenerosUsuario(userActual); //Lista generos favoritos
                GeneroMusical[] arreglogenerosFavoritos = _convertidor.createListaGenero(listaGenerosFavoritos);
                JObject[] jsonArregloGenerosFavoritos = _serial.agruparGeneros(arreglogenerosFavoritos);
                Usuario viewUserActual = _convertidor.createUsuario(userActual);
                viewUserActual.Contrasena = "XXXXXXXX"; //Oculta password

                //Retorna respuesta exitosa con datos de usuario
                respuesta = _fabricaRespuestas.crearRespuesta(true, JObject.FromObject(viewUserActual), jsonArregloGenerosFavoritos);
            } catch(Exception)
            {
                respuesta = _fabricaRespuestas.crearRespuesta(false, "Error en obtener la informacion.");
            }
            
            return respuesta;
        }

        //Modificar usuario
        public  Respuesta modificarUsuario(string tipoUsuario, dynamic pDatosUsuario, JArray pListaGenerosFavoritos)
        {
            Respuesta respuesta = null;
            usuarios usuario = null;

            //Elige el tipo de usuario
            switch(tipoUsuario)
            {
                case "fanatico":    //Si el usuario es fanatico
                    Fanatico fanaticoModificacion = new Fanatico();
                    fanaticoModificacion.deserialize(pDatosUsuario);
                    fanaticoModificacion.Estado = _manejador.obtenerEstado(1).estado;
                    fanaticoModificacion.TipoUsuario = _manejador.obtenerTipoUsuario(2).tipo;

                    //Verificar que el usuario exista
                    if (comprobarUsuarioUnico(fanaticoModificacion))
                        return _fabricaRespuestas.crearRespuesta(false, "Ya se encuentra en uso el nombre de usuario. Intente con otro por favor.");

                    //Comprobar generos musicales favoritos seleccionados
                    int[] arregloGenerosFavoritos = _serial.getArrayInt(pListaGenerosFavoritos);
                    if (arregloGenerosFavoritos.Length > 10)
                        return _fabricaRespuestas.crearRespuesta(false, "Se seleccionaron más del máximo de 10 géneros musicales favoritos. Por favor intente con 10.");

                    List<generos> listaGenerosFavoritos = new List<generos>();
                    try
                    {
                        for (int i = 0; i < arregloGenerosFavoritos.Length; i++)
                        {
                            listaGenerosFavoritos.Add(_manejador.obtenerGenero(arregloGenerosFavoritos[i]));
                        }
                    }
                    catch (Exception)
                    {
                        //Retorna respuesta de fallo
                        return _fabricaRespuestas.crearRespuesta(false, "Fallo al seleccionar los generos favoritos.");
                    }

                    //Almacena modificacion de usuario
                    respuesta = _fabricaRespuestas.crearRespuesta(true, fanaticoModificacion.serialize());
                    break;
                case "colaborador": //Si el usuario es colaborador
                    Colaborador colaboradorModificacion = new Colaborador();
                    colaboradorModificacion.deserialize(pDatosUsuario);    //Parse JSON
                    colaboradorModificacion.Estado = _manejador.obtenerEstado(1).estado;   //Rol colaborador
                    colaboradorModificacion.TipoUsuario = _manejador.obtenerTipoUsuario(1).tipo;   //Establece como activo

                    if (comprobarUsuarioUnico(colaboradorModificacion))
                        return _fabricaRespuestas.crearRespuesta(false, "Ya se encuentra en uso el nombre de usuario. Intente con otro por favor.");

                    //Almacena modificacion de colaborador
                    //usuario = _manejador.añadirUsuario(_convertidor.updateusuarios(nuevoColaborador)); //Se almacena el nuevo usuario
                    //nuevoColaborador = (Colaborador)_convertidor.createUsuario(usuarioCreado); //Almacena nuevo colaborador

                    //Retorna respuesta exitosa
                    respuesta = _fabricaRespuestas.crearRespuesta(true, colaboradorModificacion.serialize());
                    break;
                default:
                    //Si el tipo de usuario no existe. Retorna mensaje error
                    respuesta = _fabricaRespuestas.crearRespuesta(false, "Tipo de usuario no existente. Intente de nuevo por favor.");
                    break;
            }

            return respuesta;
        }

        //Comprobar inicio de sesion
        public Respuesta comprobarInicioSesion(string pUsername, string pPassword)
        {
            Respuesta respuesta = null;
            usuarios usuarioActual;
            string passwordEncriptado = _encriptador.sha256Encrypt(pPassword);  //Encripta password para comparacion

            try
            {
                usuarioActual = _manejador.obtenerUsuario(pUsername);   //Obtener datos usuario
            }
            catch (Exception e)
            {
                //Respuesta de error
                return respuesta = _fabricaRespuestas.crearRespuesta(false, "Usuario incorrecto o no existente. Por favor intente de nuevo.", e.ToString());
                throw (e);
            }


            if (usuarioActual == null)                                  //Si no existe el nombre de usuario introducido.
            {
                respuesta = _fabricaRespuestas.crearRespuesta(false, "Usuario no existente. Por favor intente de nuevo.");
            }
            else
            {
                if (usuarioActual.contraseña != passwordEncriptado)              //Si la contrasena es incorrecta.
                {
                    respuesta = _fabricaRespuestas.crearRespuesta(false, "Contraseña incorrecta. Por favor intente de nuevo.");
                }
                else                                                  //Si el usuario y contrasena son validos.
                {
                    Usuario usuarioViewModel = _convertidor.createUsuario(usuarioActual);
                    usuarioViewModel.Contrasena = "XXXXXXX";

                    //Retorna respuesta exitosa y datos del usuario
                    respuesta = _fabricaRespuestas.crearRespuesta(true, JObject.FromObject(usuarioViewModel));
                }
            }

            return respuesta;
        }

        private bool comprobarUsuarioUnico(Usuario pUsuario)
        {
            try
            {
                usuarios user = _manejador.obtenerUsuario(pUsuario.NombreUsuario);
                if (user != null)
                    return true;
                else
                    return false;
            } catch(Exception e)
            {
                throw (e);
            }
        }

        //Registrar nuevo usuario en el sistema
        public Respuesta registrarUsuario(string pRol, JObject pDatosUsuario, JArray pListaGeneroFavoritos)
        {
            Respuesta respuesta = null;
            usuarios usuarioCreado = null;
            try
            {
                if (pRol == "fanatico") //Si es fanatico
                {
                    Fanatico nuevoFanatico = new Fanatico();
                    nuevoFanatico.deserialize(pDatosUsuario);   //Parse JSON
                    nuevoFanatico.Estado = _manejador.obtenerEstado(1).estado;  //Establece estado activo
                    nuevoFanatico.TipoUsuario = _manejador.obtenerTipoUsuario(2).tipo;  //Rol fanatico

                    if (comprobarUsuarioUnico(nuevoFanatico))
                        return _fabricaRespuestas.crearRespuesta(false, "Ya se encuentra en uso el nombre de usuario. Intente con otro por favor.");

                    //Comprobar generos musicales favoritos seleccionados
                    int[] arregloGenerosFavoritos = _serial.getArrayInt(pListaGeneroFavoritos);
                    if (arregloGenerosFavoritos.Length > 10)
                        return _fabricaRespuestas.crearRespuesta(false, "Se seleccionaron más del máximo de 10 géneros musicales favoritos. Por favor intente con 10.");

                    List<generos> listaGenerosFavoritos = new List<generos>();
                    try
                    {
                        for (int i=0; i < arregloGenerosFavoritos.Length; i++)
                        {
                            listaGenerosFavoritos.Add(_manejador.obtenerGenero(arregloGenerosFavoritos[i]));
                        }
                    } catch(Exception)
                    {
                        //Retorna respuesta de fallo
                        return _fabricaRespuestas.crearRespuesta(false, "Fallo al seleccionar los generos favoritos.");
                    }

                    usuarioCreado = _manejador.añadirUsuario(_convertidor.updateusuarios(nuevoFanatico),
                                listaGenerosFavoritos);     //Se almacena el nuevo usuario
                    nuevoFanatico = (Fanatico)_convertidor.createUsuario(usuarioCreado);

                    //Retorna respuesta exitosa
                    respuesta = _fabricaRespuestas.crearRespuesta(true, nuevoFanatico.serialize());
                }
                    
                if (pRol == "colaborador")  //Si es colaborador
                {
                    Colaborador nuevoColaborador = new Colaborador();
                    nuevoColaborador.deserialize(pDatosUsuario);    //Parse JSON
                    nuevoColaborador.Estado = _manejador.obtenerEstado(1).estado;   //Rol colaborador
                    nuevoColaborador.TipoUsuario = _manejador.obtenerTipoUsuario(1).tipo;   //Establece como activo

                    if (comprobarUsuarioUnico(nuevoColaborador))
                        return _fabricaRespuestas.crearRespuesta(false, "Ya se encuentra en uso el nombre de usuario. Intente con otro por favor.");

                    usuarioCreado = _manejador.añadirUsuario(_convertidor.updateusuarios(nuevoColaborador)); //Se almacena el nuevo usuario
                    nuevoColaborador = (Colaborador) _convertidor.createUsuario(usuarioCreado); //Almacena nuevo colaborador

                    //Retorna respuesta exitosa
                    respuesta = _fabricaRespuestas.crearRespuesta(true, nuevoColaborador.serialize());
                }
            }
            catch (Exception)
            {
                //Respuesta de error 
                respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al ingresar usuario nuevo.");
                //respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al ingresar usuario nuevo.", e.ToString());
            }

            return respuesta;
        }
    }
}

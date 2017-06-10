﻿using MyConcert_WebService.database;
using MyConcert_WebService.objects;
using MyConcert_WebService.res;
using MyConcert_WebService.res.resultados;
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

        public UsuariosModel()
        {
            _usuariosDB = new UsuariosDB();
        }

        public Respuesta comprobarInicioSesion(string pUsername, string pPassword)
        {
            Usuario usuarioActual;
            try
            {
                usuarioActual = _usuariosDB.obtenerUsuario(pUsername);
            } catch(Exception e)
            {
                return respuesta = creador.crearRespuesta(false, e.ToString());
            }
            

            if (usuarioActual == null)                                  //Si no existe el nombre de usuario introducido.
            {
                respuesta = creador.crearRespuesta(false, "Usuario no existente.");
            }
            else
            {
                if (usuarioActual.Contrasena != pPassword)              //Si la contrasena es incorrecta.
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

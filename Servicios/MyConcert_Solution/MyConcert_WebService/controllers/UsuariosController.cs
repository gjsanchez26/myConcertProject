﻿using MyConcert_WebService.res;
using MyConcert_WebService.res.resultados;
using MyConcert_WebService.res.usr;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;

namespace MyConcert_WebService.controllers
{
    public class UsuariosController : ApiController
    {
        //Obtener usuario especifico.
        public JObject Get(string pNombreUsuario)
        {
            ResultadoObjeto respuesta = new ResultadoObjeto();

            //Obtiene usuario de base de datos.
            return JObject.FromObject(respuesta); //Retorna objeto usuario.
        }

        //Crear usuario nuevo.
        public JObject Post(JObject pDatosUsuario)
        {
            dynamic request = pDatosUsuario;

            try
            {
                Usuario nuevoUsuario = request.user;
                bool response = true;
                return JObject.FromObject(response);
            } catch(Exception e) {
                string error = e.Message;
                return JObject.FromObject(error);
            }
        }

        //Actualiza usuario especifico.
        public JObject Put(JObject pDatosUsuario)
        {
            dynamic peticion = pDatosUsuario;
            ResultadoObjeto respuesta = new ResultadoObjeto();

            //Actualiza usuario en base de datos.
            return JObject.FromObject(respuesta); //Retorna estado de modificacion.
        }

        //Elimina usuario especifico.
        public JObject Delete(string pNombreUsuario)
        {
            ResultadoObjeto respuesta = new ResultadoObjeto();

            //Elimina usuario de base de datos.
            return JObject.FromObject(respuesta); //Retorna estado de eliminacion.
        }
    }
}

﻿using MyConcert.models;
using MyConcert.resources.results;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert.controllers
{
    /**
     * Eventos Controller
     * */
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EventosController : ApiController
    {
        private EventosModel _model = new EventosModel();
        private FabricaRespuestas _creador = new FabricaRespuestas();

        //Obtener informacion de eventos.
        public JObject Get(string type)
        {
            Respuesta respuesta = null;

            switch (type)
            {
                case "carteleras":      //Si necesita carteleras
                    respuesta = _model.getCarteleras();
                    break;
                case "festivales":      //Si necesita festivales
                    respuesta = _model.getFestivales();
                    break;
                default:        //Si no existe el tipo de evento
                    respuesta = _creador.crearRespuesta(false, "Tipo de evento no existente.");
                    break;
            }

            return JObject.FromObject(respuesta);
        }

        //Obtener informacion de evento especifico.
        public JObject Get(int id)
        {
            Respuesta respuesta = null;

            respuesta = _model.getEvento(id);

            return JObject.FromObject(respuesta);
        }

        //Crear evento nuevo.
        public JObject Post(JObject pDatosEvento)
        {
            dynamic peticion = pDatosEvento;
            string tipoEvento = (string) peticion.event_type;
            JObject datosEventoJSON = (JObject) peticion.event_data;
            JArray categorias = (JArray) peticion.categories;

            Respuesta respuesta = null;
            respuesta = _model.crearEvento(tipoEvento, datosEventoJSON, categorias);

            return JObject.FromObject(respuesta);
        }
    }
}

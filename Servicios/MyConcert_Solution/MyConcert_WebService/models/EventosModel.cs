using MyConcert_WebService.objects;
using MyConcert_WebService.res.resultados;
using MyConcert_WebService.res.serial;
using Newtonsoft.Json.Linq;
using System;

namespace MyConcert_WebService.models
{
    public class EventosModel
    {
        private ManejadorBD _manejador = new ManejadorBD();
        private FabricaRespuestas _creador = new FabricaRespuestas();
        private SerializerJSON _serial = new SerializerJSON();

        public Respuesta getCarteleras()
        {
            Evento[] listaCarteleras = _manejador.obtenerCarteleras();
            JObject[] arreglo = new JObject[listaCarteleras.Length];

            for (int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = JObject.FromObject(listaCarteleras[i]);
            }

            return _creador.crearRespuesta(true, arreglo);
        }

        public Respuesta getFestivales()
        {
            Evento[] listaFestivales = _manejador.obtenerFestivales();
            JObject[] arreglo = new JObject[listaFestivales.Length];

            for (int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = JObject.FromObject(listaFestivales[i]);
            }

            return _creador.crearRespuesta(true, arreglo);
        }

        public Respuesta crearEvento(string pTipoEvento, dynamic pDatosEventoJSON, JArray pListaCategorias)
        {
            Respuesta respuesta = null;
            CategoriaBanda[] categoriasEvento = _serial.getArrayCategoriaBandaEvento(pListaCategorias);

            try
            {
                switch (pTipoEvento)
                {
                    case "cartelera":
                        Cartelera nuevaCartelera = _serial.leerDatosCartelera(pDatosEventoJSON);
                        _manejador.añadirCartelera(nuevaCartelera, categoriasEvento);
                        respuesta = _creador.crearRespuesta(false, "Cartelera creada exitosamente.");
                        break;
                    case "festival":
                        Festival nuevoFestival = _serial.leerDatosFestival(pDatosEventoJSON);
                        _manejador.añadirFestival(nuevoFestival, categoriasEvento);
                        respuesta = _creador.crearRespuesta(false, "Festival creado exitosamente.");
                        break;
                    default:
                        respuesta = _creador.crearRespuesta(false, "Tipo de evento no existente.");
                    break;
                }
            } catch(Exception e)
            {
                respuesta = _creador.crearRespuesta(false, "Error al crear evento nuevo.");
            }

            return respuesta;
        }
    }
}

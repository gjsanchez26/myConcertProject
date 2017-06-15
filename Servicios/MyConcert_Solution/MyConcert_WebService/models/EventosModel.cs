using MyConcert_WebService.viewModels;
using MyConcert_WebService.res.resultados;
using MyConcert_WebService.res.serial;
using Newtonsoft.Json.Linq;
using System;
using MyConcert_WebService.res.assembler;
using System.Collections.Generic;

namespace MyConcert_WebService.models
{
    public class EventosModel
    {
        private ManejadorBD _manejador = new ManejadorBD();
        private FabricaRespuestas _creador = new FabricaRespuestas();
        private Assembler _convertidor = new Assembler();
        private SerialHelper _serial = new SerialHelper();
        private ChefModel _chef = new ChefModel();

        public Respuesta getCarteleras()
        {
            Evento[] listaCarteleras = _convertidor.createListaEventos( _manejador.obtenerCarteleras());
            JObject[] arreglo = new JObject[listaCarteleras.Length];

            for (int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = JObject.FromObject(listaCarteleras[i]);
            }

            return _creador.crearRespuesta(true, arreglo);
        }

        public Respuesta getFestivales()
        {
            Evento[] listaFestivales = _convertidor.createListaEventos(_manejador.obtenerFestivales());
            JObject[] arreglo = new JObject[listaFestivales.Length];

            for (int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = JObject.FromObject(listaFestivales[i]);
            }

            return _creador.crearRespuesta(true, arreglo);
        }

        public Respuesta getEvento(int pID)
        {
            Respuesta respuesta = null;



            return respuesta;
        }

        public Respuesta crearEvento(string pTipoEvento, dynamic pDatosEventoJSON, JArray pListaCategorias)
        {
            Respuesta respuesta = null;
            try
            {
                CategoriaBanda[] categorias = _serial.getArrayCategoriaBandaEvento(pListaCategorias);

                switch (pTipoEvento)
                {
                    case "cartelera":
                        Cartelera nuevaCartelera = _serial.leerDatosCartelera(pDatosEventoJSON);
                         
                        _manejador.añadirCartelera(_convertidor.updateeventos(nuevaCartelera), _convertidor.updatecategoriasevento(categorias));
                        respuesta = _creador.crearRespuesta(false, "Cartelera creada exitosamente.");
                        break;
                    case "festival":
                        Festival nuevoFestival = _serial.leerDatosFestival(pDatosEventoJSON);
                        eventos nuevoEvento = _convertidor.updateeventos(nuevoFestival);

                        List<string> bandasGanadoras = new List<string>();
                        foreach(CategoriaBanda cat_band in categorias)
                        {
                            foreach(int IDBanda in cat_band._bandasID)
                            {
                                bandasGanadoras.Add(_manejador.obtenerBanda(IDBanda).nombreBan);
                            }
                        }



                        string bandaRecomendada = _chef.executeChefProcess(bandasGanadoras, nuevoEvento.PK_eventos);
                        nuevoEvento.FK_EVENTOS_BANDAS_CHEF = _manejador.obtenerBanda(bandaRecomendada).PK_bandas;

                        _manejador.añadirFestival(nuevoEvento, _convertidor.updatecategoriasevento(categorias));
                        respuesta = _creador.crearRespuesta(false, "Festival creado exitosamente.");
                        break;
                    default:
                        respuesta = _creador.crearRespuesta(false, "Tipo de evento no existente.");
                    break;
                }
            } catch(Exception e)
            {
                //respuesta = _creador.crearRespuesta(false, "Error al crear evento.");
                respuesta = _creador.crearRespuesta(false, "Error al crear evento.", e.ToString());
            }

            return respuesta;
        }
    }
}

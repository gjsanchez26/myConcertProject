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
            eventos eventoSolicitado = _manejador.obtenerEvento(pID);
            List<categorias> listaCategoriasEvento = _manejador.obtenerCategoriasEvento(eventoSolicitado.PK_eventos);

            if (eventoSolicitado.FK_EVENTOS_TIPOSEVENTOS == _manejador.obtenerTipoEvento(1).PK_tiposEventos)
            {
                JObject[] categoriasEventoEspecifico = obtenerCategoriasCartelera(pID, listaCategoriasEvento);
                Evento eventoAuxiliar = _convertidor.createEvento(eventoSolicitado);
                respuesta = _creador.crearRespuestaEvento(true, categoriasEventoEspecifico, JObject.FromObject(eventoAuxiliar));

            }
            else if (eventoSolicitado.FK_EVENTOS_TIPOSEVENTOS == _manejador.obtenerTipoEvento(2).PK_tiposEventos)
            {
                List<bandas> bandasFestival = extraerBandasEvento(eventoSolicitado, listaCategoriasEvento);
                JObject[] bandas = new JObject[bandasFestival.Count];
                int iterator = 0;
                foreach(bandas bandaActual in bandasFestival)
                {
                    dynamic banda = new JObject();
                    banda.name_band = bandaActual.nombreBan;
                    banda.votes = _manejador.obtenerCantidadVotos(eventoSolicitado.PK_eventos, bandaActual.PK_bandas);
                    bandas[iterator] = banda; 
                }
                Evento evento = _convertidor.createEvento(eventoSolicitado);
                FestivalBandas fest = new FestivalBandas(JObject.FromObject(evento), bandas);
                respuesta = _creador.crearRespuesta(true, JObject.FromObject(fest));
            }

            return respuesta;
        }

        private JObject[] obtenerCategoriasCartelera(int pID, List<categorias> listaCategoriasEvento)
        {
            JObject[] categoriasEventoEspecifico = new JObject[listaCategoriasEvento.Count];
            int iterator = 0;
            foreach (categorias categoriaActual in listaCategoriasEvento)
            {
                List<bandas> bandasCategoria = _manejador.obtenerBandasCategoria(categoriaActual.PK_categorias, pID);
                JObject[] bandaConResultado = new JObject[bandasCategoria.Count];
                int iterator2 = 0;
                foreach (bandas bandaActual in bandasCategoria)
                {
                    dynamic bands = new JObject();
                    bands.name_band = bandaActual.nombreBan;
                    bands.result = _manejador.obtenerCantidadVotos(pID, categoriaActual.PK_categorias, bandaActual.PK_bandas);
                    bandaConResultado[iterator2] = bands;
                    iterator2++;
                }
                CategoriaBandaVotacion catActualConBanda = new CategoriaBandaVotacion(categoriaActual.categoria, bandaConResultado);
                categoriasEventoEspecifico[iterator] = JObject.FromObject(catActualConBanda);
                iterator++;
            }

            return categoriasEventoEspecifico;
        }

        public Respuesta crearEvento(string pTipoEvento, JObject pDatosEventoJSON, JArray pListaCategorias)
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
                        respuesta = _creador.crearRespuesta(true, "Cartelera creada exitosamente.");
                        break;
                    case "festival":
                        Festival nuevoFestival = _serial.leerDatosFestival(pDatosEventoJSON);
                        eventos nuevoEvento = _convertidor.updateeventos(nuevoFestival);

                        List<bandas> bandasGanadorasFestival = parseBandas(categorias);
                        List<categorias> categoriasCartelera = _manejador.obtenerCategoriasEvento(nuevoEvento.PK_eventos);
                        List<bandas> todasBandasCartelera = extraerBandasEvento(nuevoEvento, categoriasCartelera);
                        List<bandas> bandasPerdedoras = extraerBandasNoSeleccionadas(bandasGanadorasFestival, todasBandasCartelera);
                        List<string> bandasGanadoras = bandasToString(bandasGanadorasFestival);
                        List<string> bandasPerdedorasString = bandasToString(bandasPerdedoras);

                        foreach(string str in bandasPerdedorasString)
                        {
                            Console.WriteLine(str);
                        }

                        string bandaRecomendada = _chef.executeChefProcess(bandasGanadoras, nuevoEvento.PK_eventos);

                        nuevoEvento.FK_EVENTOS_BANDAS_CHEF = _manejador.obtenerBanda(bandaRecomendada).PK_bandas;

                        _manejador.crearFestival(nuevoEvento, bandasPerdedoras);

                        respuesta = _creador.crearRespuesta(true, "Festival creado exitosamente.");
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

        private List<string> bandasToString(List<bandas> bandasGanadorasFestival)
        {
            List<string> bandasGanadoras = new List<string>();
            foreach (bandas bandaGanadora in bandasGanadorasFestival)
            {
                bandasGanadoras.Add(bandaGanadora.nombreBan);
            }

            return bandasGanadoras;
        }
        
        private List<bandas> extraerBandasNoSeleccionadas(List<bandas> bandasGanadorasFestival, List<bandas> todasBandasCartelera)
        {
            List<bandas> bandasPerdedoras = new List<bandas>();
            foreach (bandas bandaGanadora in bandasGanadorasFestival)
            {
                bandas bandaEliminar = todasBandasCartelera.Find(x => x.Equals(bandaGanadora));
                if (bandaEliminar != null)
                {
                    todasBandasCartelera.Remove(bandaEliminar);
                    Console.WriteLine(bandaEliminar.nombreBan);
                } else {
                    bandasPerdedoras.Add(bandaEliminar);
                    //Console.WriteLine(bandaEliminar.nombreBan);
                }
                    
            }
            return bandasPerdedoras;
        }

        private List<bandas> extraerBandasEvento(eventos nuevoEvento, List<categorias> categoriasCartelera)
        {
            List<bandas> todasBandasCartelera = new List<bandas>();
            foreach (categorias categoriaActual in categoriasCartelera)
            {
                foreach (bandas bandaActual in _manejador.obtenerBandasCategoria(categoriaActual.PK_categorias, nuevoEvento.PK_eventos))
                {
                    todasBandasCartelera.Add(bandaActual);
                }
            }

            return todasBandasCartelera;
        }

        private List<bandas> parseBandas(CategoriaBanda[] categorias)
        {
            List<bandas> bandasGanadorasFestival = new List<bandas>();
            foreach (CategoriaBanda cat_band in categorias)
            {
                foreach (int IDBanda in cat_band._bandasID)
                {
                    bandasGanadorasFestival.Add(_manejador.obtenerBanda(IDBanda));
                }
            }

            return bandasGanadorasFestival;
        }
    }
}

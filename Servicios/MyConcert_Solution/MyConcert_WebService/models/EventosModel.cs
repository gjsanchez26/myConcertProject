using MyConcert.viewModels;
using MyConcert.resources.results;
using MyConcert.resources.serial;
using Newtonsoft.Json.Linq;
using System;
using MyConcert.resources.assembler;
using System.Collections.Generic;
using MyConcert.resources.services;

namespace MyConcert.models
{
    public class EventosModel : AbstractModel
    {
        private SerialHelper _serial = new SerialHelper();
        private ChefModel _chef = new ChefModel();

        public EventosModel()
        {
            this._manejador = new FacadeDB();
            this._fabricaRespuestas = new FabricaRespuestas();
            this._convertidor = new Assembler();
        }

        public Respuesta getCarteleras()
        {
            Evento[] listaCarteleras = _convertidor.createListaEventos( _manejador.obtenerCarteleras());
            JObject[] arreglo = new JObject[listaCarteleras.Length];

            for (int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = JObject.FromObject(listaCarteleras[i]);
            }

            return _fabricaRespuestas.crearRespuesta(true, arreglo);
        }

        public Respuesta getFestivales()
        {
            Evento[] listaFestivales = _convertidor.createListaEventos(_manejador.obtenerFestivales());
            JObject[] arreglo = new JObject[listaFestivales.Length];

            for (int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = JObject.FromObject(listaFestivales[i]);
            }

            return _fabricaRespuestas.crearRespuesta(true, arreglo);
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
                respuesta = _fabricaRespuestas.crearRespuesta(true, categoriasEventoEspecifico, JObject.FromObject(eventoAuxiliar));

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
                respuesta = _fabricaRespuestas.crearRespuesta(true, JObject.FromObject(fest));
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
                string nombreEvento = null;
                CategoriaBanda[] categorias = _serial.getArrayCategoriaBandaEvento(pListaCategorias);

                switch (pTipoEvento)
                {
                    case "cartelera":
                        Cartelera nuevaCartelera = _serial.leerDatosCartelera(pDatosEventoJSON);
                        nombreEvento = nuevaCartelera.Nombre;

                        List<categoriasevento> categoriasEvento = _convertidor.updatecategoriasevento(categorias);
                        _manejador.añadirCartelera(_convertidor.updateeventos(nuevaCartelera), categoriasEvento);

                        publicarBandasTwitter(nombreEvento, categoriasEvento);

                        respuesta = _fabricaRespuestas.crearRespuesta(true, "Cartelera creada exitosamente.");
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

                        publicarFestivalNuevoTwitter(nuevoEvento.nombreEve);

                        respuesta = _fabricaRespuestas.crearRespuesta(true, "Festival creado exitosamente.");
                        break;
                    default:
                        respuesta = _fabricaRespuestas.crearRespuesta(false, "Tipo de evento no existente.");
                    break;
                }
            } catch(Exception e)
            {
                //respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al crear evento.");
                respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al crear evento.", e.ToString());
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

        private void publicarBandasTwitter(string pNombreEvento, List<categoriasevento> pListaCategoriasBanda)
        {
            TwitterManager twitter = new TwitterManager(); 
            foreach (categoriasevento cat_eve in pListaCategoriasBanda)
            {
                string nombreBanda = _manejador.obtenerBanda(cat_eve.FK_CATEGORIASEVENTO_BANDAS).nombreBan;
                string mensajeTweet = "¡Vota por tu banda. " + nombreBanda + " en el festival " + pNombreEvento +"!";
                try
                {
                    twitter.enviarTweet(mensajeTweet);
                } catch(Exception e)
                {
                    throw (e);
                }
            }
        }

        private void publicarFestivalNuevoTwitter(string pNombreEvento)
        {
            TwitterManager twitter = new TwitterManager();
            try
            {
                string mensajeTweet = "¡Visita nuestro nuevo festival " + pNombreEvento +"!";
                twitter.enviarTweet(mensajeTweet);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}

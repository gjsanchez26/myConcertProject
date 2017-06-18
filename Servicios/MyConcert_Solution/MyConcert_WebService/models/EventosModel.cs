using MyConcert.resources.assembler;
using MyConcert.resources.results;
using MyConcert.resources.serial;
using MyConcert.resources.services;
using MyConcert.viewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace MyConcert.models
{
    /**
     * Evento Model
     * */
    public class EventosModel : AbstractModel
    {
        private SerialHelper _serial = new SerialHelper();
        private ChefModel _chef = new ChefModel();

        //Inicializa variables locales
        public EventosModel()
        {
            this._manejador = new FacadeDB();
            this._fabricaRespuestas = new FabricaRespuestas();
            this._convertidor = new Assembler();
        }

        //Obtener carteleras
        public Respuesta getCarteleras()
        {
            //Busca la información
            Evento[] listaCarteleras = _convertidor.createListaEventos( _manejador.obtenerCarteleras());
            JObject[] arreglo = new JObject[listaCarteleras.Length];

            for (int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = JObject.FromObject(listaCarteleras[i]);
            }

            //Retorna carteleras disponibles
            return _fabricaRespuestas.crearRespuesta(true, arreglo);
        }

        //Obtener festivales
        public Respuesta getFestivales()
        {
            //Busca la información
            Evento[] listaFestivales = _convertidor.createListaEventos(_manejador.obtenerFestivales());
            JObject[] arreglo = new JObject[listaFestivales.Length];

            for (int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = JObject.FromObject(listaFestivales[i]);
            }

            //Retorna festivales disponibles
            return _fabricaRespuestas.crearRespuesta(true, arreglo);
        }

        //Verifica si elemento existe en lista
        public bool existeEnLista(List<categorias> lista, categorias categoria)
        {
            foreach (categorias catActual in lista)
            {
                if (categoria.categoria == catActual.categoria)
                {
                    //Retorna que categoria se encuentra en lista
                    return true;
                }
            }
            //Retorna que categoria no está en la lista
            return false;
        }

        //Comprueba si banda esta en lista
        public bool existeEnLista(List<bandas> lista, bandas pBanda)
        {
            foreach (bandas bandActual in lista)
            {
                if (pBanda.nombreBan == bandActual.nombreBan)
                {
                    //Retorna que banda se encuentra en lista
                    return true;
                }
            }
            //Retorna que banda no está en la lista
            return false;
        }

        //Obtener evento especifico
        public Respuesta getEvento(int pID)
        {
            Respuesta respuesta = null;
            try
            {
                //Busca la información solicitada
                eventos eventoSolicitado = _manejador.obtenerEvento(pID);
                List<categorias> listaCategoriasEvento = _manejador.obtenerCategoriasEvento(eventoSolicitado.PK_eventos);
                List<categorias> categoriasSinRepetir = generarCategorias(listaCategoriasEvento);

                //Si el evento es una cartelera
                if (eventoSolicitado.FK_EVENTOS_TIPOSEVENTOS == _manejador.obtenerTipoEvento(1).PK_tiposEventos)
                {
                    JObject[] categoriasEventoEspecifico = obtenerCategoriasCartelera(pID, categoriasSinRepetir);
                    Evento eventoAuxiliar = _convertidor.createEvento(eventoSolicitado);

                    //Cartelera obtenida correctamente
                    respuesta = _fabricaRespuestas.crearRespuesta(true, categoriasEventoEspecifico, JObject.FromObject(eventoAuxiliar));

                } //Si el evento es un festival
                else if (eventoSolicitado.FK_EVENTOS_TIPOSEVENTOS == _manejador.obtenerTipoEvento(2).PK_tiposEventos)
                {
                    List<bandas> bandasFestival = extraerBandasEvento(eventoSolicitado, categoriasSinRepetir);
                    JObject[] bandas = new JObject[bandasFestival.Count];
                    int iterator = 0;
                    foreach (bandas bandaActual in bandasFestival)
                    {
                        dynamic banda = new JObject();
                        banda.name_band = bandaActual.nombreBan;
                        banda.votes = _manejador.obtenerCantidadVotos(eventoSolicitado.PK_eventos, bandaActual.PK_bandas);
                        bandas[iterator] = banda;
                    }
                    Evento evento = _convertidor.createEvento(eventoSolicitado);
                    FestivalBandas fest = new FestivalBandas(JObject.FromObject(evento), bandas);

                    //Festival obtenido correctamente
                    respuesta = _fabricaRespuestas.crearRespuesta(true, JObject.FromObject(fest));
                }
                else
                {
                    respuesta = _fabricaRespuestas.crearRespuesta(false, "Error: Evento no existente.");
                }
            }
            catch (Exception)
            {
                //Mensaje de error
                respuesta = _fabricaRespuestas.crearRespuesta(false, "Error: Error al procesar información. Por favor intente de nuevo.");
            }

            //Retorna respuesta
            return respuesta;
        }

        //Gennera lista de categorias para almacenamiento persistente
        public List<categorias> generarCategorias(List<categorias> listaCategoriasEvento)
        {
            //Organiza la información
            List<categorias> categoriasRespuesta = new List<categorias>();
            foreach (categorias catActual in listaCategoriasEvento)
            {
                if (!existeEnLista(categoriasRespuesta, catActual))
                {
                    categoriasRespuesta.Add(catActual);
                }
            }

            //Retorna lista de categorías
            return categoriasRespuesta;
        }

        //Obtener categorias de una cartelera especifica
        private JObject[] obtenerCategoriasCartelera(int pID, List<categorias> listaCategoriasEvento)
        {
            JObject[] categoriasEventoEspecifico = null;
            try
            {
                //Busca la información
                categoriasEventoEspecifico = new JObject[listaCategoriasEvento.Count];
                int iterator = 0;
                foreach (categorias categoriaActual in listaCategoriasEvento)
                {
                    //Organiza la información solicitada
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
            }
            catch (Exception)
            {
                //Fallo al procesar información
            }

            //Retorna lilsta de categorías
            return categoriasEventoEspecifico;
        }

        //Crear evento nuevo
        public Respuesta crearEvento(string pTipoEvento, JObject pDatosEventoJSON, JArray pListaCategorias)
        {
            Respuesta respuesta = null;
            try
            {
                string nombreEvento = null;
                switch (pTipoEvento)
                {
                    //Si el evento a crear es una cartelera
                    case "cartelera":
                        //Verificar si cartelera existe
                        Cartelera nuevaCartelera = _serial.leerDatosCartelera(pDatosEventoJSON);
                        nombreEvento = nuevaCartelera.Nombre;
                        eventos eveAux = _manejador.obtenerEvento(nuevaCartelera.Nombre);
                        if (eveAux != null)
                            return _fabricaRespuestas.crearRespuesta(false, "Error: Evento ya existente. Intentar de nuevo por favor.");

                        //Verificar que existan categorias en la cartelera
                        FestivalCategoriaBanda[] categoriasSerial = _serial.getArrayFestivalCategoriaBanda(pListaCategorias);
                        if (categoriasSerial.Length == 0)
                            return _fabricaRespuestas.crearRespuesta(false, "No se puede crear cartelera sin categorías. Por favor intente de nuevo.");
                        
                        //Organiza información para envío
                        List<categoriasevento> categoriasEvento = _convertidor.updatecategoriasevento(categoriasSerial);

                        //Verificar existencia de bandas en categoria
                        foreach (categoriasevento catEve in categoriasEvento)
                        {
                            if (_manejador.obtenerBanda(catEve.FK_CATEGORIASEVENTO_BANDAS) == null)
                            {
                                string nombreCategoria = _manejador.obtenerCategoria(catEve.FK_CATEGORIASEVENTO_CATEGORIAS).categoria;
                                return _fabricaRespuestas.crearRespuesta(false, "No se puede crear una cartelera si " + nombreCategoria
                                                                                + " no tiene bandas asociadas. Por favor intente de nuevo.");
                            }
                            bandas bandaAuxiliar = _manejador.obtenerBanda(catEve.FK_CATEGORIASEVENTO_BANDAS);
                            if (_manejador.comprobarBandaEnCartelera(nuevaCartelera.FechaInicioFestival, nuevaCartelera.FechaFinalFestival, bandaAuxiliar))
                            {
                                return _fabricaRespuestas.crearRespuesta(false, "La banda "+bandaAuxiliar.nombreBan+" no se encuentra disponible para las fechas indicadas.");
                            }   
                        }

                        //Almacena nuevo evento en persistencia
                        _manejador.añadirCartelera(_convertidor.updateeventos(nuevaCartelera), categoriasEvento);

                        //Publicar tweets de bandas agregadas a evento
                        publicarBandasTwitter(nombreEvento, categoriasEvento);

                        //Operación completada
                        respuesta = _fabricaRespuestas.crearRespuesta(true, "Cartelera creada exitosamente.");
                        break;
                    //Si el evento a crear es un festival
                    case "festival":
                        //Verificar si festival existe
                        Festival nuevoFestival = _serial.leerDatosFestival(pDatosEventoJSON);
                        eventos eveAux1 = _manejador.obtenerEvento(nuevoFestival.Nombre);
                        if (eveAux1 == null)
                            return _fabricaRespuestas.crearRespuesta(false, "Error: Cartelera no existente. Intentar de nuevo por favor. Se necesita partir de una cartelera para convertir a festival.");

                        FestivalCategoriaBanda[] categoriasFestival = _serial.getArrayFestivalCategoriaBanda(pListaCategorias); 
                        
                        eventos nuevoEvento = _convertidor.updateeventos(nuevoFestival);
                                             

                        //Organiza la información para envío
                        List<bandas> bandasGanadorasFestival = parseBandas(categoriasFestival);
                        List<categorias> categoriasCartelera = _manejador.obtenerCategoriasEvento(nuevoEvento.PK_eventos);
                        List<bandas> todasBandasCartelera = extraerBandasEvento(nuevoEvento, categoriasCartelera);

                        List<bandas> bandasPerdedoras = extraerBandasNoSeleccionadas(bandasGanadorasFestival, todasBandasCartelera);

                        Console.WriteLine("*** Cartelera ***");
                        printList(todasBandasCartelera);

                        Console.WriteLine("*** Ganadoras ***");
                        printList(bandasGanadorasFestival);

                        Console.WriteLine("*** Perdedoras ***");
                        printList(bandasPerdedoras);

                        List<string> bandasGanadoras = bandasToString(bandasGanadorasFestival);
                        List<string> bandasPerdedorasString = bandasToString(bandasPerdedoras);

                        string bandaRecomendada = _chef.executeChefProcess(bandasGanadoras, bandasGanadorasFestival, nuevoEvento.PK_eventos);

                        nuevoEvento.FK_EVENTOS_BANDAS_CHEF = _manejador.obtenerBanda(bandaRecomendada).PK_bandas;

                        //Almacena nuevo evento en persistencia
                        _manejador.crearFestival(nuevoEvento, bandasPerdedoras);

                        //Publica tweet de nuevo festival
                        publicarFestivalNuevoTwitter(nuevoEvento.nombreEve);

                        //Operación completada
                        respuesta = _fabricaRespuestas.crearRespuesta(true, "Festival creado exitosamente. Nuestra banda recomendada por el chef para el festival es: "+bandaRecomendada);
                        break;
                    default:
                        //Tipo de evento no existe
                        respuesta = _fabricaRespuestas.crearRespuesta(false, "Tipo de evento no existente.");
                    break;
                }
            } catch(Exception e)
            {
                //respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al crear evento por falta de información. Verifique los datos ingresados por favor.");
                respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al crear evento. Por favor intente de nuevo.", e.ToString());
            }

            //Retorna respuesta
            return respuesta;
        }

        //Convierte lista de bandas en lista de nombres de bandas
        public List<string> bandasToString(List<bandas> bandasGanadorasFestival)
        {
            List<string> bandasGanadoras = new List<string>();
            foreach (bandas bandaGanadora in bandasGanadorasFestival)
            {
                bandasGanadoras.Add(bandaGanadora.nombreBan);
            }

            return bandasGanadoras;
        }

        private  void printList(List<bandas> ListaBandas)
        {
            foreach (bandas bandaActual in ListaBandas)
            {
                Console.WriteLine(bandaActual.nombreBan);
            }
            Console.WriteLine("*******************************");   
        }

        //Conseguir bandas no seleccionadas de una cartelera convertida a festival
        public List<bandas> extraerBandasNoSeleccionadas(List<bandas> bandasGanadorasFestival, List<bandas> todasBandasCartelera)
        {
            foreach (bandas bandaGanadora in bandasGanadorasFestival)
            {
                bandas bandaEliminar = todasBandasCartelera.Find(x => x.nombreBan.Equals(bandaGanadora.nombreBan));
                if (bandaEliminar != null)
                {
                    todasBandasCartelera.Remove(bandaEliminar);
                }
            }
            return todasBandasCartelera;
        }

        //Extraer las bandas de un evento específico
        private List<bandas> extraerBandasEvento(eventos nuevoEvento, List<categorias> categoriasCartelera)
        {
            List<bandas> todasBandasCartelera = new List<bandas>();
            foreach (categorias categoriaActual in categoriasCartelera)
            {
                foreach (bandas bandaActual in _manejador.obtenerBandasCategoria(categoriaActual.PK_categorias, nuevoEvento.PK_eventos))
                {
                    if(!existeEnLista(todasBandasCartelera, bandaActual))
                    {
                        todasBandasCartelera.Add(bandaActual);
                    }
                }
            }

            return todasBandasCartelera;
        }

        //Interpreta bandas para un evento
        private List<bandas> parseBandas(FestivalCategoriaBanda[] categorias)
        {
            List<bandas> bandasGanadorasFestival = new List<bandas>();
            foreach (FestivalCategoriaBanda cat_band in categorias)
            {
                bandasGanadorasFestival.Add(_manejador.obtenerBanda(cat_band.idBanda));
            }

            return bandasGanadorasFestival;
        }

        //Publica bandas agregadas en Twiter
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

        //Publicar nuevo festival en Twitter
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

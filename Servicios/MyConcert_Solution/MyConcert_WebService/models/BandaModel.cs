using MyConcert.viewModels;
using MyConcert.resources.results;
using System;
using MyConcert.resources.assembler;
using Newtonsoft.Json.Linq;
using MyConcert.resources.serial;
using System.Collections.Generic;
using MyConcert.resources.services;

namespace MyConcert.models
{
    public class BandaModel : AbstractModel
    {
        private SerialHelper _serial;
        private SpotifyUtils _spotify;

        public BandaModel()
        {
            _manejador = new FacadeDB();
            _fabricaRespuestas = new FabricaRespuestas();
            _convertidor = new Assembler();
            _serial = new SerialHelper();
            _spotify = new SpotifyUtils();
        }

        //Registrar nueva banda en el sistema
        public Respuesta nuevaBanda(string pNombre, JArray pMiembros,
                                JArray pCanciones, JArray pGeneros)
        {
            Respuesta respuesta = null;
            Banda banda = new Banda(pNombre, _manejador.obtenerEstado(1).estado);
            string[] miembros = _serial.getArrayString(pMiembros);
            if (miembros.Length < 1)
                return _fabricaRespuestas.crearRespuesta(false, "Debe ingresar al menos un integrante de banda.");

            string[] canciones = _serial.getArrayString(pCanciones);
            if (canciones.Length < 3)
                return _fabricaRespuestas.crearRespuesta(false, "Error, se ingresaron menos de las 3 canciones mínimas para banda nueva. Por favor intente nuevo.");
            else if (canciones.Length > 10)
                return _fabricaRespuestas.crearRespuesta(false, "Error, se ingresaron más de 10 canciones máximas. Por favor intente con menos.");

                int[] generos = _serial.getArrayInt(pGeneros);
            if (generos.Length > 10)
                return _fabricaRespuestas.crearRespuesta(false, "Error: Se seleccionaron más del máximo de 10 géneros musicales. Por favor intente con 10 o menos.");

            //Almacena banda nueva
            try
            {
                bandas bandaNueva = _manejador.obtenerBanda(banda.Nombre);
                if (bandaNueva != null)
                    return _fabricaRespuestas.crearRespuesta(false, "Error: Banda ya existente. Por favor intente de nuevo.");

                _manejador.añadirBanda(_convertidor.updatebandas(banda), 
                                       _convertidor.updateintegrantes(miembros),
                                       _convertidor.updatecanciones(canciones),
                                       _convertidor.updateListaGeneros(generos));
                respuesta = _fabricaRespuestas.crearRespuesta(true, "Banda registrada correctamente.");
            } catch(Exception)
            {
                //Retorna respuesta de error
                respuesta = _fabricaRespuestas.crearRespuesta(false, "Fallo al ingresar banda o banda ya existente.");
                //respuesta = _fabricaRespuestas.crearRespuesta(false, "Fallo al ingresar banda o banda ya esxistente.", e.ToString());
            }

            return respuesta;
        }

        //Generar comentario de banda
        public Respuesta generarComentario(int idBand, string user, string comment, float calification)
        {
            Respuesta respuesta = null;
            try
            {
                if (_manejador.obtenerBanda(idBand) == null)
                    return _fabricaRespuestas.crearRespuesta(false, "Banda no existente. Por favor intente de nuevo.");

                Comentario comentario =
                new Comentario(0,
                            user,
                            DateTime.Now,
                            comment,
                            calification,
                            _manejador.obtenerEstado(1).estado,
                            _manejador.obtenerBanda(idBand).nombreBan);
                comentarios parseComment = _convertidor.updatecomentarios(comentario);
                if (calification < 0.0 || calification > 5.0)
                    return _fabricaRespuestas.crearRespuesta(false, "Calificación debe estar entre 0 y 5 estrellas");

                if (comment.Length > 140)
                    return _fabricaRespuestas.crearRespuesta(false, "Comentario máximo de 140 caracteres. Por favor intente de nuevo.");

                _manejador.añadirComentario(parseComment); //Almacena comentario
                respuesta = _fabricaRespuestas.crearRespuesta(true, "Comentario añadido correctamente.");
            } catch(Exception)
            {
                //Retorna error
                respuesta = _fabricaRespuestas.crearRespuesta(false, "Fallo al generar comentario.");
                //respuesta = _fabricaRespuestas.crearRespuesta(true, "Comentario añadido correctamente.", e.ToString());
            }

            return respuesta;
        }

        //Obtener catalogo de bandas
        public Respuesta getCatalogoBandas()
        {
            Respuesta respuesta = null;

            try
            {
                List<bandas> catalogoBandas = _manejador.obtenerBandas();
                bandas[] arrayCatalogoBandas = catalogoBandas.ToArray();
                Banda[] arregloBandas = new Banda[catalogoBandas.Count];

                JObject[] listaBandas = new JObject[catalogoBandas.Count];

                //Organizar bandas para envio
                int iterator = 0;
                foreach (bandas banda in catalogoBandas)
                {
                    arregloBandas[iterator] = _convertidor.createBanda(banda);
                    arregloBandas[iterator].url_image = _spotify.searchArtistImages(banda.nombreBan);
                    listaBandas[iterator] = arregloBandas[iterator].serialize();
                    iterator++;
                }

                respuesta = _fabricaRespuestas.crearRespuesta(true, listaBandas); //Retorna catalogo de bandas
            } catch(Exception)
            {
                //Retorna respuesta de error
                respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al generar catalogo de bandas.");
                //respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al generar catalogo de bandas.", e.ToString());
            }

            return respuesta;
        }

        //Obtener banda especifica
        public Respuesta getBanda(int pIDBanda)
        {
            bandas bandaQuery;
            try
            {
                //Obtener banda
                bandaQuery = _manejador.obtenerBanda(pIDBanda);
                if (bandaQuery == null)
                    return _fabricaRespuestas.crearRespuesta(false, "Banda no existente. Por favor intente de nuevo.");
            } catch(Exception)
            {
                return _fabricaRespuestas.crearRespuesta(false, "Error al obtener banda o no existe.");
                //return _fabricaRespuestas.crearRespuesta(false, "Error al obtener banda o no existe.", e.ToSring());
            }
            
            //Obtener generos musicales de banda
            List<generos> generosBandaQuery = _manejador.obtenerGenerosBanda(bandaQuery);
            GeneroMusical[] arregloGenerosBandaQuery = _convertidor.createListaGenero(generosBandaQuery);
            List<integrantes> integrantesBandaQuery = _manejador.obtenerIntegrantes(bandaQuery);
            //Lista de integrantes
            MiembroBanda[] arregloIntegrantesBandaQuery = _convertidor.createListaIntegrantes(integrantesBandaQuery);
            //Lista de canciones
            List<canciones> cancionesBandaQuery = _manejador.obtenerCanciones(bandaQuery);  
            //Lista de comentarios
            List<comentarios> comentarioBandaQuery = _manejador.obtenerComentarios(bandaQuery); //Lista de comentarios

            //Organiza datos para envio
            JObject[] generosObj = _serial.agruparGeneros(arregloGenerosBandaQuery);
            JObject[] miembrosObj = _serial.agruparMiembros(arregloIntegrantesBandaQuery);
            JObject[] cancionesObj = agruparCanciones(cancionesBandaQuery, bandaQuery.nombreBan);
            JObject[] comentariosObj = agruparComentarios(comentarioBandaQuery);
            
            dynamic band_dataObj = new JObject();
            band_dataObj.name = bandaQuery.nombreBan;
            band_dataObj.image_band = _spotify.searchArtistImages(bandaQuery.nombreBan);
            band_dataObj.calification = _manejador.getCalificacion(bandaQuery);
            band_dataObj.followers = _spotify.searchArtistFollowers(bandaQuery.nombreBan);
            band_dataObj.popularity = _spotify.searchArtistPopularity(bandaQuery.nombreBan);

            //Retorna respuesta exitosa
            Respuesta respuesta = _fabricaRespuestas.crearRespuesta(true, band_dataObj, generosObj, miembrosObj, cancionesObj, comentariosObj);

            return respuesta;
        }

        //Agrupa canciones para envio
        public JObject[] agruparCanciones(List<canciones> pLista, string artist)
        {
            JObject[] cancionesObject = new JObject[pLista.Count];
            int iterator = 0;
            foreach (canciones cancion in pLista)
            {
                cancionesObject[iterator] = new JObject();
                dynamic song = cancionesObject[iterator];
                song.song_name = cancion.cancion;
                song.url_sound_test = _spotify.searchURLTrack(artist, cancion.cancion);
                iterator++;
            }

            //Retorna canciones en JSON
            return cancionesObject;
        }

        //Agrupa comentarios para envio
        public JObject[] agruparComentarios(List<comentarios> pLista)
        {
            JObject[] comentariosObject = new JObject[pLista.Count];
            int iterator = 0;
            foreach (comentarios comentario in pLista)
            {
                comentariosObject[iterator] = new JObject();
                dynamic comentarioActual = comentariosObject[iterator];
                comentarioActual.user = _manejador.obtenerUsuario(comentario.FK_COMENTARIOS_USUARIOS).username;
                comentarioActual.date = comentario.fechaCreacion;
                comentarioActual.calification = comentario.calificacion;
                comentarioActual.commentary = comentario.comentario;
                iterator++;
            }

            //Retorna comentarios en JSON
            return comentariosObject;
        }
    }
}

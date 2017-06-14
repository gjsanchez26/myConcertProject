﻿using MyConcert_WebService.viewModels;
using MyConcert_WebService.res.resultados;
using System;
using MyConcert_WebService.res.assembler;
using Newtonsoft.Json.Linq;
using MyConcert_WebService.res.serial;
using System.Collections.Generic;
using Sptfy;

namespace MyConcert_WebService.models
{
    public class BandaModel
    {
        private ManejadorBD _manejador;
        private FabricaRespuestas _creador;
        private Assembler _convertidor;
        private SerialHelper _serial;
        private SpotifyUtils _spotify;

        public BandaModel()
        {
            _manejador = new ManejadorBD();
            _creador = new FabricaRespuestas();
            _convertidor = new Assembler();
            _serial = new SerialHelper();
            _spotify = new SpotifyUtils();
        }

        public Respuesta nuevaBanda(string pNombre, JArray pMiembros,
                                JArray pCanciones, JArray pGeneros)
        {
            Respuesta respuesta = null;
            Banda banda = new Banda(pNombre, _manejador.obtenerEstado(1).estado);
            string[] miembros = _serial.getArrayString(pMiembros);
            string[] canciones = _serial.getArrayString(pCanciones);
            int[] generos = _serial.getArrayInt(pGeneros);

            try
            {
                _manejador.añadirBanda(_convertidor.updatebandas(banda), 
                                       _convertidor.updateintegrantes(miembros),
                                       _convertidor.updatecanciones(canciones),
                                       _convertidor.updateListaGeneros(generos));
                respuesta = _creador.crearRespuesta(true, "Banda registrada correctamente.");
            } catch(Exception e)
            {
                //respuesta = _creador.crearRespuesta(false, "Fallo al ingresar banda o banda ya esxistente.");
                respuesta = _creador.crearRespuesta(false, "Fallo al ingresar banda o banda ya esxistente.", e.ToString());
            }

            return respuesta;
        }

        public Respuesta getCatalogoBandas()
        {
            Respuesta respuesta = null;

            try
            {
                List<bandas> catalogoBandas = _manejador.obtenerBandas();
                Banda[] arregloBandas = new Banda[catalogoBandas.Count];
                JObject[] listaBandas = new JObject[catalogoBandas.Count];
                int iterator = 0;
                foreach (bandas banda in catalogoBandas)
                {
                    arregloBandas[iterator] = _convertidor.createBanda(banda);
                    arregloBandas[iterator].url_image = _spotify.searchArtistImages(banda.nombreBan);
                    listaBandas[iterator] = arregloBandas[iterator].serialize();
                    iterator++;
                }

                respuesta = _creador.crearRespuesta(true, listaBandas);
            } catch(Exception e)
            {
                respuesta = _creador.crearRespuesta(false, "Error al generar catalogo de bandas.", e.ToString());
            }

            return respuesta;
        }

        public Respuesta getBanda(int pIDBanda)
        {
            bandas bandaQuery = _manejador.obtenerBanda(pIDBanda);
            Console.WriteLine(bandaQuery.nombreBan);
            List<generos> generosBandaQuery = _manejador.obtenerGenerosBanda(bandaQuery);
            GeneroMusical[] arregloGenerosBandaQuery = _convertidor.createListaGenero(generosBandaQuery);
            List<integrantes> integrantesBandaQuery = _manejador.obtenerIntegrantes(bandaQuery);
            MiembroBanda[] arregloIntegrantesBandaQuery = _convertidor.createListaIntegrantes(integrantesBandaQuery);
            List<canciones> cancionesBandaQuery = _manejador.obtenerCanciones(bandaQuery);
            List<comentarios> comentarioBandaQuery = _manejador.obtenerComentarios(bandaQuery);

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

            Respuesta respuesta = _creador.crearRespuesta(true, band_dataObj, generosObj, miembrosObj, cancionesObj, comentariosObj);

            return respuesta;
        }

        private JObject[] agruparCanciones(List<canciones> pLista, string artist)
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

            return cancionesObject;
        }

        private JObject[] agruparComentarios(List<comentarios> pLista)
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

            return comentariosObject;
        }
    }
}

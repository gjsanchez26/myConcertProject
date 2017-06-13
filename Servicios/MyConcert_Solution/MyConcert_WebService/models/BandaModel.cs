using MyConcert_WebService.viewModels;
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
                respuesta = _creador.crearRespuesta(false, "Fallo al ingresar banda o banda ya esxistente.");
                //respuesta = _creador.crearRespuesta(false, e.ToString());
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
            generosbanda generosBandaQuery = _manejador.obtenerGenerosBanda(bandaQuery.PK_bandas);
            integrantes integrandesBandaQuery = _manejador.obtenerIntegrante(bandaQuery.PK_bandas);


            return new Respuesta();
        }
    }
}

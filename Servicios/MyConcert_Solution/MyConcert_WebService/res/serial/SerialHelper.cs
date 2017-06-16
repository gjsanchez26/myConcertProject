using MyConcert_WebService.viewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace MyConcert_WebService.res.serial
{ 
    public class SerialHelper
    {
        private ManejadorBD _manejador = new ManejadorBD();

        public int[] getArrayInt(JArray pArray)
        {
            dynamic arrayInt = pArray;
            int[] lista = new int[pArray.Count];
            int iterator = 0;

            foreach (dynamic i in arrayInt)
            {
                lista[iterator] = i;
                iterator++;
            }

            return lista;
        }

        public string[] getArrayString(JArray pArray)
        {
            dynamic arrayString = pArray;
            string[] lista = new string[pArray.Count];
            int iterator = 0;

            foreach (dynamic i in arrayString)
            {
                lista[iterator] = (string) i;
                iterator++;
            }
            return lista;
        }

        public JObject[] agruparGeneros(GeneroMusical[] arreglo)
        {
            JObject[] generosString = new JObject[arreglo.Length];
            int iterator = 0;
            foreach (GeneroMusical gen in arreglo)
            {
                generosString[iterator] = JObject.FromObject(gen);
                iterator++;
            }
            return generosString;
        }

        public DateTime fecha(string pFecha)
        {
            DateTime d = DateTime.Parse(pFecha, CultureInfo.InvariantCulture);

            return d;
        }

        public string[] agruparGeneros(List<generos> pLista)
        {
            string[] generosString = new string[pLista.Count];
            int iterator = 0;
            foreach (generos gen in pLista)
            {
                generosString[iterator] = gen.genero;
                iterator++;
            }
            return generosString;
        }

        public JObject[] agruparMiembros(MiembroBanda[] pLista)
        {
            JObject[] miembrosString = new JObject[pLista.Length];
            int iterator = 0;
            foreach (MiembroBanda miembro in pLista)
            {
                miembrosString[iterator] = JObject.FromObject(miembro);
                iterator++;
            }
            return miembrosString;
        }

        public CategoriaBanda[] getArrayCategoriaBandaEvento(JArray pArray)
        {
            dynamic arrayCategoriaBandaJSON = (JArray) pArray;
            CategoriaBanda[] listaRespuesta = new CategoriaBanda[arrayCategoriaBandaJSON.Count];

            int iterator = 0;
            CategoriaBanda cat_band_serial = null;
            foreach (JObject JSON in arrayCategoriaBandaJSON)
            {
                dynamic categoriaBandaJSON = JSON;
                int[] bands = getArrayInt((JArray)categoriaBandaJSON.bands);
                cat_band_serial = new CategoriaBanda((int)categoriaBandaJSON.category, bands);
                listaRespuesta[iterator] = cat_band_serial;
                iterator++;
            }

            return listaRespuesta;
        }

        public Cartelera leerDatosCartelera(dynamic pDatosEvento)
        {
            return new Cartelera(0,
                            (string)pDatosEvento.name,
                            (string)pDatosEvento.ubication,
                            _manejador.obtenerPais((int)pDatosEvento.country).pais,
                            (DateTime)pDatosEvento.initial_date,
                            (DateTime)pDatosEvento.final_date,
                            (DateTime)pDatosEvento.vote_final_date,
                            _manejador.obtenerTipoEvento(1).tipo,
                            _manejador.obtenerEstado(1).estado);
        }

        public Festival leerDatosFestival(dynamic pDatosEvento)
        {
            return new Festival((int) pDatosEvento.event_id,
                            (string)pDatosEvento.name,
                            (string)pDatosEvento.ubication,
                            _manejador.obtenerPais((int)pDatosEvento.country).pais,
                            (DateTime)pDatosEvento.initial_date,
                            (DateTime)pDatosEvento.final_date,
                            _manejador.obtenerTipoEvento(1).tipo,
                            _manejador.obtenerEstado(1).estado,
                            (string)pDatosEvento.food,
                            (string)pDatosEvento.transport,
                            (string)pDatosEvento.services,
                            "null"); //Recomendacion del chef
        }
    }
}

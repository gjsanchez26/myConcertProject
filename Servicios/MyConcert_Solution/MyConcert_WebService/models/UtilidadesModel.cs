using MyConcert_WebService.viewModels;
using MyConcert_WebService.res.resultados;
using Newtonsoft.Json.Linq;
using System;

namespace MyConcert_WebService.models
{
    public class UtilidadesModel
    {
        private ManejadorBD _manejador;
        private FabricaRespuestas _creador;

        public UtilidadesModel()
        {
            _manejador = new ManejadorBD();
            _creador = new FabricaRespuestas();
        }

        public Respuesta getUniversidades()
        {
            Universidad[] listaUniversidades = _manejador.obtenerUniversidades();
            JObject[] arreglo = new JObject[listaUniversidades.Length];

            for (int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = JObject.FromObject(listaUniversidades[i]);
            }

            return _creador.crearRespuesta(true, arreglo);
        }

        public Respuesta getPaises()
        {
            JObject[] arreglo = null;

            try
            {
                Pais[] listaPaises = _manejador.obtenerPaises();
                arreglo = new JObject[listaPaises.Length];

                for (int i = 0; i < arreglo.Length; i++)
                {
                    arreglo[i] = JObject.FromObject(listaPaises[i]);
                }
            } catch(Exception e)
            {
                return _creador.crearRespuesta(false, e.ToString());
            }

            return _creador.crearRespuesta(true, arreglo);
        }

        public Respuesta getGenerosMusicales()
        {
            GeneroMusical[] listaGenerosMusicales = _manejador.obtenerGeneros();
            JObject[] arreglo = new JObject[listaGenerosMusicales.Length];

            for (int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = JObject.FromObject(listaGenerosMusicales[i]);
            }

            return _creador.crearRespuesta(true, arreglo);
        }
    }
}

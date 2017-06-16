using MyConcert.viewModels;
using MyConcert.res.resultados;
using Newtonsoft.Json.Linq;
using System;
using MyConcert.res.assembler;

namespace MyConcert.models
{
    public class UtilidadesModel
    {
        private ManejadorBD _manejador;
        private FabricaRespuestas _creador;
        private Assembler _convertidor;

        public UtilidadesModel()
        {
            _manejador = new ManejadorBD();
            _creador = new FabricaRespuestas();
            _convertidor = new Assembler();
        }

        public Respuesta getUniversidades()
        {
            Universidad[] listaUniversidades = _convertidor.createListaUniversidad( _manejador.obtenerUniversidades());
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
                Pais[] listaPaises = _convertidor.createListaPais(_manejador.obtenerPaises());
                arreglo = new JObject[listaPaises.Length];

                for (int i = 0; i < arreglo.Length; i++)
                {
                    arreglo[i] = JObject.FromObject(listaPaises[i]);
                }
            }
            catch (Exception e)
            {
                return _creador.crearRespuesta(false, e.ToString());
            }

            return _creador.crearRespuesta(true, arreglo);
        }

        public Respuesta getGenerosMusicales()
        {
            GeneroMusical[] listaGenerosMusicales = _convertidor.createListaGenero(_manejador.obtenerGeneros());
            JObject[] arreglo = new JObject[listaGenerosMusicales.Length];

            for (int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = JObject.FromObject(listaGenerosMusicales[i]);
            }

            return _creador.crearRespuesta(true, arreglo);
        }
    }
}

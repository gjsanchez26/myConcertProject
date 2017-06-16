using MyConcert.viewModels;
using MyConcert.resources.results;
using Newtonsoft.Json.Linq;
using System;
using MyConcert.resources.assembler;

namespace MyConcert.models
{
    public class UtilidadesModel : AbstractModel
    {
        public UtilidadesModel()
        {
            _manejador = new FacadeDB();
            _fabricaRespuestas = new FabricaRespuestas();
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

            return _fabricaRespuestas.crearRespuesta(true, arreglo);
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
                return _fabricaRespuestas.crearRespuesta(false, e.ToString());
            }

            return _fabricaRespuestas.crearRespuesta(true, arreglo);
        }

        public Respuesta getGenerosMusicales()
        {
            GeneroMusical[] listaGenerosMusicales = _convertidor.createListaGenero(_manejador.obtenerGeneros());
            JObject[] arreglo = new JObject[listaGenerosMusicales.Length];

            for (int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = JObject.FromObject(listaGenerosMusicales[i]);
            }

            return _fabricaRespuestas.crearRespuesta(true, arreglo);
        }
    }
}

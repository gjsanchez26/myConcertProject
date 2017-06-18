using MyConcert.resources.assembler;
using MyConcert.resources.results;
using MyConcert.viewModels;
using Newtonsoft.Json.Linq;
using System;

namespace MyConcert.models
{
    /**
     * Utilidades Model
     * */
    public class UtilidadesModel : AbstractModel
    {
        //Inicializa variables locales
        public UtilidadesModel()
        {
            _manejador = new FacadeDB();
            _fabricaRespuestas = new FabricaRespuestas();
            _convertidor = new Assembler();
        }

        //Obtener universidades
        public Respuesta getUniversidades()
        {
            try
            {
                //Busca universidades
                Universidad[] listaUniversidades = _convertidor.createListaUniversidad(_manejador.obtenerUniversidades());
                JObject[] arreglo = new JObject[listaUniversidades.Length];

                for (int i = 0; i < arreglo.Length; i++)
                {
                    arreglo[i] = JObject.FromObject(listaUniversidades[i]);
                }

                //Retorna información de universidades
                return _fabricaRespuestas.crearRespuesta(true, arreglo);
            }
            catch (Exception)
            {
                //Retorna mensaje de error
                return _fabricaRespuestas.crearRespuesta(false, "Error al obtener datos. Por favor intente de nuevo.");
            }
        }

        //Obtener paises
        public Respuesta getPaises()
        {
            JObject[] arreglo = null;

            try
            {
                //Busca paises
                Pais[] listaPaises = _convertidor.createListaPais(_manejador.obtenerPaises());
                arreglo = new JObject[listaPaises.Length];

                for (int i = 0; i < arreglo.Length; i++)
                {
                    arreglo[i] = JObject.FromObject(listaPaises[i]);
                }
            }
            catch (Exception)
            {
                //Retorna mensaje de error
                return _fabricaRespuestas.crearRespuesta(false, "Error al obtener datos. Por favor intente de nuevo.");
            }

            //Retorna los paises
            return _fabricaRespuestas.crearRespuesta(true, arreglo);
        }

        //Obtener generos musicales
        public Respuesta getGenerosMusicales()
        {
            try
            {
                //Busca generos musicales
                GeneroMusical[] listaGenerosMusicales = _convertidor.createListaGenero(_manejador.obtenerGeneros());
                JObject[] arreglo = new JObject[listaGenerosMusicales.Length];

                for (int i = 0; i < arreglo.Length; i++)
                {
                    arreglo[i] = JObject.FromObject(listaGenerosMusicales[i]);
                }

                //Retorna los generos musicales
                return _fabricaRespuestas.crearRespuesta(true, arreglo);
            }
            catch (Exception)
            {
                //Retorna mensaje de error
                return _fabricaRespuestas.crearRespuesta(false, "Error al obtener datos. Por favor intente de nuevo.");
            }
        }
    }
}

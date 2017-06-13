using MyConcert_WebService.objects;
using MyConcert_WebService.res.resultados;
using Newtonsoft.Json.Linq;

namespace MyConcert_WebService.models
{
    public class EventosModel
    {
        ManejadorBD _manejador = new ManejadorBD();
        FabricaRespuestas _creador = new FabricaRespuestas();

        public Respuesta getCarteleras()
        {
            Evento[] listaCarteleras = _manejador.obtenerCarteleras();
            JObject[] arreglo = new JObject[listaCarteleras.Length];

            for (int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = JObject.FromObject(listaCarteleras[i]);
            }

            return _creador.crearRespuesta(true, arreglo);
        }

        public Respuesta getFestivales()
        {
            Evento[] listaFestivales = _manejador.obtenerFestivales();
            JObject[] arreglo = new JObject[listaFestivales.Length];

            for (int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = JObject.FromObject(listaFestivales[i]);
            }

            return _creador.crearRespuesta(true, arreglo);
        }
    }
}

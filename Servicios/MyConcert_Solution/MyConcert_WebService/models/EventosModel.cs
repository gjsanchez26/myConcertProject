using MyConcert_WebService.objects;
using MyConcert_WebService.res.resultados;

namespace MyConcert_WebService.models
{
    public class EventosModel
    {
        ManejadorBD _manejador = new ManejadorBD();

        public Respuesta getCarteleras()
        {
            Evento[] listaCarteleras = _manejador.obtenerCarteleras();
            
            return new Respuesta();
        }

        public Respuesta getFestivales()
        {
            Evento[] listaFestivales = _manejador.obtenerFestivales();

            return new Respuesta();
        }
    }
}

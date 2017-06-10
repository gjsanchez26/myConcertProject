using MyConcert_WebService.database;
using MyConcert_WebService.objects;
using MyConcert_WebService.res.resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.models
{
    public class EventosModel
    {
        ManejadorBD _manejador = new ManejadorBD();

        public Respuesta getCarteleras()
        {
            Evento[] = _manejador.obtenerCarteleras();
            
            return new Respuesta();
        }

        public Respuesta getFestivales()
        {
            Evento[] = _manejador.obtenerFestivales();

            return new Respuesta();
        }
    }
}

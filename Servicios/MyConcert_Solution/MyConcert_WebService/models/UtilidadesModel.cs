using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyConcert_WebService.res.resultados;
using MyConcert_WebService.objects;

namespace MyConcert_WebService.models
{
    public class UtilidadesModel
    {
        ManejadorBD _manejador = new ManejadorBD();

        public Respuesta getUniversidades()
        {
            Universidad[] listaUniversidades = _manejador.obtenerUniversidades();



            return new Respuesta();
        }

        public Respuesta getPaises()
        {
            Pais[] listaPaises = _manejador.obtenerPaises();



            return new Respuesta();
        }

        public Respuesta getGenerosMusicales()
        {
            GeneroMusical[] listaGenerosMusicales = _manejador.obtenerGeneros();


            return new Respuesta();
        }
    }
}

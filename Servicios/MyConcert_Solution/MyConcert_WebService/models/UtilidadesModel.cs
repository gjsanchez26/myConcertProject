using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyConcert_WebService.res.resultados;

namespace MyConcert_WebService.models
{
    public class UtilidadesModel
    {
        ManejadorBD _manejador = new ManejadorBD();

        public Respuesta getUniversidades()
        {
            List<universidades> listaUniversidades = _manejador.obtenerUniversidades();



            return new Respuesta();
        }

        public Respuesta getPaises()
        {
            List<paises> listaPaises = _manejador.obtenerPaises();



            return new Respuesta();
        }

        public Respuesta getGenerosMusicales()
        {
            List<generos> listaGenerosMusicales = _manejador.obtenerGeneros();


            return new Respuesta();
        }
    }
}

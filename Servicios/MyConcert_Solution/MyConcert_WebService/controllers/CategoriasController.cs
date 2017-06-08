using MyConcert_WebService.res;
using MyConcert_WebService.res.resultados;
using Newtonsoft.Json.Linq;
using System.Web.Http.Cors;

namespace MyConcert_WebService.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoriasController
    {
        //Obtener todas las categorias disponibles.
        public JObject Get()
        {
            ResultadoObjeto respuesta = new ResultadoObjeto();

            //Solicita categorias a base de datos.
            return JObject.FromObject(respuesta); //Retorna lista con categorias.
        }

        //Obtener categorias de evento especifico.
        public JObject Get(int pIDEvento)
        {
            ResultadoObjeto respuesta = new ResultadoObjeto();

            //Solicita categorias a base de datos.
            return JObject.FromObject(respuesta); //Retorna lista de categorias.
        }

        //Crear categoria nueva.
        public JObject Post(JObject pDatosCategoria)
        {
            dynamic datosCategoria = pDatosCategoria;
            ResultadoObjeto respuesta = new ResultadoObjeto();

            //Almacena categoria en base de datos.
            return JObject.FromObject(respuesta); //Retorna objeto categoria.
        }
    }
}

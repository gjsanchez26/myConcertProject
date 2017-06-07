using MyConcert_WebService.res;
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
            Resultado respuesta = new Resultado();

            //Solicita categorias a base de datos.
            return JObject.FromObject(respuesta); //Retorna lista con categorias.
        }

        //Obtener categorias de evento especifico.
        public JObject Get(int pIDEvento)
        {
            Resultado respuesta = new Resultado();

            //Solicita categorias a base de datos.
            return JObject.FromObject(respuesta); //Retorna lista de categorias.
        }

        //Crear categoria nueva.
        public JObject Post(JObject pDatosCategoria)
        {
            dynamic datosCategoria = pDatosCategoria;
            Resultado respuesta = new Resultado();

            //Almacena categoria en base de datos.
            return JObject.FromObject(respuesta); //Retorna objeto categoria.
        }
    }
}

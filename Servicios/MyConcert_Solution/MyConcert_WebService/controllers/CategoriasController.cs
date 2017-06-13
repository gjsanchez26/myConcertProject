using MyConcert_WebService.models;
using MyConcert_WebService.res;
using MyConcert_WebService.res.resultados;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert_WebService.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoriasController : ApiController
    {
        private CategoriaModel _model = new CategoriaModel();

        //Obtener todas las categorias disponibles.
        public JObject Get()
        {
            Respuesta respuesta = null;

            respuesta = _model.getCategorias();
            
            return JObject.FromObject(respuesta); 
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
            string nombreCat = datosCategoria.name;
            Respuesta respuesta = new Respuesta();

            respuesta = _model.nuevaCategoria(nombreCat);
           
            return JObject.FromObject(respuesta); 
        }
    }
}

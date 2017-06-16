using MyConcert.models;
using MyConcert.res.resultados;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoriasController : ApiController
    {
        private CategoriaModel _model = new CategoriaModel();

        //Obtener todas las categorias disponibles.
        public JObject Get()
        {

            Respuesta respuesta = _model.getCategorias();
            
            return JObject.FromObject(respuesta); 
        }

        //Crear categoria nueva.
        public JObject Post(JObject pDatosCategoria)
        {
            dynamic datosCategoria = pDatosCategoria;
            string nombreCat = datosCategoria.name;

            Respuesta respuesta = _model.nuevaCategoria(nombreCat);
           
            return JObject.FromObject(respuesta); 
        }
    }
}

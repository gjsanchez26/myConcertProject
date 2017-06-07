using MyConcert_WebService.res;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert_WebService.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BandasController : ApiController
    {
        //Obtener todas las bandas disponibles.
        public JObject Get()
        {
            Resultado respuesta = new Resultado();

            //Solicita bandas a base de datos.
            return JObject.FromObject(respuesta); //Retorna lista con bandas.
        }

        //Obtener banda especifica.
        public JObject Get(int pIDBanda)
        {
            Resultado respuesta = new Resultado();

            //Solicita banda a base de datos.
            return JObject.FromObject(respuesta); //Retorna objeto banda.
        }

        //Crear banda nueva.
        public JObject Post(JObject pPeticion)
        {
            dynamic peticion = pPeticion;
            Resultado respuesta = new Resultado();

            //Convierte datos ingresados en Banda.
            //Almacena en base de datos.
            return JObject.FromObject(respuesta);   //Retorna objeto banda.
        }

        //Actualiza banda especifica.
        public JObject Put(JObject pPeticion)
        {
            dynamic peticion = pPeticion;
            Resultado respuesta = new Resultado();

            //Convierte datos ingresados en Banda.
            //Actualiza en base de datos.
            return JObject.FromObject(respuesta);   //Retorna estado de modificacion.
        }

        //Elimina banda especifica.
        public JObject Delete(JObject pPeticion)
        {
            dynamic peticion = pPeticion;
            Resultado respuesta = new Resultado();

            //Convierte datos ingresados en Banda.
            //Elimina en base de datos.
            return JObject.FromObject(respuesta);   //Retorna estado de eliminacion.
        }
    }
}

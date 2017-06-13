using MyConcert_WebService.res;
using MyConcert_WebService.res.resultados;
using Newtonsoft.Json.Linq;
using System.Web.Http.Cors;

namespace MyConcert_WebService.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VotacionesController
    {
        //Obtener el resultado de las votaciones en un evento especifico.
        public JObject Get(int pIDEvento)
        {
            ResultadoObjeto respuesta = new ResultadoObjeto();

            //Obtiene suma de votos 
            return JObject.FromObject(respuesta);
        }

        //Obtener el resultado de las votaciones en un evento y categoria 
        //   especifico para un usuario especifico.
        public JObject Get(string pNombreUsuario, int pIDEvento, int pIDCategoria)
        {
            ResultadoObjeto respuesta = new ResultadoObjeto();

            //Obtiene resultado de votaciones en una categoria por un usuario especifico.
            return JObject.FromObject(respuesta);
        }

        //Crear votacion nueva.
        public JObject Post(JObject pPeticion)
        {
            dynamic peticion = pPeticion;
            int IDEvento = peticion.IDEvento;
            int IDCategoria = peticion.IDCategoria;
            string nombreUsuario = peticion.nombreUsuario;

            ResultadoObjeto respuesta = new ResultadoObjeto();

            //Almacena nueva votacion en base de datos.
            return JObject.FromObject(respuesta);       //Retorna objeto votacion.
        }
    }
}

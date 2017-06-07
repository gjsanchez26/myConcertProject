using MyConcert_WebService.res;
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
            Resultado respuesta = new Resultado();

            //Obtiene suma de votos 
            return JObject.FromObject(respuesta);
        }

        //Obtener el resultado de las votaciones en un evento y categoria 
        //   especifico para un usuario especifico.
        public JObject Get(string pNombreUsuario, int pIDEvento, int pIDCategoria)
        {
            Resultado respuesta = new Resultado();

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

            Resultado respuesta = new Resultado();

            //Almacena nueva votacion en base de datos.
            return JObject.FromObject(respuesta);       //Retorna objeto votacion.
        }
    }
}

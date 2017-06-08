using MyConcert_WebService.res;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert_WebService.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EventosController : ApiController
    {
        //Obtener informacion de eventos.
        public JObject Get(string pTipoEvento)
        {
            Resultado respuesta = new Resultado();

            switch (pTipoEvento)
            {
                case "cartelera":
                    break;
                case "festival":
                    break;
                default:
                    respuesta.exito = false;
                    string error = "Tipo de evento no existente.";
                    respuesta.mensajeError = JObject.FromObject(error);
                    break;
            }
            
            //Solicita eventos a base de datos.
            return JObject.FromObject(respuesta); //Retorna lista de eventos.
        }

        //Obtener informacion de evento especifico.
        public JObject Get(int pIDEvento)
        {   
            Resultado respuesta = new Resultado();
            
            //Solicita evento a base de datos.
            return JObject.FromObject(respuesta); //Retorna objeto evento.
        }

        //Crear evento nuevo.
        public JObject Post(JObject pDatosEvento)
        {
            dynamic datosEvento = pDatosEvento;
            Resultado respuesta = new Resultado();

            //Almacena evento en base de datos.
            return JObject.FromObject(respuesta); //Retorna objeto evento.
        }

        //Actualiza evento especifico.
        public JObject Put(JObject pDatosEvento)
        {
            dynamic datosEvento = pDatosEvento;
            Resultado respuesta = new Resultado();

            //Almacena evento en base de datos.
            return JObject.FromObject(respuesta); //Retorna estado de modificacion.
        }

        //Elimina evento especifico.
        public JObject Delete(int pIDEvento)
        {
            Resultado respuesta = new Resultado();

            //Elimina evento en base de datos.
            return JObject.FromObject(respuesta); //Retorna estado de eliminacion.
        }
    }
}

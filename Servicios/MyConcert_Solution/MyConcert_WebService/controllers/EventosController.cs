using MyConcert_WebService.models;
using MyConcert_WebService.res;
using MyConcert_WebService.res.resultados;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert_WebService.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EventosController : ApiController
    {
        EventosModel _model = new EventosModel();
        FabricaRespuestas _creador = new FabricaRespuestas();

        //Obtener informacion de eventos.
        public JObject Get(string type)
        {
            Respuesta respuesta = new Respuesta();

            switch (type)
            {
                case "cartelera":
                    respuesta = _model.getCarteleras();
                    break;
                case "festival":
                    respuesta = _model.getFestivales();
                    break;
                default:
                    respuesta = _creador.crearRespuesta(false, "Tipo de evento no existente.");
                    break;
            }

            return JObject.FromObject(respuesta);
        }

        //Obtener informacion de evento especifico.
        public JObject Get(int pIDEvento)
        {   
            ResultadoObjeto respuesta = new ResultadoObjeto();
            
            //Solicita evento a base de datos.
            return JObject.FromObject(respuesta); //Retorna objeto evento.
        }

        //Crear evento nuevo.
        public JObject Post(JObject pDatosEvento)
        {
            dynamic datosEvento = pDatosEvento;
            ResultadoObjeto respuesta = new ResultadoObjeto();

            //Almacena evento en base de datos.
            return JObject.FromObject(respuesta); //Retorna objeto evento.
        }

        //Actualiza evento especifico.
        public JObject Put(JObject pDatosEvento)
        {
            dynamic datosEvento = pDatosEvento;
            ResultadoObjeto respuesta = new ResultadoObjeto();

            //Almacena evento en base de datos.
            return JObject.FromObject(respuesta); //Retorna estado de modificacion.
        }

        //Elimina evento especifico.
        public JObject Delete(int pIDEvento)
        {
            ResultadoObjeto respuesta = new ResultadoObjeto();

            //Elimina evento en base de datos.
            return JObject.FromObject(respuesta); //Retorna estado de eliminacion.
        }
    }
}

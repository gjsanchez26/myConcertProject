using MyConcert.models;
using MyConcert.resources.results;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert.controllers
{
    /**
     * Utilidades Controller
     * */
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UtilidadesController : ApiController
    {
        private UtilidadesModel _model = new UtilidadesModel();
        private FabricaRespuestas _creador = new FabricaRespuestas();

        //Obtener datos de pais, universidad o generos musicales
        public JObject Get(string data)
        {
            Respuesta respuesta = null;

            switch (data)
            {
                case "paises":  //Si necesita paises
                    respuesta = _model.getPaises();
                    break;
                case "universidades":   //Si necesita universidades
                    respuesta = _model.getUniversidades();
                    break;
                case "generos": //Si necesita generos
                    respuesta = _model.getGenerosMusicales();
                    break;
                default:    //Si no existe el tipo de dato deseado
                    respuesta = _creador.crearRespuesta(false, "Tipo de dato solicitado no se encuentra.");
                    break;
            }

            return JObject.FromObject(respuesta);
        }
    }
}

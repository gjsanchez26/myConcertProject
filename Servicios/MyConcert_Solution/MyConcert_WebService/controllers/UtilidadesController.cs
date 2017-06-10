using MyConcert_WebService.models;
using MyConcert_WebService.res;
using MyConcert_WebService.res.resultados;
using Newtonsoft.Json.Linq;
using System.Web.Http.Cors;

namespace MyConcert_WebService.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UtilidadesController
    {
        UtilidadesModel _model = new UtilidadesModel();
        FabricaRespuestas _creador = new FabricaRespuestas();

        //Obtener paises, universidades o generos segun solicitud.
        public JObject Get(string pTipoDato)
        {
            Respuesta respuesta = null;

            switch (pTipoDato)
            {
                case "paises":
                    respuesta = _model.getPaises();
                    break;
                case "universidades":
                    respuesta = _model.getUniversidades();
                    break;
                case "generos":
                    respuesta = _model.getGenerosMusicales();
                    break;
                default:
                    respuesta = _creador.crearRespuesta(false, "Tipo de dato solicitado no se encuentra.");
                    break;
            }

            return JObject.FromObject(respuesta);
        }
    }
}

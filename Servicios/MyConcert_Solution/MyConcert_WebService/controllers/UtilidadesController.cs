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

        ////Obtener paises, universidades o generos segun solicitud.
        //public JObject Get(string pTipoDato)
        //{
        //    Respuesta respuesta = null;
            
        //    switch (pTipoDato)
        //    {
        //        case "paises":
        //            respuesta = _model.getUniversidades();
        //            break;
        //        case "universidades":
        //            break;
        //        case "generos":
        //            break;
        //        default:
        //            respuesta.success = false;
        //            string error = "Tipo de dato solicitado no se encuentra.";
        //            break;
        //    }
        //    return JObject.FromObject(respuesta);
        //}
    }
}

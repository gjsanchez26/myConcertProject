using MyConcert_WebService.res;
using MyConcert_WebService.res.resultados;
using Newtonsoft.Json.Linq;
using System.Web.Http.Cors;

namespace MyConcert_WebService.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UtilidadesController
    {
        //Obtener paises, universidades o generos segun solicitud.
        public JObject Post(string pTipoDato)
        {
            ResultadoObjeto respuesta = new ResultadoObjeto();

            switch (pTipoDato)
            {
                case "paises":
                    break;
                case "universidades":
                    break;
                case "generos":
                    break;
                default:
                    respuesta.exito = false;
                    string error = "Tipo de dato solicitado no se encuentra.";
                    respuesta.contenido = JObject.FromObject(error);
                    break;
            }
            return JObject.FromObject(respuesta);
        }
    }
}

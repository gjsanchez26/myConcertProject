using MyConcert_WebService.models;
using MyConcert_WebService.res.resultados;
using Newtonsoft.Json.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert_WebService.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UtilidadesController : ApiController
    {
        private UtilidadesModel _model = new UtilidadesModel();
        private FabricaRespuestas _creador = new FabricaRespuestas();

        //Obtener paises, universidades o generos segun solicitud.
        public JObject Get(string data)
        {

            Respuesta respuesta = null;

            switch (data)
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

        //public string Post()
        //{
        //    var request = HttpContext.Current.Request;
        //    var filePath = "C:\\temp\\" + request.Headers["filename"];
        //    //using (var fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
        //    //{
        //    //    request.InputStream.CopyTo(fs);
        //    //}
        //    return "uploaded";
        //}

    }
}

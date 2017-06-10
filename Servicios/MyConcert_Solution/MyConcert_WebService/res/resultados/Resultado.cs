using Newtonsoft.Json.Linq;

namespace MyConcert_WebService.res.resultados
{
    public class ResultadoObjeto : Respuesta
    {
        public JObject content;

        public ResultadoObjeto(bool pExito, JObject pObjeto)
        {
            this.success = pExito;
            this.content = pObjeto;
        }

        public ResultadoObjeto()
        {

        }
    }
}

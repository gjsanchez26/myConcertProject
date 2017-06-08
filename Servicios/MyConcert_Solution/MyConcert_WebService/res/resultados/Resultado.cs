using Newtonsoft.Json.Linq;

namespace MyConcert_WebService.res.resultados
{
    public class ResultadoObjeto : Respuesta
    {
        public JObject contenido;

        public ResultadoObjeto(bool pExito, JObject pObjeto)
        {
            this.exito = pExito;
            this.contenido = pObjeto;
        }

        public ResultadoObjeto()
        {

        }
    }
}

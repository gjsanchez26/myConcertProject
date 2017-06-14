using Newtonsoft.Json.Linq;

namespace MyConcert_WebService.res.resultados
{
    public class ResultadoUsuario : Respuesta
    {
        public JObject user;
        public JObject[] genres;

        public ResultadoUsuario(bool pSuccess, JObject user, JObject[] genres)
        {
            this.success = pSuccess;
            this.user = user;
            this.genres = genres;
        }
    }
}

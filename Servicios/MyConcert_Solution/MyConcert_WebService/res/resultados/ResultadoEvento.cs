using Newtonsoft.Json.Linq;

namespace MyConcert.res.resultados
{
    public class ResultadoEvento : Respuesta
    {
        public JObject event_data;
        public JObject[] categories;

        public ResultadoEvento(bool pSuccess, JObject event_data, JObject[] categories)
        {
            this.success = pSuccess;
            this.event_data = event_data;
            this.categories = categories;
        }
    }
}

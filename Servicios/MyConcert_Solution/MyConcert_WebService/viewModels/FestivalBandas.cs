using Newtonsoft.Json.Linq;

namespace MyConcert_WebService.viewModels
{
    public class FestivalBandas
    {
        public JObject event_data;
        public JObject[] bands;

        public FestivalBandas(JObject event_data, JObject[] bands)
        {
            this.event_data = event_data;
            this.bands = bands;
        }
    }
}

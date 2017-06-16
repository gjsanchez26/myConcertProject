using Newtonsoft.Json.Linq;

namespace MyConcert.viewModels
{
    public class CategoriaBandaVotacion
    {
        public string category;
        public JObject[] bands;

        public CategoriaBandaVotacion(string category, JObject[] bands)
        {
            this.category = category;
            this.bands = bands;
        }
    }
}

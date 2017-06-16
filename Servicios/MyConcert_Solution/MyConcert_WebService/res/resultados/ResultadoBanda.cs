using Newtonsoft.Json.Linq;

namespace MyConcert.res.resultados
{
    public class ResultadoBanda : Respuesta
    {
        public JObject band_data;
        public JObject[] genres;
        public JObject[] members;
        public JObject[] songs;
        public JObject[] comments;

        public ResultadoBanda(bool pSuccess, JObject band_data, JObject[] genres, JObject[] members, JObject[] songs, JObject[] comments)
        {
            this.success = pSuccess;
            this.band_data = band_data;
            this.genres = genres;
            this.members = members;
            this.songs = songs;
            this.comments = comments;
        }
    }
}

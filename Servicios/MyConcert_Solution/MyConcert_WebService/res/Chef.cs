using Newtonsoft.Json.Linq;
using Sptfy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyConcert_WebService.res
{
    class Chef
    {
        private SpotifyManager _spotify;

        /**********************************************************/

        //Constructor
        public Chef()
        {
            _spotify = new SpotifyManager();
        }

        /**
         * Obtiene los ID de los artistas involucrados
         * en el algoritmo de la recomendacion del chef
         * */
        public List<string> getIDArtists(List<string> partists)
        {
            List<string> tmp = new List<string>();
            for (int i = 0; i < partists.Count; i++)
            {
                tmp.Add(_spotify.searchArtistID(partists[i]));
            }
            return tmp;

        }

        /**
         * Obtiene todos los ID de las tres canciones de cada
         * artista involucrado en el algoritmo del chef
         * */
        public List<List<string>> getIDTracks(List<string> pid_artists)
        {
            List<List<string>> id_tracks = new List<List<string>>();
            List<string> tmp = new List<string>();
            for (int i = 0; i < pid_artists.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tmp.Add(_spotify.searchTracks(pid_artists[i], j));
                }
                id_tracks.Add(tmp);
                tmp = new List<string>();
            }
            return id_tracks;
        }

        /**
         * Indice individual por cada cancion 
         * segun sus caracteristicas musicales
         * que la describen
         * */
        public float indexSong(dynamic pskills)
        {
            float resultado = ((pskills.danceability * 20) + ((pskills.tempo * 20) / 180) + (pskills.speechiness * 20) +
                (pskills.instrumentalness * 20) + (pskills.energy * 10) + (pskills.valence * 10));
            return resultado;
        }

        /**
         * Calcula el indice de cada cancion de un artista 
         * y los suma posteriormente para promediar dicha suma
         * */
        public float calculateIndex(List<string> pid_tracks)
        {
            float res = 0;
            Task<JObject> _sk;
            dynamic _skills;
            for (int i = 0; i < pid_tracks.Count; i++)
            {
                _sk = _spotify.trackFeatures(pid_tracks[i]);
                _skills = _sk.Result;
                res += indexSong(_skills);                
            }
            return (res/pid_tracks.Count);
        }

        /**
         * Valor absoluto
         * */
        public float fabs(float px)
        {
            if (px < 0)
            {
                px *= -1;
            }
            return px;
        }

        /**
         * Compara los indices de las bandas excluidas del festival
         * con el indice del festival a realizar
         * */
        public int compare(float pfest, List<float> pother_indexes)
        {
            List<float> error = new List<float>();
            for (int i = 0; i < pother_indexes.Count; i++)
            {
                error.Add(fabs(pfest - pother_indexes[i]));
            }
            float lower = error[0];
            for (int j = 0; j < error.Count; j++)
            {
                if (error[j] < lower)
                {
                    lower = error[j];
                }
            }
            int _index = 0;
            for (int z = 0; z < error.Count; z++)
            {
                if (error[z] == lower)
                {
                    _index = z;
                }
            }
            return _index;
        }

        /**
         *Algoritmo del chef para encontrar la 
         * banda recomendada de los festivales
         */
        public string chefAlgorythm(List<string> winners, List<string> other_bands)
        {
            float fest_index = 0;
            List<string> id_winners = getIDArtists(winners);
            List<string> id_other = getIDArtists(other_bands);
            
            //Las 3 canciones se obtienen de la base de datos. *******
            List<List<string>> id_winners_tracks = getIDTracks(id_winners);
            List<List<string>> id_other_tracks = getIDTracks(id_other);

            //Se calculan los indices de las bandas excluidas del festival 
            List<float> other_indexes = new List<float>();
            for (int i = 0; i < id_other_tracks.Count; i++)
            {
                other_indexes.Add(calculateIndex(id_other_tracks[i]));
                Console.WriteLine("Indice banda excluida "+i+": "+other_indexes[i]);
            }

            /**************************************************************************/

            //Se calculan los indices de cada banda ganadora en cartelera
            List<float> winners_indexes = new List<float>();
            for (int i = 0; i < id_winners_tracks.Count; i++)
            {
                winners_indexes.Add(calculateIndex(id_winners_tracks[i]));
                fest_index += winners_indexes[i];
                Console.WriteLine("Indice banda ganadora " + i + ": " + winners_indexes[i]);
            }
            //Se calcula el indice del festival 
            fest_index = (fest_index /winners_indexes.Count);
            Console.WriteLine("Indice festival: " + fest_index);
            
            //Se comparan indices para concluir banda recomendada
            int index_rec = compare(fest_index, other_indexes);
            string id_recommended = id_other[index_rec];
            Console.WriteLine("ID rec: " + id_recommended);
            return id_recommended;
        }

    }
}

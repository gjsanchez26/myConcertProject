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
        List<int> _commentsTable;

        /**********************************************************/

        //Constructor
        public Chef()
        {
            _spotify = new SpotifyManager();
        }

        public void fillCommentsTable()
        {
            _commentsTable = new List<int>();
            _commentsTable.Add(0);
            _commentsTable.Add(5);
            _commentsTable.Add(5);
            _commentsTable.Add(5);
            _commentsTable.Add(10);
            _commentsTable.Add(10);
            _commentsTable.Add(15);
            _commentsTable.Add(15);
            _commentsTable.Add(20);
            _commentsTable.Add(20);
            _commentsTable.Add(20);
            _commentsTable.Add(25);
            _commentsTable.Add(25);
            _commentsTable.Add(30);
            _commentsTable.Add(30);
            _commentsTable.Add(30);
            _commentsTable.Add(30);
            _commentsTable.Add(35);
            _commentsTable.Add(35);
            _commentsTable.Add(40);
            _commentsTable.Add(40);
            _commentsTable.Add(40);
            _commentsTable.Add(45);
            _commentsTable.Add(45);
            _commentsTable.Add(50);
            _commentsTable.Add(50);
            _commentsTable.Add(50);
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

        /***********************ALGORITMO CHEF ***************************************/

        /**
         *Algoritmo del chef para encontrar la banda recomendada 
         * de los festivales por medio de las caracteristicas de 3 canciones 
         * de cada banda que proporciona Spotify se realizan diversos
         * calculos.
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
                Console.WriteLine("Promedio otra banda "+i+": "+other_indexes[i]);
            }

            //Se calculan los indices de cada banda ganadora en cartelera
            List<float> winners_indexes = new List<float>();
            for (int i = 0; i < id_winners_tracks.Count; i++)
            {
                winners_indexes.Add(calculateIndex(id_winners_tracks[i]));
                fest_index += winners_indexes[i];
            }
            //Se calcula el indice del festival 
            fest_index = (fest_index /winners_indexes.Count);
            Console.WriteLine("Indice festival: " + fest_index);
            
            //Se comparan indices para concluir banda recomendada
            int index_rec = compare(fest_index, other_indexes);
            string id_recommended = other_bands[index_rec];
            Console.WriteLine("Banda recomendada: " + id_recommended);
            return id_recommended;
        }

        /***********************ALGORITMO CHEF ALTERNATIVO****************************/

        /**
         * calcula el promedio de comentarios de una banda 
         * segun la tabla especificada
         * */
        public int getCommentsProm(int pcomment)
        {
            fillCommentsTable();
            int tmp = 0;
            int max_comments = 26;
            for (int i = 0; i < max_comments; i++)
            {
                if (pcomment == i)
                {
                    tmp = _commentsTable[i];
                    break;
                }
            }
            return tmp;
        }

        /**
         * Calcula el promedio del rating de 
         * cada banda 
         * */
        public int getRatingProm(int pstar)
        {
            return (pstar * 10);
        }


        /**
         * Algoritmo alternativo del chef que permite realizar una recomendacion
         * de una banda extra para un festival cuando spotify no posee la suficiente
         * informacion. Por medio de los comentarios y el rating de la banda se 
         * realiza el calculo de los indices. 
         * */
        public string alternativeChefAlgorythm(List<string> winners, List<string> other_bands)
        {
            /* se pide a la base de datos la cantidad de comentarios de las bandas
                 * y el promedio de calificacion */
            /* SE HACEN LAS PETICIONES A LA DB */
            List<int> amount_comments_other = new List<int>();
            List<int> amount_stars_other = new List<int>();
            amount_comments_other.Add(24);
            amount_comments_other.Add(12);
            amount_comments_other.Add(3);
            amount_stars_other.Add(1);
            amount_stars_other.Add(3);
            amount_stars_other.Add(5);

            //Se calculan los promedios de las posibles bandas recomendadas
            List<float> other_proms = new List<float>();
            for (int i = 0; i < other_bands.Count; i++)
            {
                other_proms.Add(getCommentsProm(amount_comments_other[i]) + 
                    getRatingProm(amount_stars_other[i]));
                Console.WriteLine("promedio otra banda "+i+": "+other_proms[i]);
            }

            //Se calcula el indice del festival
            List<int> amount_comments_winners = new List<int>();
            List<int> amount_stars_winners = new List<int>();
            amount_comments_winners.Add(15);
            amount_comments_winners.Add(25);
            amount_comments_winners.Add(10);
            amount_stars_winners.Add(2);
            amount_stars_winners.Add(4);
            amount_stars_winners.Add(2);

            int fest_index = 0, tmp = 0;
            for (int i = 0; i < winners.Count; i++)
            {
                tmp = (getCommentsProm(amount_comments_winners[i]) + getRatingProm(amount_stars_winners[i]));
                fest_index += tmp;
                tmp = 0;
            }
            fest_index /= winners.Count;
            Console.WriteLine("Indice festival: " + fest_index);

            //Compara el indice del festival con los indices de las bandas a recomendar
            int index_rec = compare(fest_index, other_proms);
            string id_recommended = other_bands[index_rec];
            Console.WriteLine("Banda recomendada: " + id_recommended);

            return id_recommended;
        }        

    }
}

using MyConcert_WebService.models;
using MyConcert_WebService.res.chef;
using Newtonsoft.Json.Linq;
using Sptfy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyConcert_WebService.res
{
    class Chef
    {
        private SpotifyUtils _spotify;
        CommentsTable _commentsTable;

        /**********************************************************/

        //Constructor
        public Chef()
        {
            _spotify = new SpotifyUtils();
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
        public List<List<string>> getIDTracks(List<string> pid_artists, List<List<canciones>> songs_bands)
        {
            List<List<string>> id_tracks = new List<List<string>>();                        
            List<string> tmp = new List<string>();
            string id_track;
            for (int i = 0; i < songs_bands.Count; i++)
            {
                for (int j = 0; j < songs_bands[i].Count; j++)
                {
                    if (tmp.Count == 3)
                    {
                        break;
                    }
                    id_track = _spotify.searchTracks(pid_artists[i], songs_bands[i][j].cancion);
                    if (id_track != null)
                    {
                        tmp.Add(id_track);
                        Console.WriteLine("cosa: " + tmp[i]);
                    }
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
            int n = pid_tracks.Count;
            Task<JObject> _sk;
            dynamic _skills;
            for (int i = 0; i < pid_tracks.Count; i++)
            {
                if (pid_tracks.Count >= 3)
                {
                    _sk = _spotify.trackFeatures(pid_tracks[i]);
                    _skills = _sk.Result;
                    res += indexSong(_skills);
                }
                else
                {
                    n -= 1;
                }
            }
            if (n == 0)
            {
                return 0;
            } else
            {
               
                return (res/n);
            }
        }

        /**
         * Valor absoluto
         * */
        public double fabs(double px)
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
        public int compare(double pfest, List<double> pother_indexes)
        {
            List<double> error = new List<double>();
            for (int i = 0; i < pother_indexes.Count; i++)
            {
                error.Add(fabs(pfest - pother_indexes[i]));
            }
            double lower = error[0];
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

        /***********************ALGORITMO CHEF***************************************/

        /**
         *Algoritmo del chef para encontrar la banda recomendada 
         * de los festivales por medio de las caracteristicas de 3 canciones 
         * de cada banda que proporciona Spotify se realizan diversos
         * calculos.
         */
        public string chefAlgorythm(List<string> winners, List<string> other_bands,
            List<List<canciones>> winner_songs, List<List<canciones>> other_songs)
        {
            double fest_index = 0;
            List<string> id_winners = getIDArtists(winners);
            List<string> id_other = getIDArtists(other_bands);
            
            //Las canciones se obtienen de la base de datos
            List<List<string>> id_winners_tracks = getIDTracks(id_winners, winner_songs);
            List<List<string>> id_other_tracks = getIDTracks(id_other, other_songs);

            //Se calculan los indices de las bandas excluidas del festival 
            List<double> other_indexes = new List<double>();
            for (int i = 0; i < id_other_tracks.Count; i++)
            {
                other_indexes.Add(calculateIndex(id_other_tracks[i]));
                Console.WriteLine("Promedio otra banda "+i+": "+other_indexes[i]);
            }

            //Se calculan los indices de cada banda ganadora en cartelera
            List<double> winners_indexes = new List<double>();
            for (int i = 0; i < id_winners_tracks.Count; i++)
            {
                winners_indexes.Add(calculateIndex(id_winners_tracks[i]));
                fest_index += winners_indexes[i];
            }
            //Se calcula el indice del festival 
            if (winners_indexes.Count == 0)
            {
                fest_index = 0;
            }
            else
            {
                fest_index = (fest_index / winners_indexes.Count);
            }
            Console.WriteLine("Indice festival: " + fest_index);
            
            //Se comparan indices para concluir banda recomendada
            int index_rec = compare(fest_index, other_indexes);
            string _recommended = other_bands[index_rec];
            Console.WriteLine("Banda recomendada: " + _recommended);
            return _recommended;
        }

        /***********************ALGORITMO CHEF ALTERNATIVO****************************/

        /**
         * calcula el promedio de comentarios de una banda 
         * segun la tabla especificada
         * */
        public float getCommentsProm(float pcomment)
        {
            float tmp = 0;
            int max_comments = 26;
            for (int i = 0; i < max_comments; i++)
            {
                if (pcomment == i)
                {
                    tmp = _commentsTable.getCommentPercentage(i);
                    break;
                }
            }
            return tmp;
        }

        /**
         * Calcula el promedio del rating de 
         * cada banda 
         * */
        public float getRatingProm(float pstar)
        {
            return (pstar * 10);
        }


        /**
         * Algoritmo alternativo del chef que permite realizar una recomendacion
         * de una banda extra para un festival cuando spotify no posee la suficiente
         * informacion. Por medio de los comentarios y el rating de la banda se 
         * realiza el calculo de los indices. 
         * */
        public string alternativeChefAlgorythm(List<string> winners, List<string> other_bands,
            List<float> amount_comments_other, List<float> amount_stars_other, List<float> amount_comments_winners,
            List<float> amount_stars_winners)
        {
            _commentsTable = new CommentsTable();
           
            //Se calculan los promedios de las posibles bandas recomendadas

            List<double> other_proms = new List<double>();
            for (int i = 0; i < other_bands.Count; i++)
            {
                other_proms.Add(getCommentsProm(amount_comments_other[i]) + 
                    getRatingProm(amount_stars_other[i]));
                Console.WriteLine("promedio otra banda "+i+": "+other_proms[i]);
            }

            //Se calcula el indice del festival
            /* por medio de la cantidad de comentarios de las bandas
                 * ganadoras y el promedio de calificacion */


            float fest_index = 0, tmp = 0;
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
            string _recommended = other_bands[index_rec];
            Console.WriteLine("Banda recomendada: " + _recommended);

            return _recommended;
        }        

    }
}

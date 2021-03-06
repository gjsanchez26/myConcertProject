﻿using MyConcert.resources.services;
using MyConcert_WebService.resources.security;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/**
 * @namespace MyConcert.resources.chef
 * @brief Almacena las clases relacionadas al
 * algoritmo del chef para la recomendacion de 
 * una banda. 
 */
namespace MyConcert.resources.operations
{
    /**
     * @class Chef 
     * @brief Se encarga de encapsular todas las funcionalidades
     * y dependencias del algoritmo de recomendación del Chef.
     */
    public class Chef
    {
        private SpotifyUtils _spotify;
        private CommentsTable _commentsTable;
        private SimpleOperations _validations;

        /**********************************************************/

        //Constructor
        public Chef()
        {
            _spotify = new SpotifyUtils();
            _commentsTable = new CommentsTable();
            _validations = new SimpleOperations();
        }

        /**
         * @brief Obtiene los ID de los artistas involucrados en el algoritmo de la recomendacion del chef.
         * @param partists Lista de nombres de artistas.
         * @return Una nueva lista con los identificadores de cada artista.
         */
        public List<string> getIDArtists(List<string> partists)
        {
            string id;
            List<string> tmp = new List<string>();
            foreach(string i in partists)
            {
                id = _spotify.searchArtistID(i);
                if (id.Length != 0)
                    tmp.Add(id);
            }
            return tmp;
        }

        /**
        * @brief Obtiene los ID de las canciones de los artistas involucrados en el algoritmo de la recomendacion del chef.
        * @param pid_artists Lista de identificadores de los artistas.
        * @param songs_bands Lista que contiene las canciones de cada artista involucrado.
        * @return Una nueva lista con los identificadores de las canciones de cada artista.
        */
        public List<List<string>> getIDTracks(List<string> pid_artists, List<List<canciones>> songs_bands)
        {
            List<List<string>> id_tracks = new List<List<string>>();                        
            List<string> tmp = new List<string>();
            string id_track;
            try
            {   int i = 0;
                foreach(List<canciones> canciones in songs_bands)
                {
                    Console.WriteLine("for lista canciones"+ i);
                    foreach (canciones cancion in canciones)
                    {
                        if (_validations.isAmountItems(tmp.Count, 3)) {
                           break;
                        }
                        Console.WriteLine(pid_artists[i]);
                        Console.WriteLine(cancion.cancion);

                        id_track = _spotify.searchTracks(pid_artists[i], cancion.cancion);
                        if (id_track.Equals("No_ID"))
                        {
                            

                        }
                        else
                        {
                            tmp.Add(id_track);
                        }
                    }
                    i += 1;
                    id_tracks.Add(tmp);
                    tmp = new List<string>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }       
            return id_tracks;
        }
        /**
        * @brief Indice individual por cada cancion segun sus caracteristicas musicales que la describen.
        * @param pskills Objeto con las características de una cancion de una banda obtenidas por spotify.
        * @return Un resultado promediado mediante los valores de las caracteristicas de la cancion.
        */
        public float indexSong(dynamic pskills)
        {
            float resultado = ((pskills.danceability * 20) + ((pskills.tempo * 20) / 180) + (pskills.speechiness * 20) +
                (pskills.instrumentalness * 20) + (pskills.energy * 10) + (pskills.valence * 10));
            Console.WriteLine("dacenability: "+pskills.danceability);
            Console.WriteLine("tempo: "+pskills.tempo);
            Console.WriteLine("valence: "+pskills.valence);
            return resultado;
        }

        /**
        * @brief Calcula el indice de cada cancion de un artista y los suma posteriormente para promediar dicha suma.
        * @param pid_tracks Lista con los identificadores de las canciones de una banda.
        * @return Un resultado promediado propio de la banda.
        */
        public float calculateIndex(List<string> pid_tracks)
        {
            float res = 0;
            int n = pid_tracks.Count;
            
            Task<JObject> _sk;
            dynamic _skills;
            for (int i = 0; i < pid_tracks.Count; i++)
            {

                _sk = _spotify.trackFeatures(pid_tracks[i]);
                _skills = _sk.Result;
                res += indexSong(_skills);

            }
            return res / 3;          
            
        }

        /**
        * @brief Compara los indices de las bandas excluidas del festival con el indice del festival a realizar.
        * @param pfest Indice promediado del festival.
        * @param pother_indexes Lista de los indices promediados de las demás bandas.
        * @return Indice donde está ubicada la banda ganadora en la lista de bandas a recomendar.
        */
        public int compare(double pfest, List<double> pother_indexes)
        {
            List<double> error = new List<double>();
            for (int i = 0; i < pother_indexes.Count; i++)
            {
                error.Add(_validations.double_abs(pfest - pother_indexes[i]));
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

        private void printList(List<string> ListaBandas)
        {
            foreach (string bandaActual in ListaBandas)
            {
                Console.WriteLine(bandaActual);
            }
            Console.WriteLine("*******************************");
        }

        public void printMatriz(List<List<canciones>> matriz)
        {
            Console.WriteLine("********* CANCIONES ********");
            foreach (List<canciones> listaActual in matriz)
            {
                foreach (canciones str in listaActual)
                {
                    Console.WriteLine(str.cancion);
                }
            }
            Console.WriteLine("*******************************");
        }

        public void printMatriz(List<List<string>> matriz)
        {
            foreach (List<string> listaActual in matriz)
            {
                foreach (string str in listaActual)
                {
                    Console.WriteLine(str);
                }
            }
            Console.WriteLine("*******************************");
        }

        /***********************ALGORITMO CHEF***************************************/

        /**
         * @brief Algoritmo del chef para encontrar la banda recomendada de los festivales por medio 
         * de las caracteristicas de 3 canciones de cada banda que proporciona Spotify se realizan diversos
         * calculos.
         * @param winners Lista de bandas ganadoras dentro de una cartelera.
         * @param other_bands Lista de bandas que no están dentro del festival.
         * @param winner_songs Lista de las canciones de las bandas ganadoras.
         * @param other_songs Lista de las canciones de las demás bandas excluídas del festival.
         * @return Banda recomendada por el algoritmo del chef.
         */
        public string chefAlgorythm(List<string> winners, List<string> other_bands,
            List<List<canciones>> winner_songs, List<List<canciones>> other_songs)
        {
            Console.WriteLine("Algoritmo del Chef Principal");
            double fest_index = 0;
            List<string> id_winners = getIDArtists(winners);
            List<string> id_other = getIDArtists(other_bands);
            //Las canciones se obtienen de la base de datos
            List < List < string>> id_winners_tracks = getIDTracks(winners, winner_songs);
            List < List < string>> id_other_tracks = getIDTracks(id_other, other_songs);

            //Se calculan los indices de las bandas excluidas del festival 
            List<double> other_indexes = new List<double>();
            for (int i = 0; i < id_other_tracks.Count; i++)
            {
                Console.WriteLine("longitud lista de canciones por banda: " + id_other_tracks[i].Count);
                if (id_other_tracks[i].Count < 3)
                {
                    other_indexes.Add(0);
                }
                else
                {
                    other_indexes.Add(calculateIndex(id_other_tracks[i]));
                }
                Console.WriteLine("Promedio otra banda "+i+": "+other_indexes[i]);
            }
            //Se calculan los indices de cada banda ganadora en cartelera
            List<double> winners_indexes = new List<double>();
            int n2 = id_winners_tracks.Count;
            for (int i = 0; i < id_winners_tracks.Count; i++)
            {
                if (id_winners_tracks[i].Count < 3)
                {
                    winners_indexes.Add(0);
                    n2 -= 1;
                }
                else
                {
                    winners_indexes.Add(calculateIndex(id_winners_tracks[i]));
                }
                fest_index += winners_indexes[i];
            }
            //Se calcula el indice del festival 
            if (n2 == 0)
            {
                fest_index = 0;
                throw (new Exception());
            }
            else
            {
                fest_index = (fest_index / n2);
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
        * @brief Calcula el promedio de comentarios de una banda segun la tabla especificada.
        * @param pcomment Numero de comentarios de una banda.
        * @return El promedio del numero de comentarios de la banda.
        */
        public float getCommentsProm(float pcomment)
        {
            float tmp = 0;
            int max_comments = 25;
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
        * @brief Calcula el promedio del rating de cada banda.
        * @param pstar Numero de rating de una banda.
        * @return El promedio del rating de la banda.
        */
        public float getRatingProm(float pstar)
        {
            return (pstar * 10);
        }


        /**
        * @brief Algoritmo alternativo del chef que permite realizar una recomendacioncde una banda
        * extra para un festival cuando spotify no posee la suficiente informacion. 
        * Por medio de los comentarios y el rating de la banda se realiza el calculo de los indices. 
        * @param winners Lista de bandas ganadoras dentro de una cartelera.
        * @param other_bands Lista de bandas que no están dentro del festival.
        * @param amount_comments_other Lista del numero de comentarios de las otras bandas.
        * @param amount_stars_other Lista de los rates en los comentarios de las otras bandas.
        * @param amount_comments_winners Lista del numero de comentarios de las bandas ganadoras.
        * @param amount_stars_winners Lista de los rates en los comentarios de las bandas ganadoras.
        * @return Banda recomendada por el algoritmo del chef alternativo.
        */
        public string alternativeChefAlgorythm(List<string> winners, List<string> other_bands,
            List<float> amount_comments_other, List<float> amount_stars_other, List<float> amount_comments_winners,
            List<float> amount_stars_winners)
        {           
            //Se calculan los promedios de las posibles bandas recomendadas

            List<double> other_proms = new List<double>();
            for (int i = 0; i < other_bands.Count; i++)
            {
                other_proms.Add(getCommentsProm(amount_comments_other[i]) + 
                    getRatingProm(amount_stars_other[i]));
                Console.WriteLine("promedio otra banda "+ other_bands[i] + ": "+other_proms[i]);
            }

            /* Se calcula el indice del festival
               por medio de la cantidad de comentarios de las bandas
               ganadoras y el promedio de calificacion */

            float fest_index = 0, tmp = 0;
            for (int i = 0; i < winners.Count; i++)
            {
                tmp = (getCommentsProm(amount_comments_winners[i]) + getRatingProm(amount_stars_winners[i]));
                fest_index += tmp;
                tmp = 0;
            }
            fest_index /= winners.Count;
            Console.WriteLine("Indice festival: " + fest_index);

            string _recommended = null;
            try
            {
                //Compara el indice del festival con los indices de las bandas a recomendar
                int index_rec = compare(fest_index, other_proms);
                _recommended = other_bands[index_rec];
                Console.WriteLine("Banda recomendada: " + _recommended);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return _recommended;
        }        

    }
}

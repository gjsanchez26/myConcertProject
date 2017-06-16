﻿using MyConcert.res;
using System;
using System.Collections.Generic;

/**
 * @namespace MyConcert.models
 * @brief Almacena las clases que definen la lógica
 * entre los modulos de la base de datos y los 
 * controladores.
 */
namespace MyConcert.models
{
    /**
     * @class ChefModel
     * @brief Clase que ejecuta el algoritmo del chef 
     * junto con todas sus dependencias.
     */
    class ChefModel
    {
        /**
         * @brief Funcion que solicita dependencias y ejecuta el algoritmo del chef según los parámetros indicados. 
         * @param pwinners Lista de bandas ganadoras.
         * @param id_fest El identificador del evento a realzarse.
         */
        public string executeChefProcess(List<string> pwinners, int id_fest)
        {
            ManejadorBD _managerDB = new ManejadorBD();
            /* ALGORITMO DEL CHEF */
            Console.WriteLine("Algoritmo del Chef");
            /*se captura desde javascript al realizar la eleccion de las bandas ganadoras*/

            List<bandas> winner_bands = new List<bandas>();
            foreach (string nameBands in pwinners)
            {
                winner_bands.Add(_managerDB.obtenerBanda(nameBands));
            }
            
            eventos _evento = _managerDB.obtenerEvento(id_fest);
            List<bandas> other_bands = _managerDB.obtenerBandasNoCartelera(_evento);
            List<string> _other = getBandsNames(other_bands);
            
            /* POR MIENTRAS: winner_songs */
            List<List<canciones>> winner_songs = getAllSongsArtists(winner_bands);
            List<List<canciones>> other_songs = getAllSongsArtists(other_bands);
            
            Chef _chef = new Chef();
            try
            {
                return _chef.chefAlgorythm(pwinners, _other, other_songs, winner_songs);
                /*SE SOLICITA INFO A LA BASE DE DATOS RESPECTO A LA BANDA*/
                /*SE GENERA LA BANDA RECOMENDADA*/
            }
            catch (Exception e)
            {
                List<float> amount_comments_other = getComments(other_bands);
                List<float> amount_comments_winners = getComments(winner_bands);

                List<float> amount_stars_other = getRating(other_bands);
                List<float> amount_stars_winners = getRating(winner_bands);

                Console.WriteLine("Error: No hay suficiente informacion de las bandas en Spotify...");
                Console.WriteLine("Algoritmo del Chef alternativo");
                
                return _chef.alternativeChefAlgorythm(pwinners, _other, amount_comments_other, amount_stars_other,
                    amount_comments_winners, amount_stars_winners);
            }
        }

        /*******************************************************************/

        /**
         * Funciones que acceden a la base de datos para solicitar 
         * informacion de relevancia para la ejecucion del calculo
         * de la recomendacion del Chef para festivales
         * */

        /**
         * @brief Solicita comentarios de las bandas. 
         * @param pbands Lista de bandas.
         * @return Lista de comentarios de una banda.
         */
        public List<float> getComments(List<bandas> pbands)
        {
            ManejadorBD _managerDB = new ManejadorBD();
            List<float> _comments = new List<float>();
            for (int i = 0; i < pbands.Count; i++)
            {
                _comments.Add(_managerDB.getCantidadComentarios(pbands[i]));
            }
            return _comments;
        }

        /**
         * @brief Solicita calificaciones de las bandas. 
         * @param pbands Lista de bandas.
         * @return Lista de calificaciones de una banda.
         */
        public List<float> getRating(List<bandas> pbands)
        {
            ManejadorBD _managerDB = new ManejadorBD();
            List<float> _ratings = new List<float>();
            for (int i = 0; i < pbands.Count; i++)
            {
                _ratings.Add(_managerDB.getCalificacion(pbands[i]));
            }
            return _ratings;
        }

        /**
         * @brief Crea una lista con los nombres de las bandas.
         * @param pbands Lista de bandas.
         * @return Lista de nombres de las bandas.
         */
        public List<string> getBandsNames(List<bandas> pbands)
        {
            List<string> _band = new List<string>();
            for (int i = 0; i < pbands.Count; i++)
            {
                _band.Add(pbands[i].nombreBan);
            }
            return _band;
        }

        /**
         * @brief Obtiene las canciones de las bandas.
         * @param pbands Lista de bandas.
         * @return Lista de nombres de las canciones de las bandas.
         */
        public List<List<canciones>> getAllSongsArtists(List<bandas> pbands)
        {
            ManejadorBD _managerDB = new ManejadorBD();
            List<List<canciones>> _songs = new List<List<canciones>>();
            for (int i = 0; i < pbands.Count; i++)
            {
                _songs.Add(_managerDB.obtenerCanciones(pbands[i]));
            }
            return _songs;
        }
    }
}

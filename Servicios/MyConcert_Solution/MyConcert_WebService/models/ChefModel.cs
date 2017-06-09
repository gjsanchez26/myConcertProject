using MyConcert_WebService.res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.models
{
    class ChefModel
    {
        //Manejador de base de datos 
        private ManejadorBD _managerDB;

        public ChefModel()
        {
            _managerDB = new ManejadorBD();
        }

        
        /**
         * Funcion que solicita dependencias y ejecuta 
         * el algoritmo del chef según los parámetros indicados 
         * */

        public void executeChefProcess(List<string> pwinners, int id_fest)
        {
            /* ALGORITMO DEL CHEF */
            Console.WriteLine("Algoritmo del Chef");
            /*se captura desde javascript al realizar la eleccion de las bandas ganadoras*/
            List<bandas> winner_bands = new List<bandas>();
            List<bandas> other_bands = new List<bandas>();           

            /*    _other.Add("Janis Joplin");
                _other.Add("Jefferson Airplane");
                _other.Add("Led Zeppelin");    */
                
            eventos _evento = _managerDB.obtenerEvento(id_fest);
            other_bands = _managerDB.obtenerBandasNoCartelera(_evento);
            List<string> _other = getBandsNames(other_bands);

            /* POR MIENTRAS: winner_songs */
            List<List<canciones>> winner_songs = getAllSongsArtists(winner_bands);
            List<List<canciones>> other_songs = getAllSongsArtists(other_bands);

            Chef _chef = new Chef();
            try
            {
                string res = _chef.chefAlgorythm(pwinners, _other, other_songs, winner_songs);
                /*SE SOLICITA INFO A LA BASE DE DATOS RESPECTO A LA BANDA*/
                /*SE ENVIA LA BANDA RECOMENDADA A JAVASCRIPT*/
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: No hay suficiente informacion de las bandas en Spotify...");
                Console.WriteLine("Algoritmo del Chef alternativo");

                List<float> amount_comments_other = getComments(other_bands);
                List<float> amount_comments_winners = getComments(winner_bands);

                List<float> amount_stars_other = getRating(other_bands);
                List<float> amount_stars_winners = getRating(winner_bands);

                _chef.alternativeChefAlgorythm(pwinners, _other, amount_comments_other, amount_stars_other,
                    amount_comments_winners, amount_stars_winners);
            }
        }

        /*******************************************************************/

        /**
         * Funciones que acceden a la base de datos para solicitar 
         * informacion de relevancia para la ejecucion del calculo
         * de la recomendacion del Chef para festivales
         * */

        //Solicita comentarios de las bandas
        public List<float> getComments(List<bandas> pbands)
        {
            List<float> _comments = new List<float>();
            for (int i = 0; i < pbands.Count; i++)
            {
                _comments.Add(_managerDB.getCantidadComentarios(pbands[i]));
            }
            return _comments;
        }

        //Solicita calificaciones de las bandas
        public List<float> getRating(List<bandas> pbands)
        {
            List<float> _ratings = new List<float>();
            for (int i = 0; i < pbands.Count; i++)
            {
                _ratings.Add(_managerDB.getCalificacion(pbands[i]));
            }
            return _ratings;
        }

        //Crea una lista con los nombres de las bandas
        public List<string> getBandsNames(List<bandas> pbands)
        {
            List<string> _band = new List<string>();
            for (int i = 0; i < pbands.Count; i++)
            {
                _band.Add(pbands[i].nombreBan);
            }
            return _band;
        }
        
        //Obtiene las canciones de las bandas
        public List<List<canciones>> getAllSongsArtists(List<bandas> pbands)
        {
            List<List<canciones>> _songs = new List<List<canciones>>();
            for (int i = 0; i < pbands.Count; i++)
            {
                _songs.Add(_managerDB.obtenerCanciones(pbands[i]));
            }
            return _songs;
        }
    }
}

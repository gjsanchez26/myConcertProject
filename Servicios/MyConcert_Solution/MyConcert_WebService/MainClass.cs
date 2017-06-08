using SpotifyAPI.Web.Models;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using MyConcert_WebService.res;
using System.Collections.Generic;
using MyConcert_WebService.security;

namespace Sptfy
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            /* ALGORITMO DEL CHEF */
            /*   Console.WriteLine("Algoritmo del Chef");
               List<string> _winner = new List<string>();
               List<string> _other = new List<string>();

               _winner.Add("The Doors");
               _winner.Add("Pink Floyd");
               _winner.Add("Metallica");

               _other.Add("Janis Joplin");
               _other.Add("Jefferson Airplane");
               _other.Add("Led Zeppelin");
               Chef _chef = new Chef();

               try
               {
                   string res = _chef.chefAlgorythm(_winner, _other);
               }
               catch (Exception e)
               {
                   Console.WriteLine("Error: No hay suficiente informacion de las bandas en Spotify...");
                   Console.WriteLine("Algoritmo del Chef alternativo");
                   _chef.alternativeChefAlgorythm(_winner, _other);                
               }
               */
            /* ALGORITMO DE ENCRIPTACION */
            /*    Console.WriteLine("Encriptacion");
                SHA256Encriptation _sha = new SHA256Encriptation();
                string encrypted_str = _sha.sha256Encrypt("hola");
                Console.WriteLine("Hola encriptado: " + encrypted_str); */

            /* ESTRATEGIA 100 DOLARES */
            /*   Console.WriteLine("Estrategia de los 100 dólares");
               DolarStrategy _dolar = new DolarStrategy();
               List<int> dolar_votes = new List<int>();
               dolar_votes.Add(25);
               dolar_votes.Add(25);
               dolar_votes.Add(15);
               dolar_votes.Add(5);
               dolar_votes.Add(30);

               bool isHundred = _dolar.checkDolars(dolar_votes);
               if (isHundred)
               {
                   Console.WriteLine("Su votación está correcta...");
               }  */

            SpotifyManager sp = new SpotifyManager();
            string id = sp.searchArtistID("The Doors");
            string name = sp.searchNameTrack(id, 3);
            string track = sp.searchURLTrack(id,3);
            string album = sp.searchAlbumTrack(id, 3);
            Console.WriteLine(name);
            Console.WriteLine(track);
            Console.WriteLine(album);

            Console.ReadLine();
        }
    }

}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyConcert.resources.operations;
using MyConcert.resources.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert.resources.operations.Tests
{
    [TestClass()]
    public class ChefTests
    {
        [TestMethod()]
        public void chefAlgorythmTest()
        {
            SpotifyUtils s = new SpotifyUtils();
            string x = s.searchArtistID("Bob Marley");
            Console.WriteLine("id: " + x);
            string song = s.searchTracks("Daft Punk", "One More Time");
            Console.WriteLine("song id: " + song);

            Chef chef = new Chef();
            List<string> winners = new List<string>();
            winners.Add("Daft Punk");
            winners.Add("Porcupine Tree");
            List<string> id_winners = chef.getIDArtists(winners);
            foreach (string i in id_winners)
            {
                Console.WriteLine("id_banda" + i);
            }


            List<List<canciones>> winner_songs = new List<List<canciones>>();
            List<canciones> can1 = new List<canciones>();
            canciones can11 = new canciones();
            can11.cancion = "One More Time";
            can1.Add(can11);
            List<canciones> can2 = new List<canciones>();
            canciones can21 = new canciones();
            can21.cancion = "Trains";
            can2.Add(can21);
            winner_songs.Add(can1);
            winner_songs.Add(can2);
            List<List<string>> id_winners_tracks = chef.getIDTracks(winners, winner_songs);


            foreach (List<string> i in id_winners_tracks)
            {
                foreach (string j in i)
                {
                    Console.WriteLine("id_ song " + j);

                }
            }
            Console.ReadLine();

        }
    }
}
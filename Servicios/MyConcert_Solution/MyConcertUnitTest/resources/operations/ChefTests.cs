using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyConcert.resources.services;
using System;
using System.Collections.Generic;

namespace MyConcert.resources.operations.Tests
{
    /**
     * Test para verificar datos necesarios para la recomendacion 
     * del chef.
     * */
    [TestClass()]
    public class ChefTests
    {
        /* Arrange */
        SpotifyUtils s = new SpotifyUtils();
        Chef chef = new Chef();

        
        [TestMethod()]
        public void chefSearchIDArtistTest()
        {
            /* Act */
            string x = s.searchArtistID("Bob Marley");
            /* Assert */
            Assert.AreNotEqual(x,null);
            
        }

        [TestMethod()]
        public void chefSearchTracks()
        {
            /* Act */
            string song = s.searchTracks("Daft Punk", "One More Time");

            /* Assert */
            Assert.AreNotEqual(song, null);
        }

        [TestMethod()]
        public void chefGetTracksWinners()
        {
            /* Act */
            Chef chef = new Chef();
            List<string> winners = new List<string>();
            winners.Add("Daft Punk");
            winners.Add("Porcupine Tree");
            List<string> id_winners = chef.getIDArtists(winners);
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

            /* Act */
            List<List<string>> id_winners_tracks = chef.getIDTracks(winners, winner_songs);


            /* Assert */
            Assert.IsNotNull(id_winners_tracks);
        }
    }
}
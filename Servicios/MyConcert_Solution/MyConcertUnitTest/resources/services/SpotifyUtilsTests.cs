using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyConcert.resources.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert.resources.services.Tests
{
    [TestClass()]
    public class SpotifyUtilsTests
    {
        /**
         * @brief test para solicitar los seguidores de
         * una banda a Spotify API
         * */
        SpotifyUtils sp = new SpotifyUtils();
        [TestMethod()]
        public void searchArtistPopularityTest()
        {
            int followers = sp.searchArtistFollowers("The Doors");
            Console.WriteLine(followers);
            Assert.IsInstanceOfType(followers, typeof(int));
            Assert.AreNotEqual(followers,10);
        }
    }
}
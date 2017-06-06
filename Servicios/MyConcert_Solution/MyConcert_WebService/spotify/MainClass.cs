using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web;
using System;
using System.Text;

namespace Sptfy
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            SpotifyManager spotify_manager = new SpotifyManager();
            string search_artist = "The Doors";
            FullArtist _artist = spotify_manager.searchArtistInfo(search_artist);
            Console.WriteLine(_artist.Name);
            Console.WriteLine(_artist.Images[1].Url);
            
            FullTrack _track = spotify_manager.searchTracks(_artist.Id);
            Console.ReadLine();

        }
    }

}

using System;
using System.Text;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web;
using System.IO;
using System.Net;
using System.Net.Http;

namespace Sptfy
{
    /**
     * Clase que maneja las búsquedas en Spotify,
     * así como el almacenamiento de información relevante
     **/
    class SpotifyManager
    {
        private static SpotifyWebAPI _spotify { get; set; }
        private static ClientCredentialsAuth _auth;
        protected const string _clientID = "8ffc2dd7b0da48798e93c40a6e8594ee";
        protected const string _clientSecret = "174dd8f058614cdf85809b4fb3df340a";
        //private JsController _js;
        //private DbController _db;
        

        /*****************************************************************************/

        //Constructor
        public SpotifyManager()
        {
            //Manejador de los eventos y peticiones con spotify
            _spotify = new SpotifyWebAPI();
         //   _js = new JsController();
         //   _db = new DbController();
            askForAuth();

        }
        /**
        * Solicita el token de autorización para
        * realizar peticiones a la API de Spotify
        **/
        private void askForAuth()
        {
            _auth = new ClientCredentialsAuth()
            {
                ClientId = _clientID,
                ClientSecret = _clientSecret,
                Scope = Scope.UserReadPrivate
            };
            //Solicita token de autorizacion
            Token token = _auth.DoAuth();
            _spotify.TokenType = token.TokenType;
            _spotify.AccessToken = token.AccessToken;
            _spotify.UseAuth = true;
        }

        /**
        * Solicita datos de un artista 
        * en especifico. Retorna un objeto con toda 
        * la información de este.
        **/
        public FullArtist searchArtistInfo(string partist)
        {
            FullArtist info_artist = null;
            SearchItem item = _spotify.SearchItems(partist, SearchType.Artist);

            //Busca el dato 
            for (int i = 0; i < item.Artists.Items.Count; i++)
            {
                if (partist == item.Artists.Items[i].Name)
                {
                    info_artist = item.Artists.Items[i];
                }
            }
            return info_artist;
        }


        /**
        * Solicita datos de una cancion 
        * en especifico. Retorna un objeto con toda 
        * la información de esta.
        **/
        public FullTrack searchTracks(string pidartist)
        {
            SeveralTracks tracks = _spotify.GetArtistsTopTracks(pidartist, "CR");
            FullTrack track = _spotify.GetTrack(tracks.Tracks[0].Id);
            Console.WriteLine(track.Name);
            trackAnalysis(track.Id);
            return track;
        }

        static async void trackAnalysis(string pid)
        {    
            
        }

    }
}

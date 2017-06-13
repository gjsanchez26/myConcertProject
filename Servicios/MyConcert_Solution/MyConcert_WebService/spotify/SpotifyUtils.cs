﻿using System;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sptfy
{
    
    /**
    * @class SpotifyUtils
    * @brief  Clase que maneja las búsquedas en Spotify, así como el
    * almacenamiento de información relevante.    */
    class SpotifyUtils
    {
        private static SpotifyWebAPI _spotify { get; set; }
        private static ClientCredentialsAuth _auth;
        protected const string _clientID = "8ffc2dd7b0da48798e93c40a6e8594ee";
        protected const string _clientSecret = "174dd8f058614cdf85809b4fb3df340a";

        /*****************************************************************************/

        //Constructor
        public SpotifyUtils()
        {
            //Manejador de los eventos y peticiones con spotify
            _spotify = new SpotifyWebAPI();
            askForAuth();

        }

        
        /**
         * @brief Solicita el token de autorización para realizar peticiones a la API de Spotify.
         */
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

        /*****************************************************************/

        /**
         * @brief Solicita dato de un artista en especifico. Retorna el ID del artista de interes.
         * @param partist El nombre del artista.
         * @return El identificador del artista, segun spotify.
         */
        public string searchArtistID(string partist)
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
            return info_artist.Id;
        }
        
        
        /**
          * @brief Solicita dato de un artista en especifico. Retorna la popularidad del artista de interes.
          * @param partist El nombre del artista.
          * @return La popularidad del artista, segun spotify.
          */
        public int searchArtistPopularity(string partist)
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
            return info_artist.Popularity;
        }

        /**
      * Solicita dato de un artista 
      * en especifico. Retorna la cantidad de
      * seguidores de un artista 
      **/
        /**
        * @brief Solicita dato de un artista en especifico. Retorna la cantidad de seguidores del artista de interes.
        * @param partist El nombre del artista.
        * @return Los seguidores del artista, segun spotify.
        */
        public int searchArtistFollowers(string partist)
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
            return info_artist.Followers.Total;
        }

        
        /**
         * @brief Solicita dato de un artista en especifico. Retorna los generos del artista de interes.
         * @param partist El nombre del artista.
         * @return Lista de generos del artista, segun spotify.
         */
        public List<string> searchArtistGenres(string partist)
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
            return info_artist.Genres;
        }


        /**
          * @brief Solicita dato de un artista en especifico. Retorna una de las imagenes de un artista proporcionada por spotify.
          * @param partist El nombre del artista.
          * @return Lista de imagenes del artista, proveida por spotify.
          */
        public List<Image> searchArtistImages(string partist)
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
            return info_artist.Images;
        }


        /*****************************************************************/

        /**
        * @brief Solicita datos de una cancion en especifico. Retorna el identificador de la cancion.
        * @param partist El nombre del artista.
        * @param psong Nombre de la cancion que se quiere.
        * @return identificador de la canción.
        */
        public string searchTracks(string pidartist, string psong)
        {
            string tmp = null;
            SeveralTracks tracklist = _spotify.GetArtistsTopTracks(pidartist, "CR");
            for (int i = 0; i < tracklist.Tracks.Count; i++)
            {
                if (tracklist.Tracks[i].Name == psong)
                {
                    tmp = tracklist.Tracks[i].Id;
                    break;
                }
            }
            return tmp;
        }

        /**
        * @brief Solicita dato de una cancion en especifico. Retorna el nombre
        * @param partist El nombre del artista.
        * @param pindex indice para acceder a alguna cancion de la lista.
        * @return Nombre de la cancion.
        */
        public string searchNameTrack(string pidartist, int pindex)
        {
            SeveralTracks tracks = _spotify.GetArtistsTopTracks(pidartist, "CR");
            return tracks.Tracks[pindex].Name;
        }

        
        /**
       * @brief Solicita dato de una cancion en especifico. Retorna el URL
       * @param partist El nombre del artista.
       * @param pnametrack indice para acceder a alguna cancion de la lista.
       * @return URL de la cancion.
       */
        public string searchURLTrack(string pidartist, string pnametrack)
        {
            SeveralTracks tracks = _spotify.GetArtistsTopTracks(pidartist, "CR");
            string url = null;
            for (int i = 0; i < tracks.Tracks.Count; i++)
            {
                if (tracks.Tracks[i].Name == pnametrack)
                {
                    url = tracks.Tracks[i].PreviewUrl;
                }
            }
            return url;
        }
        
        /**
       * @brief Solicita dato de una cancion en especifico. Retorna el nombre del album al que pertenece.
       * @param partist El nombre del artista.
       * @param pnametrack indice para acceder a alguna cancion de la lista.
       * @return Album de la cancion.
       */
        public string searchAlbumTrack(string pidartist, string pnametrack)
        {
            SeveralTracks tracks = _spotify.GetArtistsTopTracks(pidartist, "CR");
            string album = null;
            for (int i = 0; i < tracks.Tracks.Count; i++)
            {
                if (tracks.Tracks[i].Name == pnametrack)
                {
                    album = tracks.Tracks[i].Album.Name;
                }
            }
            return album;
        }

         /**
         * @brief Funcion que obtiene las caracteristicas que describen una cancion por medio de Spotify.
         * Retorna un JSON con dichas caracteristicas.
         * @param pid Identificador de la cancion a evaluar.
         * @return un objeto con todas las caracteristicas de la cancion.
         */
        public async Task<JObject> trackFeatures(string pid)
        {
            //Solicita los datos de analisis de una cancion 
            using (var client = new HttpClient())
            {
                var url = "https://api.spotify.com/v1/audio-features/" + pid;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _spotify.AccessToken);
                string response = await client.GetStringAsync(url);
                JObject _data = JObject.Parse(response);
                return _data;
            }
        }
    }
}


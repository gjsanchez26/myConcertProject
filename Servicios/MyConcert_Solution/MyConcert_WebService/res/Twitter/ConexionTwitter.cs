using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.res.Twitter
{
    class ConexionTwitter
    {
        private string _consumerKey;
        private string _consumerSecret;
        private string _accessToken;
        private string _accessTokenSecret;
        private static TwitterContext _contexto;

        public ConexionTwitter(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret)
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            _accessToken = accessToken;
            _accessTokenSecret = accessTokenSecret;

            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = "6xkDbM2YckJmuORo6l8x63Chh",
                    ConsumerSecret = "G5RzCrPHHmv1sXtdJZeQKOrdDlPjLE11attPRlrqmdgm6f0bMe",
                    AccessToken = "861808810465341440-sIiLeRKb6pfvygyib1q9GVF7Hqkqs6K",
                    AccessTokenSecret = "6o0vnhse0z33we5oO1AOSxgbQckgsDbDTTTtwzIz8PbIP"
                }
            };

            _contexto = new TwitterContext(auth);
        }

        public static async Task enviarTweet(string pMensaje)
        {
            var tweet = await _contexto.TweetAsync(pMensaje);

            if (tweet != null)
            {
                Console.WriteLine("Tweet enviado.");
            } else
            {
                Console.WriteLine("Fallo al intentar enviar tweet.");
            }
        }
    }
}

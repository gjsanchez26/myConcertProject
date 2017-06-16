using LinqToTwitter;
using System;
using System.Threading.Tasks;

namespace MyConcert.resources.services
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
                    ConsumerKey = _consumerKey,
                    ConsumerSecret = _consumerSecret,
                    AccessToken = _accessToken,
                    AccessTokenSecret = _accessTokenSecret
                }
            };

            _contexto = new TwitterContext(auth);
        }

        public async Task enviarTweet(string pMensaje)
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

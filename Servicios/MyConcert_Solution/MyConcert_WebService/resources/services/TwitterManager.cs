using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert.resources.services
{
    class TwitterManager
    {
        private ConexionTwitter _conexion;

        public TwitterManager()
        {
            _conexion = new ConexionTwitter("6xkDbM2YckJmuORo6l8x63Chh",
                                            "G5RzCrPHHmv1sXtdJZeQKOrdDlPjLE11attPRlrqmdgm6f0bMe",
                                            "861808810465341440-sIiLeRKb6pfvygyib1q9GVF7Hqkqs6K",
                                            "6o0vnhse0z33we5oO1AOSxgbQckgsDbDTTTtwzIz8PbIP");


        }

        public async void enviarTweet(string mensaje)
        {
            try
            {
                await _conexion.enviarTweet(mensaje);
            } catch(Exception e)
            {
                throw (e);
            }
        }
    }
}

using System.Text;
using System.Security.Cryptography;

/**
 * @namespace MyConcert.resources.security
 * @brief Almacena las clase para establecer seguridad
 * a las contraseñas de los usuarios con el algoritmo
 * SHA256.
 */
namespace MyConcert.resources.security
{
    /**
     * @class SHA256Encriptation
     * @brief Objeto que contiene el algoritmo de 
     * seguridad para contraseñas.
     */
    public class SHA256Encriptation
    {
        /**
        * @brief Algoritmo para la encriptacion de contraseñas (seguridad). Obtenido de:
         * http://www.programadordepalo.com/access-encriptar-contrasenas-con-sha-256-utilizando-biblioteca-de-clases-net-con-c/
        * @param ppassword Contraseña para encriptar. 
        * @return Contraseña encriptada.
        */
        public string sha256Encrypt(string ppassword)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();
            byte[] inputBytes = Encoding.UTF8.GetBytes(ppassword);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }

    }
}

using System.Text;
using System.Security.Cryptography;

namespace MyConcert_WebService.security
{
    class SHA256Encriptation
    {

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

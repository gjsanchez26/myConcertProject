using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyConcert.resources.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert.resources.security.Tests
{
    [TestClass()]
    public class SHA256EncriptationTests
    {

        [TestMethod()]
        public void sha256EncryptTest()
        {
            string str_encryp = "hola";
            SHA256Encriptation _encriptation = new SHA256Encriptation();
            string resp = _encriptation.sha256Encrypt(str_encryp);

            Assert.AreNotEqual(str_encryp, resp);
        }

        [TestMethod()]
        public void sha256EncryptNullTest()
        {
            string str_encryp = "hola";
            SHA256Encriptation _encriptation = new SHA256Encriptation();
            string resp = _encriptation.sha256Encrypt(str_encryp);

            Assert.IsNotNull(resp);
        }
    }
}
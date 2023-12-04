using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbDb.Managers
{
    internal class KeyManager
    {

        public static string GetEncryptionKey()
        {
            if (File.Exists("C:\\Users\\david\\OneDrive\\Skrivbord\\key.txt"))
            {
                return File.ReadAllText("C:\\Users\\david\\OneDrive\\Skrivbord\\key.txt");
            }
            else
            {
                string key = GenerateEncryptionKey();
                File.WriteAllText("C:\\Users\\david\\OneDrive\\Skrivbord\\key.txt", key);
                return key;
            }
        }



        private static string GenerateEncryptionKey()
        {
            var rng = new RNGCryptoServiceProvider();

            var byteArray = new byte[16];

            rng.GetBytes(byteArray);

            return Convert.ToBase64String(byteArray);

        }
    }
}


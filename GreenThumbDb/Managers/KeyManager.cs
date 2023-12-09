using System.IO;
using System.Security.Cryptography;

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


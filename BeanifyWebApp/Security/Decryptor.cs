using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace BeanifyWebApp.Security
{
    public static class Decryptor
    {
        public static string Decrypt()
        {
            using (var rijAlg = Rijndael.Create())
            {
                byte[] Key = { 108, 214, 72, 143, 61, 176, 62, 43, 195, 48, 45, 143, 213, 223, 161, 183, 15, 58, 4, 129, 213, 53, 246, 209, 11, 93, 241, 229, 198, 233, 174, 205 };
                byte[] IV = { 12, 148, 67, 97, 94, 122, 28, 127, 121, 108, 45, 207, 153, 46, 43, 91 };

                rijAlg.Key = Key;
                rijAlg.IV = IV;

                string FilePath = System.Web.Hosting.HostingEnvironment.MapPath("~/EmailTemplates/EmailSecrets.txt");

                byte[] encryptText = File.ReadAllBytes(FilePath);

                string plaintext = null;

                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msDecrypt = new MemoryStream(encryptText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            //Write all data to the stream.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                        return plaintext;
                    }
                }
            }

        }
    }
}
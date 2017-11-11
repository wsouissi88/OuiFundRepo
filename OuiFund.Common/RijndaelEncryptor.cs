using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Common
{
    //encryption class
    public class RijndaelEncryptor
    {
        /// <summary>
        /// Encrypts a text using Rijndael'algo and transposes it to base64
        /// </summary>
        /// <param name="clearText">Text to encrypt</param>
        /// <param name="strKey">private key</param>
        /// <param name="strIv">initialization's string</param>
        /// <returns>Encrypted text</returns>
        public static string Encrypt(string clearText, string strKey, string strIv)
        {
            var plainText = Encoding.UTF8.GetBytes(clearText);
            var key = Encoding.UTF8.GetBytes(strKey);
            var iv = Encoding.UTF8.GetBytes(strIv);

            var rijndael = new RijndaelManaged { Mode = CipherMode.CBC };
            var aesEncryptor = rijndael.CreateEncryptor(key, iv);
            var ms = new MemoryStream();

            var cs = new CryptoStream(ms, aesEncryptor, CryptoStreamMode.Write);
            cs.Write(plainText, 0, plainText.Length);
            cs.FlushFinalBlock();

            var cipherBytes = ms.ToArray();

            ms.Close();
            cs.Close();

            return Convert.ToBase64String(cipherBytes);

        }

        /// <summary>
        /// Decrypt a Rijndael's cyphred text from base64
        /// </summary>
        /// <param name="cipherText">Encrypted text</param>
        /// <param name="strKey">private key</param>
        /// <param name="strIv">initialization's string</param>
        /// <returns>Plain text</returns>
        public static string Decrypt(string cipherText, string strKey, string strIv)
        {
            var cipheredData = Convert.FromBase64String(cipherText);
            var key = Encoding.UTF8.GetBytes(strKey);
            var iv = Encoding.UTF8.GetBytes(strIv);

            var rijndael = new RijndaelManaged { Mode = CipherMode.CBC };

            var decryptor = rijndael.CreateDecryptor(key, iv);
            var ms = new MemoryStream(cipheredData);
            var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);


            var plainTextData = new byte[cipheredData.Length];
            var decryptedByteCount = cs.Read(plainTextData, 0, plainTextData.Length);

            ms.Close();
            cs.Close();

            return Encoding.UTF8.GetString(plainTextData, 0, decryptedByteCount);
        }
    }
}

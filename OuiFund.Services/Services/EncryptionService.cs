using OuiFund.Common;
using OuiFund.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Services.Services
{
    public class EncryptionService : IEncryptionService
    {
        public string Encrypt(string clearText, string strKey, string strIv)
        {
            return RijndaelEncryptor.Encrypt(clearText, strKey, strIv);
        }

        public string Decrypt(string cipherText, string strKey, string strIv)
        {
            return RijndaelEncryptor.Decrypt(cipherText, strKey, strIv);
        }
    }
}

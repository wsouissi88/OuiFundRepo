using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Services.IServices
{
    public interface IEncryptionService
    {
        string Encrypt(string clearText, string strKey, string strIv);
        string Decrypt(string clearText, string strKey, string strIv);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;
using System.Windows.Controls;

namespace Sorozatok
{
    class Encrypt
    {
        public static string Titkosit(PasswordBox p)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(p.Password));
                return Convert.ToBase64String(data);
            }
        }
        
    }
}

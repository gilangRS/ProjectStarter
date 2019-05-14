using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    public class Password
    {
        public string Encrypt(string password)
        {
            SHA512 test = SHA512Cng.Create();
            byte[] passHash = Encoding.UTF8.GetBytes(password);
            byte[] Encrypted = test.ComputeHash(passHash);
            password = GetStringFromHash(Encrypted);
            return password;
        }

        private string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("x2"));
            }
            return result.ToString();
        }
    }
}

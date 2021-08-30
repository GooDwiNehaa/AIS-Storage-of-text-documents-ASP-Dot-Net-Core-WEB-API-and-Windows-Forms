using System;
using System.Security.Cryptography;
using System.Text;

namespace ServerDiplom.BusinessLogic
{
    public class HashData
    {
        public static string GetHash(string input)
        {
            var md5 = MD5.Create();
            var sha256 = SHA256.Create();

            var inputByte = Encoding.UTF8.GetBytes(input);

            var result = md5.ComputeHash(sha256.ComputeHash(inputByte));

            return Convert.ToBase64String(result);
        }
    }
}

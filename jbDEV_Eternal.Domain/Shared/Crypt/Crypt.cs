using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace jbDEV_Eternal.Domain.Shared.Crypt
{
    public class Crypt
    {
        public static string Encrypt(string text)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] hashBytes;
            using (HashAlgorithm hash = SHA1.Create())
                hashBytes = hash.ComputeHash(encoding.GetBytes(text));

            StringBuilder hashValue = new StringBuilder(hashBytes.Length * 2);
            foreach(byte b in hashBytes)
            {
                hashValue.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
            }

            return hashValue.ToString();
        }

        public static string ValidateCryptPass(string text)
        {
            var md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(text);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X2"));

            return sb.ToString();
        }
    }
}

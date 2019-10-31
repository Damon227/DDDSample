using System;
using System.Security.Cryptography;
using System.Text;

namespace DDDSample.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string GetMD5Hash(this string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            MD5 md5 = MD5.Create();
            byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(s));
            return hashBytes.ToPrintableString();
        }
    }
}

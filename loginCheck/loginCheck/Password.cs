using PCLCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace loginCheck
{
    public class Password
    {
        public static string makePassword(string password)
        {
            if (password.Length < 8)
            {
                return "Error: 8";
            }
            else if (!Regex.IsMatch(password, @"^[a-zA-Z0-9_]+$"))
            {
                return "Error: symbol";
            }

            return hash(password);

        }
        public static string hash(string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);
            var hasher = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha256);
            byte[] hash = hasher.HashData(data);
            return Convert.ToBase64String(hash);

        }
    }
}
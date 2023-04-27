using System.Text;
using XSystem.Security.Cryptography;

namespace DiplomApplication.Logic
{
    internal static class PasswordHash
    {
        internal static string GetHashCode(string password)
        {

            byte[] bytes = Encoding.Unicode.GetBytes(password);

            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();

            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }
    }
}

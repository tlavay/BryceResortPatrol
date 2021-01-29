using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BryceResortPatrol.Common.Services.Helpers
{
    internal static class HashHelper
    {
        public static byte[] GetHash(string password, string salt)
        {
            var unhashedBytes = Encoding.Unicode.GetBytes($"{salt}_{password}");
            var sha256Managed = new SHA256Managed();
            return sha256Managed.ComputeHash(unhashedBytes);
        }

        public static bool CompareHash(string storedPasswordHash, string attemptedPassword, string salt)
        {
            var base64AttemptedHash = Convert.ToBase64String(GetHash(attemptedPassword, salt));
            return storedPasswordHash == base64AttemptedHash;
        }
    }
}

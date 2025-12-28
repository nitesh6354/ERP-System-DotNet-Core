using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ERP.Infrastructure.Security
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            // Generate random salt
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);

            // Create hash
            string hashed = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8));

            // Store salt + hash together
            return $"{Convert.ToBase64String(salt)}.{hashed}";
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split('.');
            if (parts.Length != 2) return false;

            byte[] salt = Convert.FromBase64String(parts[0]);
            string hash = parts[1];

            string computedHash = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8));

            return hash == computedHash;
        }
    }
}

//Password hashing is one-way.
//Verification is done by re-hashing and comparing.
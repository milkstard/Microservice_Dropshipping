using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace AccountsService.Helper
{
    public class PasswordSaltAndHashHelper
    {
        public static string HashPassword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(128 / 8);

            string hashed = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8)
                );

            return hashed;
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash, byte[] storedSalt)
        {
            var enteredHash = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: enteredPassword,
                    salt: storedSalt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8)
                );

            return storedHash == enteredHash;
        }
    }
}

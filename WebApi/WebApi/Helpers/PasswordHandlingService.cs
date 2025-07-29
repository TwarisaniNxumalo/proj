using System.Security.Cryptography;
using System.Text;

namespace WebApi.Helpers
{
    public class PasswordHandlingService
    {
        public static (string hash, string salt) HashPassword(string password)
        {
           
            byte[] saltBytes = new byte[16];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            
            using var sha256 = SHA256.Create();
            byte[] combinedBytes = saltBytes.Concat(Encoding.UTF8.GetBytes(password)).ToArray();
            byte[] hashBytes = sha256.ComputeHash(combinedBytes);

          
            return (Convert.ToBase64String(hashBytes), Convert.ToBase64String(saltBytes));
        }


        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            byte[] saltBytes = Convert.FromBase64String(storedSalt);
            byte[] combinedBytes = saltBytes.Concat(Encoding.UTF8.GetBytes(enteredPassword)).ToArray();

            using var sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(combinedBytes);

            return Convert.ToBase64String(hashBytes) == storedHash;
        }

    }
}

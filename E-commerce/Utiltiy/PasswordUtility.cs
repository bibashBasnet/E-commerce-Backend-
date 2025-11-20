using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace E_commerce.Utiltiy
{
    public class PasswordUtility
    {
        public static string HashPassword(string password)
        {
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashPassword;
        }

        public static bool VerifyPassword(string password, string hash) 
        {
            bool isVerified = BCrypt.Net.BCrypt.Verify(password, hash);
            return isVerified;
        }
    }
}

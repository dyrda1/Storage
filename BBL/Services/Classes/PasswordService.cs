using BLL.Services.Interfaces;
using System.Text;
using System.Security.Cryptography;

namespace BLL.Services.Classes
{
    public class PasswordService : IPasswordService
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computerHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computerHash.Length; i++)
                {
                    if (passwordHash[i] != computerHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}

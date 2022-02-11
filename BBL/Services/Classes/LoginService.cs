using AutoMapper;
using BBL.BusinessModels;
using BBL.DTO;
using BBL.Services.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Services.Classes
{
    public class LoginService : ILoginService
    {
        private readonly ApplicationContext _context;
        private readonly IAuthenticateService _authenticate;

        public LoginService(ApplicationContext context, IAuthenticateService authenticate)
        {
            _context = context;
            _authenticate = authenticate;
        }

        public async Task<Response<string>> Login(UserDTO userDTO)
        {
            var response = new Response<string>();

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userDTO.Email);
            if (user == null)
            {
                response.Message = "User not found";
                response.Success = false;
            }
            else if (!VerifyPasswordHash(userDTO.Password, user.PasswordHash, user.PasswordSalt))
            {
                response.Message = "Wrong password";
                response.Success = false;
            }
            else
            {
                response.Data = _authenticate.CreateToken(user);
            }
            return response;
        }

        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
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

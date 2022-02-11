using AutoMapper;
using BBL.BusinessModels;
using BBL.DTO;
using BBL.Services.Interfaces;
using BLL.Services.Classes;
using BLL.Services.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BBL.Services.Classes
{
    public class LoginService : ILoginService
    {
        private readonly ApplicationContext _context;
        private readonly IAuthenticateService _authenticate;
        private readonly IPasswordService _passwordHash;

        public LoginService(ApplicationContext context, IAuthenticateService authenticate, IPasswordService passwordHash)
        {
            _context = context;
            _authenticate = authenticate;
            _passwordHash = passwordHash;
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
            else if (!_passwordHash.VerifyPasswordHash(userDTO.Password, user.PasswordHash, user.PasswordSalt))
            {
                response.Message = "User not found";
                response.Success = false;
            }
            else
            {
                response.Data = _authenticate.CreateToken(user);
            }
            return response;
        }
    }
}

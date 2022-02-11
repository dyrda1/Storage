using AutoMapper;
using BBL.BusinessModels;
using BBL.DTO;
using BBL.Services.Interfaces;
using BLL.Services.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BBL.Services.Classes
{
    public class RegisterService : IRegisterService
    {
        private readonly ApplicationContext _context;
        //private readonly IAuthenticateService _authenticate;
        private readonly IPasswordService _passwordHash;

        public RegisterService(ApplicationContext context, /*IAuthenticateService authenticate,*/ IPasswordService passwordHash)
        {
            _context = context;
            //_authenticate = authenticate;
            _passwordHash = passwordHash;
        }

        public async Task<Response<Guid>> Register(UserDTO userDTO)
        {
            var response = new Response<Guid>();

            var exist = await _context.Users.AnyAsync(x => x.Email == userDTO.Email);
            if (exist)
            {
                response.Message = "User alredy exists";
                response.Success = false;
                return response;
            }

            _passwordHash.CreatePasswordHash(userDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User() 
            { 
                Email = userDTO.Email, 
                PasswordHash = passwordHash, 
                PasswordSalt = passwordSalt 
            };

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            response.Data = user.Id;
            return response;
        }
    }
}
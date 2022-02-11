using BBL.BusinessModels;
using BBL.DTO;
using BBL.Services.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Services.Classes
{
    public class RegisterService : IRegisterService
    {
        private readonly ApplicationContext _context;

        public RegisterService(ApplicationContext context)
        {
            _context = context;
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

            CreatePasswordHash(userDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);
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

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
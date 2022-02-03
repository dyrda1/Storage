using AutoMapper;
using BBL.AuthorizationModels;
using BBL.DTO;
using BBL.Services.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Services.Classes
{
    class LoginService : ILoginService
    {
        private ApplicationContext _context;
        private IAuthenticateService _authenticate;

        public LoginService(ApplicationContext context, IAuthenticateService authenticate)
        {
            _context = context;
            _authenticate = authenticate;
        }

        public async Task<ClaimsIdentity> Login(LoginModel model)
        {
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

            var userDTO = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper().Map<User, UserDTO>(user);

            if (userDTO != null)
            {
                return _authenticate.Authenticate(userDTO);
            }

            return null;
        }
    }
}

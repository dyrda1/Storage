using AutoMapper;
using BBL.AuthorizationModels;
using BBL.DTO;
using BBL.Services.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BBL.Services.Classes
{
    class LoginService : ILoginService
    {
        private readonly ApplicationContext _context;
        private readonly IAuthenticateService _authenticate;

        public LoginService(ApplicationContext context, IAuthenticateService authenticate)
        {
            _context = context;
            _authenticate = authenticate;
        }

        public async Task<ClaimsIdentity> Login(LoginModel model)
        {
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

            var userDTO = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper().Map<User, UserDTO>(user);

            if (userDTO == null)
            {
                return null;
            }

            return _authenticate.Authenticate(userDTO);
        }
    }
}

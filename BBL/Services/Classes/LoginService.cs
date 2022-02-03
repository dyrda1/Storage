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
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        private readonly IAuthenticateService _authenticate;


        public LoginService(ApplicationContext context, IAuthenticateService authenticate, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _authenticate = authenticate;
        }

        public async Task<ClaimsIdentity> Login(LoginModel model)
        {
            User user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

            var userDTO = _mapper.Map<UserDTO>(user);

            if (userDTO == null)
            {
                return null;
            }

            return _authenticate.Authenticate(userDTO);
        }
    }
}

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
    class RegisterService : IRegisterService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        private readonly IAuthenticateService _authenticate;

        public RegisterService(ApplicationContext context, IAuthenticateService authenticate, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _authenticate = authenticate;
        }

        public async Task<ClaimsIdentity> Register(RegisterModel model)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

            if (user != null)
            {
                return null;
            }

            user = new User { Email = model.Email, Password = model.Password };
            user.Role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var userDTO = _mapper.Map<UserDTO>(user);

            return _authenticate.Authenticate(userDTO);
        }
    }
}
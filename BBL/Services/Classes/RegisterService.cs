using AutoMapper;
using BBL.AuthorizationModels;
using BBL.BusinessModels;
using BBL.DTO;
using BBL.Services.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BBL.Services.Classes
{
    public class RegisterService : IRegisterService
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

        public async Task<Response<ClaimsIdentity>> Register(RegisterModel model)
        {
            var response = new Response<ClaimsIdentity>();

            User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

            if (user != null)
            {
                response.Message = "User with this Email already exists";
                response.Success = false;

                return response;
            }

            user = new User { Email = model.Email, Password = model.Password };
            user.Role = await _context.Roles.FirstAsync(r => r.Name == "employer");

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            response.Data = _authenticate.Authenticate(_mapper.Map<UserDTO>(user));

            return response;
        }
    }
}
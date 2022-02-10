//using AutoMapper;
//using BBL.AuthorizationModels;
//using BBL.BusinessModels;
//using BBL.DTO;
//using BBL.Services.Interfaces;
//using DAL;
//using DAL.Entities;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace BBL.Services.Classes
//{
//    public class LoginService : ILoginService
//    {
//        private readonly IMapper _mapper;
//        private readonly ApplicationContext _context;
//        private readonly IAuthenticateService _authenticate;


//        public LoginService(ApplicationContext context, IAuthenticateService authenticate, IMapper mapper)
//        {
//            _mapper = mapper;
//            _context = context;
//            _authenticate = authenticate;
//        }

//        public async Task<Response<ClaimsIdentity>> Login(LoginModel model)
//        {
//            var response = new Response<ClaimsIdentity>();

//            User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
            
//            if (user == null)
//            {
//                response.Message = "User with this password and email does not exist";
//                response.Success = false;

//                return response;
//            }

//            response.Data = _authenticate.Authenticate(_mapper.Map<UserDTO>(user));

//            return response;
//        }
//    }
//} TODO: hier

using AutoMapper;
using BBL.BusinessModels;
using BBL.DTO;
using BBL.Services.Interfaces;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBL.Services.Classes
{
    public class AdminService : IAdminService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public AdminService(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Response<List<UserDTO>>> DeleteUser(UserDTO userDTO)
        {
            var response = new Response<List<UserDTO>>();

            var user = _context.Users.FirstOrDefault(x => x.Password == userDTO.Password && x.Email == userDTO.Email);

            if (user == null)
            {
                response.Message = "User with this password and email does not exist";
                response.Success = false;

                return response;
            }

            var mark = _context.SkippeddDays.FirstOrDefault(x => x.User.Password == userDTO.Password && x.User.Email == userDTO.Email);

            if (mark.Amount < 5)
            {
                response.Message = "User has less than 5 skipped days";
                response.Success = false;

                return response;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<List<UserDTO>>(_context.Users.ToList());

            return response;
        }

        public Response<List<SkippedDaysDTO>> GetUsersSkippedDays()
        {
            var response = new Response<List<SkippedDaysDTO>>()
            {
                Data = _mapper.Map<List<SkippedDaysDTO>>(_context.SkippeddDays.ToList())
            };

            return response;
        }

        public Response<List<ReportDTO>> GetReports()
        {
            var response = new Response<List<ReportDTO>>()
            {
                Data = _mapper.Map<List<ReportDTO>>(_context.Reports.ToList())
            };

            return response;
        }
    }
}

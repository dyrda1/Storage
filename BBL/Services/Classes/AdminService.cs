using AutoMapper;
using BBL.BusinessModels;
using BBL.DTO;
using BBL.Services.Interfaces;
using BLL.DTO;
using DAL;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Response<List<UserDTO>>> DeleteUser(string email)
        {
            var response = new Response<List<UserDTO>>();

            if (!_context.Users.Any(x => x.Email == email))
            {
                response.Message = "User not exists";
                response.Success = false;
                return response;
            }

            var mark = _context.SkippeddDays.FirstOrDefault(x => x.User.Email == email);

            if (mark.Amount < 5)
            {
                response.Message = "User has less than 5 skipped days";
                response.Success = false;
                return response;
            }

            _context.Users.Remove(mark.User);
            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<List<UserDTO>>(await _context.Users.ToListAsync());

            return response;
        }

        public async Task<Response<List<GetSkippedDaysDTO>>> GetUsersSkippedDays()
        {
            var response = new Response<List<GetSkippedDaysDTO>>()
            {
                Data = _mapper.Map<List<GetSkippedDaysDTO>>(await _context.SkippeddDays.ToListAsync())
            };

            return response;
        }

        public async Task<Response<List<ReportDTO>>> GetReports()
        {
            var response = new Response<List<ReportDTO>>()
            {
                Data = _mapper.Map<List<ReportDTO>>(await _context.Reports.ToListAsync())
            };

            return response;
        }
    }
}

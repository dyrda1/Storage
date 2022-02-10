using AutoMapper;
using BBL.BusinessModels;
using BBL.DTO;
using BBL.Services.Interfaces;
using DAL;
using DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace BBL.Services.Classes
{
    public class MarkService : IMarkService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public MarkService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<SkippedDaysDTO>> Mark(UserDTO userDTO)
        {
            var response = new Response<SkippedDaysDTO>();

            var user = _context.Users.FirstOrDefault(x => x.Password == userDTO.Password && x.Email == userDTO.Email);

            if (user == null)
            {
                response.Message = "User with this password and email does not exist";
                response.Success = false;

                return response;
            }

            var mark = _context.SkippeddDays.FirstOrDefault(x => x.User.Password == userDTO.Password && x.User.Email == userDTO.Email);

            if (mark == null)
            {
                mark = new SkippedDays() { UserId = user.Id, MarkedToday = true };
                await _context.SkippeddDays.AddAsync(mark);
            }

            mark.MarkedToday = true;
            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<SkippedDaysDTO>(mark);

            return response;
        }
    }
}

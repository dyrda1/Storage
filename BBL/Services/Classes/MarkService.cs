using AutoMapper;
using BBL.BusinessModels;
using BBL.DTO;
using BBL.Services.Interfaces;
using DAL;
using DAL.Entities;
using System;
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

        public async Task<Response<SkippedDaysDTO>> Mark(Guid id)
        {
            var response = new Response<SkippedDaysDTO>();

            var mark = _context.SkippeddDays.FirstOrDefault(x => x.Id == id);

            if (mark == null)
            {
                mark = new SkippedDays() { UserId = id, MarkedToday = true };
                await _context.SkippeddDays.AddAsync(mark);
            }

            mark.MarkedToday = true;
            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<SkippedDaysDTO>(mark);

            return response;
        }
    }
}

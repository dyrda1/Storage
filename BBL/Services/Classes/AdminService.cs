using AutoMapper;
using BBL.BusinessModels;
using BBL.DTO;
using BBL.Services.Interfaces;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BBL.Services.Classes
{
    class AdminService : IAdminService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public AdminService(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public Response<List<ReportDTO>> GetReports()
        {
            var response = new Response<List<ReportDTO>>()
            {
                Data = _mapper.Map<List<ReportDTO>>(_context.Products.ToList())
            };

            return response;
        }

        //TODO: method to see employees' passes

        //TODO: method for firing employees
    }
}

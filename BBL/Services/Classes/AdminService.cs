using AutoMapper;
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

        public List<ReportDTO> GetReports()
        {
            var reports = _context.Reports.ToList();
            return _mapper.Map<List<ReportDTO>>(reports);
        }

        //TODO: method to see employees' passes

        //TODO: method for firing employees
    }
}

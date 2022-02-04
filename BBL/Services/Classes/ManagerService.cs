using AutoMapper;
using BBL.DTO;
using BBL.Services.Interfaces;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBL.Services.Classes
{
    public class ManagerService : IManagerService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        private readonly IInitializeReportService _initialize;

        public async Task<ReportDTO> Create(DateTime dateFrom, DateTime dateTo)
        {
            var report = new Report();

            report.Time = _initialize.GetTime(dateFrom, dateTo);
            report.Sum = _initialize.GetSum(dateFrom, dateTo);
            report.Amount = _initialize.GetAmount(dateFrom, dateTo);

            var products = _initialize.GetProducts(dateFrom, dateTo);
            report.Products = _mapper.Map<List<Product>>(products);

            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();

            report = _context.Reports.Last();

            return _mapper.Map<ReportDTO>(report);
        }

        public ManagerService(ApplicationContext context, IMapper mapper, IInitializeReportService initialize)
        {
            _mapper = mapper;
            _context = context;
            _initialize = initialize;
        }
    }
}

using AutoMapper;
using BBL.DTO;
using BBL.Services.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBL.Services.Classes
{
    public class InitializeReportService : IInitializeReportService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public InitializeReportService(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public string GetTime(DateTime dateFrom, DateTime dateTo)
        {
            return dateFrom.Date + " - " + dateTo.Date;
        }

        public async Task<List<ProductDTO>> GetProducts(DateTime dateFrom, DateTime dateTo)
        {
            var productsDTO = new List<ProductDTO>();

            var orders = await _context.Orders.Where(o => o.Date >= dateFrom && o.Date <= dateTo).ToListAsync();

            foreach (var order in orders)
            {
                productsDTO.AddRange(_mapper.Map<List<ProductDTO>>(order.Products));
            }

            return productsDTO;
        }

        public async Task<int> GetAmount(DateTime dateFrom, DateTime dateTo)
        {
            var products = await GetProducts(dateFrom, dateTo);
            return products.Count;
        }

        public async Task<decimal> GetSum(DateTime dateFrom, DateTime dateTo)
        {
            var products = await GetProducts(dateFrom, dateTo);
            return products.Select(x => x.Price).Sum();
        }
    }
}

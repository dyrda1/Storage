using AutoMapper;
using BBL.DTO;
using BBL.Services.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<ProductDTO> GetProducts(DateTime dateFrom, DateTime dateTo) //TODO: repeat parameters?
        {
            var productsDTO = new List<ProductDTO>();

            var orders = _context.Orders.Where(o => o.Date >= dateFrom && o.Date <= dateTo);

            foreach (var order in orders)
            {
                var orderProductsDTO = _mapper.Map<List<ProductDTO>>(order.Products);
                productsDTO.AddRange(orderProductsDTO);
            }

            return productsDTO;
        }

        public int GetAmount(DateTime dateFrom, DateTime dateTo)
        {
            return GetProducts(dateFrom, dateTo).Count;
        }

        public decimal GetSum(DateTime dateFrom, DateTime dateTo)
        {
            return GetProducts(dateFrom, dateTo).Select(x => x.Price).Sum();
        }
    }
}

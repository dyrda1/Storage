using AutoMapper;
using BBL.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BBL.BusinessModels
{
    class Report
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        private DateTime _dateFrom { get; set; }
        private DateTime _dateTo { get; set; }

        public Guid id { get; set; }
        
        public string GetTime(DateTime dateFrom, DateTime dateTo)
        {
            return dateFrom.Date + " - " + dateTo.Date;
        }

        public List<ProductDTO> GetProducts()
        {
            var productsDTO = new List<ProductDTO>();

            var orders = _context.Orders.Where(o => o.Date >= _dateFrom && o.Date <= _dateTo);

            foreach (var order in orders)
            {
                var orderProductsDTO = order.Products.Select(p => _mapper.Map<ProductDTO>(p));
                productsDTO.AddRange(orderProductsDTO);
            }

            return productsDTO;
        }

        public int GetCount()
        {
            return GetProducts().Count;
        }

        public decimal GetSum()
        {
            return GetProducts().Select(x => x.Price).Sum();
        }

        public Report(ApplicationContext context, IMapper mapper) //TODO: constructor injection with contstructor with parameters?
        {
            _mapper = mapper;
            _context = context;
        }

        public Report(DateTime dateFrom, DateTime dateTo)
        {
            _dateFrom = dateFrom;
            _dateTo = dateTo;
        }
    }
}

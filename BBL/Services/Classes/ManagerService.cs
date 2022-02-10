﻿using AutoMapper;
using BBL.BusinessModels;
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

        public ManagerService(ApplicationContext context, IMapper mapper, IInitializeReportService initialize)
        {
            _mapper = mapper;
            _context = context;
            _initialize = initialize;
        }

        public async Task<Response<ReportDTO>> Create(DateTime dateFrom, DateTime dateTo)
        {
            var response = new Response<ReportDTO>();

            var report = new Report
            {
                Time = _initialize.GetTime(dateFrom, dateTo),
                Sum = _initialize.GetSum(dateFrom, dateTo),
                Amount = _initialize.GetAmount(dateFrom, dateTo)
            };

            List<ProductDTO> products = _initialize.GetProducts(dateFrom, dateTo);

            if (products.Count == 0)
            {
                response.Message = "No products have been sold during this time";
                response.Success = false;

                return response;
            }

            response.Data = _mapper.Map<ReportDTO>(report);
            report.Products = _mapper.Map<List<Product>>(products);

            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();
                        
            return response;
        }
    }
}

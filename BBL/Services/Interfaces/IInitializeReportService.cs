using BBL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BBL.Services.Interfaces
{
    public interface IInitializeReportService
    {
        string GetTime(DateTime dateFrom, DateTime dateTo);

        Task<List<ProductDTO>> GetProducts(DateTime dateFrom, DateTime dateTo);

        Task<int> GetAmount(DateTime dateFrom, DateTime dateTo);

        Task<decimal> GetSum(DateTime dateFrom, DateTime dateTo);
    }
}

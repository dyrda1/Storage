using BBL.DTO;
using System;
using System.Collections.Generic;

namespace BBL.Services.Interfaces
{
    public interface IInitializeReportService
    {
        string GetTime(DateTime dateFrom, DateTime dateTo);

        List<ProductDTO> GetProducts(DateTime dateFrom, DateTime dateTo);

        int GetAmount(DateTime dateFrom, DateTime dateTo);

        decimal GetSum(DateTime dateFrom, DateTime dateTo);    
    }
}

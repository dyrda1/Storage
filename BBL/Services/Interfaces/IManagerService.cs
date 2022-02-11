using BBL.BusinessModels;
using BBL.DTO;
using System;
using System.Threading.Tasks;

namespace BBL.Services.Interfaces
{
    public interface IManagerService
    {
        Task<Response<ReportDTO>> Create(DateTime dateFrom, DateTime dateTo);
    }
}

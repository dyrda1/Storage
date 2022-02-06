using BBL.BusinessModels;
using BBL.DTO;
using System.Collections.Generic;

namespace BBL.Services.Interfaces
{
    public interface IAdminService
    {
        Response<List<ReportDTO>> GetReports();
    }
}

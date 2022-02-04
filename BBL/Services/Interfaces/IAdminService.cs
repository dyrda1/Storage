using BBL.DTO;
using System.Collections.Generic;

namespace BBL.Services.Interfaces
{
    public interface IAdminService
    {
        List<ReportDTO> GetReports();
    }
}

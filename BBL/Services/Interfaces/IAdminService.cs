using BBL.BusinessModels;
using BBL.DTO;
using BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BBL.Services.Interfaces
{
    public interface IAdminService
    {
        Task<Response<List<ReportDTO>>> GetReports();

        Task<Response<List<GetSkippedDaysDTO>>> GetUsersSkippedDays();

        Task<Response<List<UserDTO>>> DeleteUser(string email);
    }
}

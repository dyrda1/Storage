using BBL.BusinessModels;
using BBL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BBL.Services.Interfaces
{
    public interface IAdminService
    {
        Response<List<ReportDTO>> GetReports();

        Response<List<SkippedDaysDTO>> GetUsersSkippedDays();

        Task<Response<List<UserDTO>>> DeleteUser(UserDTO userDTO);
    }
}

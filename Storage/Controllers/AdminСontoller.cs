using BBL.BusinessModels;
using BBL.DTO;
using BBL.Services.Interfaces;
using BLL.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Storage.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminСontoller
    {
        private readonly IAdminService _adminService;

        public AdminСontoller(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        [Route("GetReports")]
        public async Task<ActionResult<Response<List<ReportDTO>>>> GetReports()
        {
            return await _adminService.GetReports();
        }

        [HttpGet]
        [Route("GetUsersSkippedDays")]
        public async Task<ActionResult<Response<List<GetSkippedDaysDTO>>>> GetUsersSkippedDays()
        {
            return await _adminService.GetUsersSkippedDays();
        }

        [HttpDelete]
        public async Task<ActionResult<Response<List<UserDTO>>>> Delete(string email)
        {
            return await _adminService.DeleteUser(email);
        }
    }
}

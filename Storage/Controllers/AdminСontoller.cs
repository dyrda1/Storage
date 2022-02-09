using BBL.BusinessModels;
using BBL.DTO;
using BBL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Storage.Controllers
{
    //[Authorize(Roles = "admin")]
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
        public ActionResult<Response<List<ReportDTO>>> GetReports()
        {
            return _adminService.GetReports();
        }

        [HttpGet]
        [Route("GetUsersSkippedDays")]
        public ActionResult<Response<List<SkippedDaysDTO>>> GetUsersSkippedDays()
        {
            return _adminService.GetUsersSkippedDays();
        }

        [HttpDelete]
        public async Task<ActionResult<Response<List<UserDTO>>>> Delete(UserDTO userDTO)
        {
            return await _adminService.DeleteUser(userDTO);
        }
    }
}

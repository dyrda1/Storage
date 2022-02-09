using BBL.BusinessModels;
using BBL.DTO;
using BBL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Storage.Controllers
{
    //[Authorize(Roles = "manager")]
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerСontoller:ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerСontoller(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpPost]
        public async Task<ActionResult<Response<ReportDTO>>> Post(DateTime dateFrom, DateTime dateTo)
        {
            return await _managerService.Create(dateFrom, dateTo);
        }
    }
}

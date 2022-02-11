using BBL.BusinessModels;
using BBL.DTO;
using BBL.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Storage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;

        public AccountController(ILoginService loginService, IRegisterService registerService)
        {
            _loginService = loginService;
            _registerService = registerService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<Response<Guid>>> Register(UserDTO userDTO)
        {
            return await _registerService.Register(userDTO);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<Response<string>>> Login(UserDTO userDTO)
        {
            return await _loginService.Login(userDTO);
        }
    }
}

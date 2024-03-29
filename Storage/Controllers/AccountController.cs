﻿using BBL.BusinessModels;
using BBL.DTO;
using BBL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpPost("Register")]
        public async Task<ActionResult<Response<Guid>>> Register(UserDTO userDTO)
        {
            var response = await _registerService.Register(userDTO);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<Response<string>>> Login(UserDTO userDTO)
        {
            var response = await _loginService.Login(userDTO);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return await _loginService.Login(userDTO);
        }
    }
}

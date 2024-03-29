﻿using BBL.BusinessModels;
using BBL.DTO;
using BBL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Storage.Controllers
{
    [Authorize(Roles = "employer")]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployerСontoller : ControllerBase
    {
        private readonly IEmployerService _employerService;
        private readonly IMarkService _markService;

        public EmployerСontoller(IEmployerService employerService, IMarkService markService)
        {
            _employerService = employerService;
            _markService = markService;
        }

        [HttpPost]
        public async Task<ActionResult<Response<List<ProductDTO>>>> Post(CreateProductDTO productDTO)
        {
            return await _employerService.Create(productDTO);
        }

        [HttpDelete]
        public async Task<ActionResult<Response<List<ProductDTO>>>> Delete(string name)
        {
            return await _employerService.DeleteByName(name);
        }

        [HttpPut]
        public async Task<ActionResult<Response<List<ProductDTO>>>> Put(ProductDTO productDTO)
        {
            return await _employerService.Update(productDTO);
        }

        [HttpPut]
        [Route("Mark")]
        public async Task<ActionResult<Response<SkippedDaysDTO>>> Put()
        {
            var id = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            return await _markService.Mark(id);
        }
    }
}

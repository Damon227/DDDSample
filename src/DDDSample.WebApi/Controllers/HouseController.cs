using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDSample.Application.DtoModels.House;
using DDDSample.Application.Services.Interfaces;
using DDDSample.Infrastructure.Models;
using DDDSample.WebApi.Extensions;
using DDDSample.WebApi.Filters;
using DDDSample.WebApi.Models.House;
using Microsoft.AspNetCore.Mvc;

namespace DDDSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class HouseController : DDDSampleControllerBase
    {
        private readonly IHouseApplicationService _houseApplicationService;

        public HouseController(IHouseApplicationService houseApplicationService)
        {
            _houseApplicationService = houseApplicationService;
        }

        [HttpPost]
        [Route("Create")]
        [RequestModelValidate]
        public async Task<IActionResult> Create([FromBody] CreateHouseRequest request)
        {
            Result<HouseDto> result = await _houseApplicationService.CreateHouseAsync(request.OwnerId, request.Name, request.Address, request.Area);
            
            return result.Succeed ? Success(result.Data) : Fail(result.Code, result.Message);
        }

        [HttpGet]
        [Route("Get/{houseId}")]
        public async Task<IActionResult> Get(string houseId)
        {
            return Success(await _houseApplicationService.GetHouseAsync(houseId));
        }

        [HttpPost]
        [Route("UpdateName/{houseId}/{name}")]
        public async Task<IActionResult> UpdateName(string houseId, string name)
        {
            Result result = await _houseApplicationService.UpdateHouseNameAsync(houseId, name);

            return result.Succeed ? Success() : Fail(result.Code, result.Message);
        }
    }
}

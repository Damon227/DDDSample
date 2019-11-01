using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDSample.Application.DtoModels.Production;
using DDDSample.Application.Services.Interfaces;
using DDDSample.Infrastructure.Models;
using DDDSample.WebApi.Extensions;
using DDDSample.WebApi.Models.Production;
using Microsoft.AspNetCore.Mvc;

namespace DDDSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionController : DDDSampleControllerBase
    {
        private readonly IProductionApplicationService _productionApplicationService;

        public ProductionController(IProductionApplicationService productionApplicationService)
        {
            _productionApplicationService = productionApplicationService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateRequest request)
        {
            Result<ProductionDto> result = 
                await _productionApplicationService.CreateProductionAsync(request.Name, request.FullName, request.Price);

            if (result.Succeed)
            {
                return Success(result.Data);
            }

            return Error(result.Message);
        }

        [HttpPost]
        [Route("UpdateName/{productionId:length(32)}/{name:maxlength(20)}")]
        public async Task<IActionResult> UpdateName(string productionId, string name)
        {
            Result result = await _productionApplicationService.UpdateNameAsync(productionId, name);

            if (result.Succeed)
            {
                return Success();
            }

            return Error(result.Message);
        }

        [HttpGet]
        [Route("Get/{productionId:length(32)}")]
        public async Task<IActionResult> Get(string productionId)
        {
            ProductionDto productionDto = await _productionApplicationService.GetAsync(productionId);
            return Success(productionDto);
        }
    }
}

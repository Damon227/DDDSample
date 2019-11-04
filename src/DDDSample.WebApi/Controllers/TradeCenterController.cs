using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDSample.Application.Services.Interfaces;
using DDDSample.Domain.TradeCenter.Models;
using DDDSample.Infrastructure.Models;
using DDDSample.WebApi.Extensions;
using DDDSample.WebApi.Filters;
using DDDSample.WebApi.Models.TradeCenter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DDDSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TradeCenterController : DDDSampleControllerBase
    {
        private readonly ITradeCenterApplicationService _tradeCenterApplicationService;

        public TradeCenterController(ITradeCenterApplicationService tradeCenterApplicationService)
        {
            _tradeCenterApplicationService = tradeCenterApplicationService;
        }

        [HttpPost]
        [Route("Create")]
        [RequestModelValidate]
        public async Task<IActionResult> Create([FromBody] CreateTradeRecordRequest request)
        {
            Result<TradeRecord> result = await _tradeCenterApplicationService
                .CreateTradeRecordAsync(request.HouseId, request.SellerId, request.BuyerId, request.Description);

            return result.Succeed ? Success(result.Data) : Fail(result.Code, result.Message);
        }
    }
}

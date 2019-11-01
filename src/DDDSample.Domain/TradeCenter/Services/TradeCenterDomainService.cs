using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DDDSample.Domain.Commands;
using DDDSample.Domain.TradeCenter.Models;
using DDDSample.Domain.TradeCenter.Services.Interfaces;
using DDDSample.Infrastructure.Models;
using MediatR;

namespace DDDSample.Domain.TradeCenter.Services
{
    public class TradeCenterDomainService : ITradeCenterDomainService
    {
        private readonly IMediator _mediator;

        public TradeCenterDomainService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<House.Models.House> GetHouseAsync(string houseId)
        {
            if (string.IsNullOrEmpty(houseId))
            {
                throw new ArgumentNullException(nameof(houseId));
            }

            return await _mediator.Send(new HouseQueryCommand(houseId));
        }

        public async Task<Result> CanTradeAsync(string houseId)
        {
            if (string.IsNullOrEmpty(houseId))
            {
                throw new ArgumentNullException(nameof(houseId));
            }

            House.Models.House house = await GetHouseAsync(houseId);
            if (house != null && !house.CanTrade())
            {
                return Result.Fail("This house not allow trade.");
            }

            return Result.Success();
        }
    }
}

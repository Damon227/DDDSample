using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DDDSample.Infrastructure.Models;

namespace DDDSample.Domain.TradeCenter.Services.Interfaces
{
    public interface ITradeCenterDomainService
    {
        Task<House.Models.House> GetHouseAsync(string houseId);

        Task<Result> CanTradeAsync(string houseId);
    }
}

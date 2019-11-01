using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DDDSample.Domain.TradeCenter.Models;
using DDDSample.Infrastructure.Models;

namespace DDDSample.Application.Services.Interfaces
{
    public interface ITradeCenterApplicationService
    {
        Task<Result<TradeRecord>> CreateTradeRecordAsync(string houseId, string sellerId, string buyerId, string description = null);
    }
}

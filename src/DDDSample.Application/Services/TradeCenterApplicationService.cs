using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DDDSample.Application.Services.Interfaces;
using DDDSample.Domain.Events;
using DDDSample.Domain.House.Models;
using DDDSample.Domain.Interfaces;
using DDDSample.Domain.TradeCenter.Models;
using DDDSample.Domain.TradeCenter.Services.Interfaces;
using DDDSample.Infrastructure.Models;
using MediatR;

namespace DDDSample.Application.Services
{
    public class TradeCenterApplicationService : ITradeCenterApplicationService
    {
        private readonly ITradeRecordRepository _tradeRecordRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITradeCenterDomainService _tradeCenterDomainService;
        private readonly IMediator _mediator;

        public TradeCenterApplicationService(
            ITradeRecordRepository tradeRecordRepository, 
            IUnitOfWork unitOfWork, 
            ITradeCenterDomainService tradeCenterDomainService, 
            IMediator mediator)
        {
            _tradeRecordRepository = tradeRecordRepository;
            _unitOfWork = unitOfWork;
            _tradeCenterDomainService = tradeCenterDomainService;
            _mediator = mediator;
        }

        public async Task<Result<TradeRecord>> CreateTradeRecordAsync(string houseId, string sellerId, string buyerId, string description = null)
        {
            Result check = await _tradeCenterDomainService.CanTradeAsync(houseId);
            if (!check.Succeed)
            {
                return Result<TradeRecord>.Fail(check.Message);
            }

            TradeRecord tradeRecord = new TradeRecord(houseId, sellerId, buyerId, description);

            _tradeRecordRepository.Add(tradeRecord);
            if (await _unitOfWork.CommitAsync())
            {
                // send event to house and wait
                await _mediator.Publish(new HouseTradedEvent(houseId, buyerId));
            }

            return Result<TradeRecord>.Success(tradeRecord);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DDDSample.Domain.Events;
using DDDSample.Domain.Interfaces;
using MediatR;

namespace DDDSample.Domain.EventHandlers
{
    public class HouseEventHandler : INotificationHandler<HouseTradedEvent>
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HouseEventHandler(IHouseRepository houseRepository, IUnitOfWork unitOfWork)
        {
            _houseRepository = houseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(HouseTradedEvent notification, CancellationToken cancellationToken)
        {
            House.Models.House house = await _houseRepository.GetByIdAsync(notification.HouseId);
            if (house != null)
            {
                house.TradeTo(notification.BuyerId);
                _houseRepository.Update(house);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}

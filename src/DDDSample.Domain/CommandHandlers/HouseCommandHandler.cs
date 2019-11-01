using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DDDSample.Domain.Commands;
using DDDSample.Domain.Interfaces;
using MediatR;

namespace DDDSample.Domain.CommandHandlers
{
    public class HouseCommandHandler : IRequestHandler<HouseQueryCommand, House.Models.House>
    {
        private readonly IHouseRepository _houseRepository;

        public HouseCommandHandler(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        public async Task<House.Models.House> Handle(HouseQueryCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.HouseId))
            {
                return null;
            }

            return await _houseRepository.GetByIdAsync(request.HouseId);
        }
    }
}

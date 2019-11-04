using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DDDSample.Domain.House.Services.Interfaces;
using DDDSample.Domain.Interfaces;
using DDDSample.Infrastructure.Models;

namespace DDDSample.Domain.House.Services
{
    public class HouseDomainService : IHouseDomainService
    {
        private readonly IHouseRepository _houseRepository;

        public HouseDomainService(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        public async Task<Result> UpdateNameAsync(string houseId, string name)
        {
            if (string.IsNullOrEmpty(houseId))
            {
                throw new ArgumentNullException(nameof(houseId));
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Models.House house = await _houseRepository.GetByIdAsync(houseId);
            if (house == null)
            {
                return Result.Fail("Production not exist.");
            }

            house.UpdateName(name);
            _houseRepository.Update(house);

            return Result.Success();
        }
    }
}

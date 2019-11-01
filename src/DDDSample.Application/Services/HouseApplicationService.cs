using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DDDSample.Application.Services.Interfaces;
using DDDSample.Domain.House.Models;
using DDDSample.Domain.Interfaces;
using DDDSample.Infrastructure.Models;

namespace DDDSample.Application.Services
{
    public class HouseApplicationService : IHouseApplicationService
    {
        private readonly IHouseRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public HouseApplicationService(IHouseRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<House>> CreateHouseAsync(string ownerId, string name, string address, float area)
        {
            House house = new House(ownerId, name, address, area);

            _repository.Add(house);
            await _unitOfWork.CommitAsync();
            
            return Result<House>.Success(house);
        }
    }
}

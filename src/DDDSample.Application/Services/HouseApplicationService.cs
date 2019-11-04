using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DDDSample.Application.DtoModels.House;
using DDDSample.Application.Services.Interfaces;
using DDDSample.Domain.House.Models;
using DDDSample.Domain.House.Services.Interfaces;
using DDDSample.Domain.Interfaces;
using DDDSample.Infrastructure.Models;

namespace DDDSample.Application.Services
{
    public class HouseApplicationService : IHouseApplicationService
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHouseDomainService _houseDomainService;

        public HouseApplicationService(IHouseRepository houseRepository, IUnitOfWork unitOfWork, IMapper mapper, IHouseDomainService houseDomainService)
        {
            _houseRepository = houseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _houseDomainService = houseDomainService;
        }

        public async Task<Result<HouseDto>> CreateHouseAsync(string ownerId, string name, string address, double area)
        {
            House house = new House(ownerId, name, address, area);

            _houseRepository.Add(house);
            await _unitOfWork.CommitAsync();
            
            return Result<HouseDto>.Success(_mapper.Map<HouseDto>(house));
        }

        public async Task<HouseDto> GetHouseAsync(string houseId)
        {
            House house = await _houseRepository.GetByIdAsync(houseId);
            return _mapper.Map<HouseDto>(house);
        }

        public async Task<Result> UpdateHouseNameAsync(string houseId, string name)
        {
            Result result = await _houseDomainService.UpdateNameAsync(houseId, name);

            if (result.Succeed)
            {
                await _unitOfWork.CommitAsync();
            }

            return result;
        }
    }
}

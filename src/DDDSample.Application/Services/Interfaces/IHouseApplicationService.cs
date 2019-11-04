using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DDDSample.Application.DtoModels.House;
using DDDSample.Domain.House.Models;
using DDDSample.Infrastructure.Models;

namespace DDDSample.Application.Services.Interfaces
{
    public interface IHouseApplicationService
    {
        Task<Result<HouseDto>> CreateHouseAsync(string ownerId, string name, string address, double area);

        Task<HouseDto> GetHouseAsync(string houseId);

        Task<Result> UpdateHouseNameAsync(string houseId, string name);
    }
}

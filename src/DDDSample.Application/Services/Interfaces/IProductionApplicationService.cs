using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DDDSample.Application.DtoModels.Production;
using DDDSample.Infrastructure.Models;

namespace DDDSample.Application.Services.Interfaces
{
    public interface IProductionApplicationService
    {
        Task<Result<ProductionDto>> CreateProductionAsync(string name, string fullName, long price);

        Task<ProductionDto> GetAsync(string productionId);

        Task<Result> UpdateNameAsync(string productionId, string name);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DDDSample.Domain.House.Models;
using DDDSample.Infrastructure.Models;

namespace DDDSample.Application.Services.Interfaces
{
    public interface IHouseApplicationService
    {
        Task<Result<House>> CreateHouseAsync(string ownerId, string name, string address, float area);
    }
}

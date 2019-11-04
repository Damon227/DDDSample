using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DDDSample.Infrastructure.Models;

namespace DDDSample.Domain.House.Services.Interfaces
{
    public interface IHouseDomainService
    {
        Task<Result> UpdateNameAsync(string houseId, string name);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DDDSample.Infrastructure.Models;

namespace DDDSample.Domain.Production.Services.Interfaces
{
    public interface IProductionDomainService
    {
        Task<Result> CheckNameAsync(string name);

        Task<Result> UpdateNameAsync(Models.Production production, string name);
    }
}

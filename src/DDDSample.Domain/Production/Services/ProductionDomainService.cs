using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DDDSample.Domain.Interfaces;
using DDDSample.Domain.Production.Services.Interfaces;
using DDDSample.Infrastructure.Models;

namespace DDDSample.Domain.Production.Services
{
    public class ProductionDomainService : IProductionDomainService
    {
        private readonly IProductionRepository _repository;

        public ProductionDomainService(IProductionRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Result> CheckNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (name.Length > 20)
            {
                return Result.Fail("The name's length must be less than 20.");
            }

            Models.Production production = await _repository.GetByNameAsync(name);
            if (production != null)
            {
                return Result.Fail("The name of production is exist.");
            }

            return Result.Success();
        }

        public async Task<Result> UpdateNameAsync(Models.Production production, string name)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Result checkResult = await CheckNameAsync(name);
            if (!checkResult.Succeed)
            {
                return checkResult;
            }

            production.UpdateName(name);
            _repository.Update(production);

            return Result.Success();
        }
    }
}

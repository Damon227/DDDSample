using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DDDSample.Application.DtoModels.Production;
using DDDSample.Application.Services.Interfaces;
using DDDSample.Domain.Events;
using DDDSample.Domain.Interfaces;
using DDDSample.Domain.Production.Models;
using DDDSample.Domain.Production.Services.Interfaces;
using DDDSample.Infrastructure.Models;
using MediatR;

namespace DDDSample.Application.Services
{
    public class ProductionApplicationService : IProductionApplicationService
    {
        private readonly IProductionDomainService _productionDomainService;
        private readonly IProductionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductionApplicationService(
            IProductionDomainService productionDomainService, 
            IProductionRepository repository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IMediator mediator)
        {
            _productionDomainService = productionDomainService ?? throw new ArgumentNullException(nameof(productionDomainService));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Result<ProductionDto>> CreateProductionAsync(string name, string fullName, long price)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Result checkResult = await _productionDomainService.CheckNameAsync(name);
            if (!checkResult.Succeed)
            {
                return Result<ProductionDto>.Fail(checkResult.Message);
            }

            Production production = new Production(name, fullName, price);

            _repository.Add(production);
            if (await _unitOfWork.CommitAsync())
            {
                await _mediator.Publish(new ProductionCreatedEvent(production.Id, production.Name, production.FullName, production.Price));
            }

            return Result<ProductionDto>.Success(_mapper.Map<ProductionDto>(production));
        }

        public async Task<ProductionDto> GetAsync(string productionId)
        {
            if (string.IsNullOrEmpty(productionId))
            {
                throw new ArgumentNullException(nameof(productionId));
            }

            Production production = await _repository.GetByIdAsync(productionId);

            return _mapper.Map<ProductionDto>(production);
        }

        public async Task<Result> UpdateNameAsync(string productionId, string name)
        {
            if (string.IsNullOrEmpty(productionId))
            {
                throw new ArgumentNullException(nameof(productionId));
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
           
            Production production = await _repository.GetByIdAsync(productionId);
            Result result = await _productionDomainService.UpdateNameAsync(production, name);

            if (result.Succeed)
            {
                if (await _unitOfWork.CommitAsync())
                {
                    await _mediator.Publish(new ProductionNameUpdatedEvent(productionId, name));
                }
            }

            return result;
        }
    }
}

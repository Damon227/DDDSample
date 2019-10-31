using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DDDSample.Application.DtoModels.Production;
using DDDSample.Domain.Production.Models;

namespace DDDSample.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Production, ProductionDto>();
        }
    }
}

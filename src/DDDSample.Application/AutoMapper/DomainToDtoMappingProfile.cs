using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DDDSample.Application.DtoModels.House;
using DDDSample.Application.DtoModels.Production;
using DDDSample.Domain.House.Models;

namespace DDDSample.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<House, HouseDto>();
        }
    }
}

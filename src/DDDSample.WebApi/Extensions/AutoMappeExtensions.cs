using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDSample.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace DDDSample.WebApi.Extensions
{
    public static class AutoMappeExtensions
    {
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddAutoMapper(typeof(DomainToDtoMappingProfile), typeof(DtoToDomainMappingProfile));

            //AutoMapperConfig.RegisterMappings();
        }
    }
}

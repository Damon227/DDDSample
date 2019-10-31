using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDSample.Application.Services;
using DDDSample.Application.Services.Interfaces;
using DDDSample.Data;
using DDDSample.Data.Production;
using DDDSample.Data.Repository;
using DDDSample.Data.Uow;
using DDDSample.Domain.Interfaces;
using DDDSample.Domain.Production.Services;
using DDDSample.Domain.Production.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDDSample.WebApi.Extensions
{
    public class NativeInjector
    {
        public static void RegisterServies(IServiceCollection services, IConfiguration configuration)
        {
            // Application
            services.AddScoped<IProductionApplicationService, ProductionApplicationService>();

            // Domain
            services.AddScoped<IProductionDomainService, ProductionDomainService>();

            // Data
            services.Configure<DataOptions>(configuration.GetSection("Data"));
            services.AddScoped<IProductionRepository, ProductionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MyDbContext>();

            // Commands

            // Events
        }
    }
}

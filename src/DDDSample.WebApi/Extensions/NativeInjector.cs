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
using DDDSample.Domain.House.Services;
using DDDSample.Domain.House.Services.Interfaces;
using DDDSample.Domain.Interfaces;
using DDDSample.Domain.TradeCenter.Services;
using DDDSample.Domain.TradeCenter.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDDSample.WebApi.Extensions
{
    public class NativeInjector
    {
        public static void RegisterServies(IServiceCollection services, IConfiguration configuration)
        {
            // Application
            services.AddScoped<IHouseApplicationService, HouseApplicationService>();
            services.AddScoped<ITradeCenterApplicationService, TradeCenterApplicationService>();

            // Domain
            services.AddScoped<IHouseDomainService, HouseDomainService>();
            services.AddScoped<ITradeCenterDomainService, TradeCenterDomainService>();

            // Data
            services.Configure<DataOptions>(configuration.GetSection("Data"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MyDbContext>();
            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<ITradeRecordRepository, TradeRecordRepository>();

            // Commands

            // Events
        }
    }
}

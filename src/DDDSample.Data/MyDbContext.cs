using System;
using System.Collections.Generic;
using System.Text;
using DDDSample.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DDDSample.Data.Production
{
    public class MyDbContext : DbContext
    {
        private readonly DataOptions _dataOptions;
        private readonly ILoggerFactory _loggerFactory;

        public MyDbContext(IOptions<DataOptions> dataOptionsAccessor, ILoggerFactory loggerFactory)
        {
            _dataOptions = dataOptionsAccessor?.Value ?? throw new ArgumentNullException(nameof(dataOptionsAccessor));
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        public DbSet<Domain.Production.Models.Production> Productions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductionMap());

            modelBuilder.Entity<Domain.Production.Models.Production>().HasQueryFilter(t => t.Enable);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dataOptions.ConnectionString)
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(_loggerFactory);
        }
    }
}

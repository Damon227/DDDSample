using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DDDSample.Data.Production;
using DDDSample.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DDDSample.Data.Repository
{
    public class ProductionRepository : Repository<Domain.Production.Models.Production>, IProductionRepository
    {
        public ProductionRepository(MyDbContext dbContext) 
            : base(dbContext)
        {
            
        }

        public async Task<Domain.Production.Models.Production> GetByNameAsync(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(t => t.Name == name);
        }
    }
}

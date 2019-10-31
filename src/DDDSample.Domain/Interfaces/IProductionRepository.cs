using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDSample.Domain.Interfaces
{
    public interface IProductionRepository : IRepository<Production.Models.Production>
    {
        Task<Production.Models.Production> GetByNameAsync(string name);
    }
}

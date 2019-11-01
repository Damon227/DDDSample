using System;
using System.Collections.Generic;
using System.Text;
using DDDSample.Data.Production;
using DDDSample.Domain.House.Models;
using DDDSample.Domain.Interfaces;

namespace DDDSample.Data.Repository
{
    public class HouseRepository : Repository<House>, IHouseRepository
    {
        public HouseRepository(MyDbContext dbContext) : base(dbContext)
        {
        }
    }
}

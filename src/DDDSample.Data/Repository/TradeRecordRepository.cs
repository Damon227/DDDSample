using System;
using System.Collections.Generic;
using System.Text;
using DDDSample.Data.Production;
using DDDSample.Domain.Interfaces;
using DDDSample.Domain.TradeCenter.Models;

namespace DDDSample.Data.Repository
{
    public class TradeRecordRepository : Repository<TradeRecord>, ITradeRecordRepository
    {
        public TradeRecordRepository(MyDbContext dbContext) : base(dbContext)
        {
        }
    }
}

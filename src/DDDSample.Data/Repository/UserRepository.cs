using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DDDSample.Data.Production;
using DDDSample.Domain.Interfaces;
using DDDSample.Domain.User.Models;
using Microsoft.EntityFrameworkCore;

namespace DDDSample.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MyDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByIDNoAsync(string idNo)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(t => t.IDNo == idNo);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDSample.Data.Production;
using DDDSample.Domain.Core.Models;
using DDDSample.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DDDSample.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly MyDbContext DbContext;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(MyDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Remove(string entityId)
        {
            DbSet.Remove(DbSet.AsNoTracking().FirstOrDefault(t => t.EntityId == entityId));
        }

        public virtual async Task<TEntity> GetByEntityIdAsync(string entityId)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(t => t.EntityId == entityId);
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
    }
}

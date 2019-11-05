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
        protected readonly MyDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void Remove(string id)
        {
            _dbSet.Remove(_dbSet.AsNoTracking().FirstOrDefault(t => t.Id == id));
        }

        public virtual async Task<TEntity> GetByIdAsync(string id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}

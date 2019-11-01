using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DDDSample.Domain.Core.Models;

namespace DDDSample.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(string id);
        Task<TEntity> GetByIdAsync(string id);
        Task<int> SaveChangesAsync();
    }
}

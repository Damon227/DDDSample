using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDSample.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();

        Task<bool> CommitAsync();
    }
}

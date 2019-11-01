using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DDDSample.Infrastructure.Models;

namespace DDDSample.Domain.User.Services.Interfaces
{
    public interface IUserDomainService
    {
        Task<bool> IsExistAsync(string idNo);
    }
}

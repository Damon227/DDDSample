using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DDDSample.Domain.User.Models;
using DDDSample.Infrastructure.Models;

namespace DDDSample.Application.Services.Interfaces
{
    public interface IUserApplicationService
    {
        Task<Result<User>> CreateUserAsync(string name, string phoneNumber, string idNo);
    }
}

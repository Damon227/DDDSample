using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDSample.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User.Models.User>
    {
        Task<User.Models.User> GetUserByIDNoAsync(string idNo);
    }
}

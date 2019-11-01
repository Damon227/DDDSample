using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DDDSample.Domain.Interfaces;
using DDDSample.Domain.User.Services.Interfaces;
using DDDSample.Infrastructure.Models;

namespace DDDSample.Domain.User.Services
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _repository;

        public UserDomainService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> IsExistAsync(string idNo)
        {
            if (string.IsNullOrEmpty(idNo))
            {
                throw new ArgumentNullException(nameof(idNo));
            }

            Models.User user = await _repository.GetUserByIDNoAsync(idNo);

            return user != null;
        }
    }
}

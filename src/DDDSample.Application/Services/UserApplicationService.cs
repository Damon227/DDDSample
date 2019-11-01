using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DDDSample.Application.Services.Interfaces;
using DDDSample.Domain.Interfaces;
using DDDSample.Domain.User.Models;
using DDDSample.Domain.User.Services.Interfaces;
using DDDSample.Infrastructure.Models;

namespace DDDSample.Application.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserDomainService _userDomainService;

        public UserApplicationService(
            IUserRepository repository, 
            IUnitOfWork unitOfWork, 
            IUserDomainService userDomainService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _userDomainService = userDomainService;
        }

        public async Task<Result<User>> CreateUserAsync(string name, string phoneNumber, string idNo)
        {
            User user = new User(name, phoneNumber, idNo);
            bool exist = await _userDomainService.IsExistAsync(idNo);
            if (!exist)
            {
                _repository.Add(user);
                await _unitOfWork.CommitAsync();

                return Result<User>.Success(user);
            }

            return Result<User>.Fail("user is existed.");
        }
    }
}

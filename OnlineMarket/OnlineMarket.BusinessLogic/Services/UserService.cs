using System;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Contract.Interfaces;

namespace OnlineMarket.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IUserUnitOfWork<UserContractModel> _userUnitOfWork;

        public UserService(IUserUnitOfWork<UserContractModel> userUnitOfWork)
        {
            _userUnitOfWork = userUnitOfWork;
        }

        public UserContractModel RegisterUser(UserContractModel contractModel)
        {
            throw new NotImplementedException();
        }

        public void Login(UserContractModel contractModel)
        {
            throw new NotImplementedException();
        }

        public bool CheckConfirmation(UserContractModel user)
        {
            return false;
        }
    }
}

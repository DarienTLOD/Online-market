using System;
using OnlineMarket.Contract.ContractModels;

namespace OnlineMarket.Contract.Interfaces
{
    public interface IUserService
    {
        UserContractModel RegisterUser(UserContractModel user);
        void Login(UserContractModel user);
        bool CheckConfirmation(UserContractModel user);
    }
}

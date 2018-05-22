using System;
using System.Linq;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Contract.Interfaces;

namespace OnlineMarket.BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountUnitOfWork<AccountContractModel> _accountUnitOfWork;
        public AccountService(IAccountUnitOfWork<AccountContractModel> accountUnitOfWork)
        {
            _accountUnitOfWork = accountUnitOfWork;
        }

        public AccountContractModel GetAccountByAccountOwnerId(Guid accountOwnerId)
        {
            return _accountUnitOfWork.AccountRepository.GetWithInclude(x=>x.AccountOwnerId == accountOwnerId, y=>y.Storages).FirstOrDefault();
        }
    }
}

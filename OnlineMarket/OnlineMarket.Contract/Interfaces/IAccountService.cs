using System;
using OnlineMarket.Contract.ContractModels;

namespace OnlineMarket.Contract.Interfaces
{
    public interface IAccountService
    {
        AccountContractModel GetAccountByAccountOwnerId(Guid accountOwnerId);
    }
}

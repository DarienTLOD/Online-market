using System;
using OnlineMarket.Contract.ContractModels;

namespace OnlineMarket.Contract.Interfaces
{
    public interface IUserService
    {
        UserContractModel Get(Guid id);
    }
}

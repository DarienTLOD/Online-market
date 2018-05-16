using System;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Contract.Interfaces;

namespace OnlineMarket.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IOnlineMarketUnitOfWork _onlineMarketUnitOfWork;

        public UserService(IOnlineMarketUnitOfWork onlineMarketUnitOfWork)
        {
            _onlineMarketUnitOfWork = onlineMarketUnitOfWork;
        }

        public UserContractModel Get(Guid id)
        {
           return _onlineMarketUnitOfWork.UserRepository.Get(id);
        }
    }
}

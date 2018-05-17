using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Contract.Interfaces;

namespace OnlineMarket.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IOnlineMarketUnitOfWork<UserContractModel> _onlineMarketUnitOfWork;

        public UserService(IOnlineMarketUnitOfWork<UserContractModel> onlineMarketUnitOfWork)
        {
            _onlineMarketUnitOfWork = onlineMarketUnitOfWork;
        }

        public UserContractModel Get(Guid id)
        {
           return _onlineMarketUnitOfWork.Repository.Get(id);
        }

        public IEnumerable<UserContractModel> Find(Expression<Func<UserContractModel, bool>> predecate)
        {
           return _onlineMarketUnitOfWork.Repository.Find(predecate);
        }
    }
}

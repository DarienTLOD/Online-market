using System;
using System.Collections.Generic;
using System.Linq;
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

        public UserContractModel Get(params object[] id)
        {
           return _onlineMarketUnitOfWork.Repository.Get(id);
        }

        public List<UserContractModel> GetAll()
        {
           return _onlineMarketUnitOfWork.Repository.GetAll().ToList();
        }


        public IEnumerable<UserContractModel> Find(Expression<Func<UserContractModel, bool>> predecate)
        {
           return _onlineMarketUnitOfWork.Repository.Find(predecate);
        }
    }
}

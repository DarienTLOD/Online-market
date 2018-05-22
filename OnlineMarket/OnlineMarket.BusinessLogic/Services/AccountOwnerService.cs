using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OnlineMarket.Contract.Interfaces;

namespace OnlineMarket.BusinessLogic.Services
{
    public class AccountOwnerService<T> : IAccountOwnerService<T>
    where T : class 
    {
        private readonly IOnlineMarketUnitOfWork<T> _onlineMarketUnitOfWork;

        public AccountOwnerService(IOnlineMarketUnitOfWork<T> onlineMarketUnitOfWork)
        {
            _onlineMarketUnitOfWork = onlineMarketUnitOfWork;
        }

        public T Get(params object[] id)
        {
           return _onlineMarketUnitOfWork.Repository.Get(id);
        }

        public List<T> GetAll()
        {
           return _onlineMarketUnitOfWork.Repository.GetAll().ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
           return _onlineMarketUnitOfWork.Repository.Find(predicate);
        }
    }
}

using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Contract.Interfaces;

namespace OnlineMarket.DataAccess.Repositories
{
    public class OnlineMarketUnitOfWork<T> : IOnlineMarketUnitOfWork<T> where T : class 
    {
        public IRepository<T> Repository { get; }

        private readonly IContext _context;

        public OnlineMarketUnitOfWork(IRepository<T> repository, IContext context)
        {
            Repository = repository;
            _context = context;
        }

        public void Save()
        {
            _context.Save();
        }
    }
}

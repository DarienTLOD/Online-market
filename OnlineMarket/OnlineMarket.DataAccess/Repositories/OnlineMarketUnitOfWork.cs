using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Contract.Interfaces;

namespace OnlineMarket.DataAccess.Repositories
{
    public class OnlineMarketUnitOfWork : IOnlineMarketUnitOfWork
    {
        public IRepositoryBase<UserContractModel> UserRepository { get; }

        private readonly IContext _context;

        public OnlineMarketUnitOfWork(IRepositoryBase<UserContractModel> userRepository, IContext context)
        {
            UserRepository = userRepository;
            _context = context;
        }

        public void Save()
        {
            _context.Save();
        }
    }
}

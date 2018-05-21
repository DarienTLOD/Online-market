using System.Runtime.CompilerServices;
using OnlineMarket.Contract.Interfaces;

[assembly: InternalsVisibleTo("OnlineMarket.DependencyResolver")]
namespace OnlineMarket.DataAccess.UnitsOfWork
{
    internal class OnlineMarketUnitOfWork<T> : IOnlineMarketUnitOfWork<T> where T : class
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

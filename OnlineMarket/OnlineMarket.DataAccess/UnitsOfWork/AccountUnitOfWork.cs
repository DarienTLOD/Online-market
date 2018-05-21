using System.Runtime.CompilerServices;
using OnlineMarket.Contract.Interfaces;

[assembly: InternalsVisibleTo("OnlineMarket.DependencyResolver")]
namespace OnlineMarket.DataAccess.UnitsOfWork
{
    internal class AccountUnitOfWork<T> : IAccountUnitOfWork<T>
        where T : class
    {
        public IRepository<T> AccountRepository { get; }
        private readonly IContext _context;

        public AccountUnitOfWork(IContext context, IRepository<T> accountRepository)
        {
            _context = context;
            AccountRepository = accountRepository;
        }

        public void Save()
        {
            _context.Save();
        }
    }
}

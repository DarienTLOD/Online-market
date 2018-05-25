using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using OnlineMarket.Contract.Interfaces;

[assembly: InternalsVisibleTo("OnlineMarket.DependencyResolver")]
namespace OnlineMarket.DataAccess.UnitsOfWork
{
    internal class OperationUnitOfWork<T, TU, TV, TY> : IOperationUnitOfWork<T, TU, TV, TY>
        where T : class
        where TU : class
        where TV : class
        where TY : class
    {
        public IRepository<T> AccountRepository { get; }
        public IRepository<TU> RateRepository { get; }
        public IRepository<TV> StorageRepository { get; }
        public IRepository<TY> OperationArchiveRepository { get; }
        private readonly IContext _context;

        public OperationUnitOfWork(IRepository<T> accountRepository, IRepository<TU> rateRepository, IRepository<TV> storageRepository, IRepository<TY> operationArchiveRepository, IContext context)
        {
            AccountRepository = accountRepository;
            RateRepository = rateRepository;
            StorageRepository = storageRepository;
            OperationArchiveRepository = operationArchiveRepository;
            _context = context;
        }

        public void Save()
        {
            _context.Save();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveAsync();
        }
    }
}

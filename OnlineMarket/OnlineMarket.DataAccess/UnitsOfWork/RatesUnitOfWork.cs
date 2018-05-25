using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using OnlineMarket.Contract.Interfaces;

[assembly: InternalsVisibleTo("OnlineMarket.DependencyResolver")]
namespace OnlineMarket.DataAccess.UnitsOfWork
{
    internal class RatesUnitOfWork<T, TU> : IRatesUnitOfWork<T, TU>
        where T : class
        where TU : class
    {
        public IRepository<T> CurrentRateRepository { get; }
        public IRepository<TU> ExchangeRatesRepository { get; }
        private readonly IContext _context;

        public RatesUnitOfWork(IRepository<T> currentRateRepository, IRepository<TU> exchangeRatesRepository, IContext context)
        {
            CurrentRateRepository = currentRateRepository;
            ExchangeRatesRepository = exchangeRatesRepository;
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

namespace OnlineMarket.Contract.Interfaces
{
    public interface IRatesUnitOfWork<T, TU> : IUnitOfWork
    where T : class
    where TU : class
    {
        IRepository<T> CurrentRateRepository { get; }
        IRepository<TU> ExchangeRatesRepository { get; }
    }
}

namespace OnlineMarket.Contract.Interfaces
{
    public interface IOnlineMarketUnitOfWork<TI> : IUnitOfWork
        where TI : class
    {
        IRepository<TI> Repository { get; } 
    }
}

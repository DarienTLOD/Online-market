namespace OnlineMarket.Contract.Interfaces
{
    public interface IOnlineMarketUnitOfWork<TI> 
        where TI : class
    {
        IRepository<TI> Repository { get; } 
        void Save();
    }
}

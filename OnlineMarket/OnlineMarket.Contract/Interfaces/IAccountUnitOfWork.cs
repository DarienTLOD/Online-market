namespace OnlineMarket.Contract.Interfaces
{
    public interface IAccountUnitOfWork<T> : IUnitOfWork
        where T : class
    {
        IRepository<T> AccountRepository { get; }
    }
}

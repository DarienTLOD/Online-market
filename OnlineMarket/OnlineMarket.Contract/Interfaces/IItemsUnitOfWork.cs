namespace OnlineMarket.Contract.Interfaces
{
    public interface IItemsUnitOfWork<T> : IUnitOfWork
    where T : class
    {
        IRepository<T> ItemRepository { get; }
    }
}

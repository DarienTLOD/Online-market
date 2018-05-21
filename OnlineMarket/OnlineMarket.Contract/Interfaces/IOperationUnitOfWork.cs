namespace OnlineMarket.Contract.Interfaces
{
    public interface IOperationUnitOfWork<T, TU, TV, TY> : IUnitOfWork
        where T : class
        where TU : class
        where TV : class
        where TY : class
    {
        IRepository<T> AccountRepository { get; }
        IRepository<TU> RateRepository { get; }
        IRepository<TV> StorageRepository { get; }
        IRepository<TY> OperationArchiveRepository { get; }
    }
}

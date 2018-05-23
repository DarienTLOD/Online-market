namespace OnlineMarket.Contract.Interfaces
{
    public interface IUserUnitOfWork<TI> : IUnitOfWork
        where TI : class
    {
        IRepository<TI> UserRepository { get; } 
    }
}

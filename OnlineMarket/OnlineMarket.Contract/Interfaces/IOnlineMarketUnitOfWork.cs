using OnlineMarket.Contract.ContractModels;

namespace OnlineMarket.Contract.Interfaces
{
    public interface IOnlineMarketUnitOfWork
    {
        IRepositoryBase<UserContractModel> UserRepository { get; }
        void Save();
    }
}

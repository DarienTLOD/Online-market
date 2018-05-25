using System.Threading.Tasks;

namespace OnlineMarket.Contract.Interfaces
{
    public interface IUnitOfWork
    {
        void Save();
        Task<int> SaveAsync();
    }
}

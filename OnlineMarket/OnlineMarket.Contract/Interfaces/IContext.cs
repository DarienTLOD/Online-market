using System.Threading.Tasks;

namespace OnlineMarket.Contract.Interfaces
{
    public interface IContext
    {
        void Save();
        Task<int> SaveAsync();
    }
}

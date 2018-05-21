using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineMarket.Contract.Interfaces;

[assembly: InternalsVisibleTo("OnlineMarket.DependencyResolver")]
namespace OnlineMarket.DataAccess
{
    internal class Context : IContext
    {
        private readonly OnlineMarketContext _onlineMarketContext;

        public Context(OnlineMarketContext onlineMarketContext)
        {
            _onlineMarketContext = onlineMarketContext;
        }

        public void Save()
        {
            _onlineMarketContext.SaveChanges();
        }
    }
}

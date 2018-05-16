using OnlineMarket.Contract.Interfaces;

namespace OnlineMarket.DataAccess
{
    public class Context : IContext
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

using System.Runtime.CompilerServices;
using OnlineMarket.Contract.Interfaces;

[assembly: InternalsVisibleTo("OnlineMarket.DependencyResolver")]
namespace OnlineMarket.DataAccess.UnitsOfWork
{
    internal class ItemssUnitOfWork<T> : IItemsUnitOfWork<T>
        where T : class
    {
        public IRepository<T> ItemRepository { get; }
        private readonly IContext _context;

        public ItemssUnitOfWork(IRepository<T> itemRepository, IContext context)
        {
            ItemRepository = itemRepository;
            _context = context;
        }
        public void Save()
        {
            _context.Save();
        }
    }
}

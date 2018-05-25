using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using OnlineMarket.Contract.Interfaces;

[assembly: InternalsVisibleTo("OnlineMarket.DependencyResolver")]
namespace OnlineMarket.DataAccess.UnitsOfWork
{
    internal class UserUnitOfWork<T> : IUserUnitOfWork<T> where T : class
    {
        public IRepository<T> UserRepository { get; }

        private readonly IContext _context;

        public UserUnitOfWork(IRepository<T> userRepository, IContext context)
        {
            UserRepository = userRepository;
            _context = context;
        }

        public void Save()
        {
            _context.Save();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveAsync();
        }
    }
}

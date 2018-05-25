using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineMarket.Contract.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T Get(params object[] keyValues);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Create(T item);
        void CreateAsync(T item);
        void CreateMany(IEnumerable<T> items);
        Task CreateManyAsync(IEnumerable<T> items);
        void Update(T item);
        void Delete(T item);
        IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetWithInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
    }
}

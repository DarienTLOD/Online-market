using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineMarket.Contract.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(params object[] keyValues);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}

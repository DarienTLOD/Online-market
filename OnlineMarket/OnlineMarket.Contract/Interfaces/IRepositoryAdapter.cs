using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineMarket.Contract.Interfaces
{
    public interface IRepositoryAdapter<TI,TO> 
        where TI : class
        where TO : class
    {
        IEnumerable<TI> GetAll();
        TI Get(params object[] keyValues);
        IEnumerable<TI> Find(Expression<Func<TI, bool>> predicate);
        void Create(TI item);
        void CreateMany(IEnumerable<TI> items);
        void Update(TI item);
        void Delete(TI item);
        IEnumerable<TI> GetWithInclude(params Expression<Func<TI, object>>[] includeProperties);
        IEnumerable<TI> GetWithInclude(Func<TI, bool> predicate, params Expression<Func<TI, object>>[] includeProperties);
    }
}

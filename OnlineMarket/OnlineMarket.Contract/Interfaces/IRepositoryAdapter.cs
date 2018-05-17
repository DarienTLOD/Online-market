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
        void Update(TI item);
        void Delete(TI item);
    }
}

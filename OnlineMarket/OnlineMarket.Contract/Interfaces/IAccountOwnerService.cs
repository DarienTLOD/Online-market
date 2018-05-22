using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineMarket.Contract.Interfaces
{
    public interface IAccountOwnerService<T>
    {
        T Get(params object[] keyValues);
        List<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predecate);
    }
}

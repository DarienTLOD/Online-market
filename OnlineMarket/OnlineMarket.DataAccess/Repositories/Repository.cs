using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Contract.Interfaces;

namespace OnlineMarket.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly OnlineMarketContext _context;

        public Repository(OnlineMarketContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public T Get(params object[] id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Create(T user)
        {
            _context.Set<T>().Add(user);
        }

        public void Update(T user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public void Delete(T item)
        {
            if (item != null)
                _context.Set<T>().Remove(item);
        }
    }
}

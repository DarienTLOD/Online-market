using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using AutoMapper;
using OnlineMarket.Contract.Interfaces;

[assembly: InternalsVisibleTo("OnlineMarket.DependencyResolver")]
namespace OnlineMarket.DataAccess.RepositoryAdapter
{
    internal class RepositoryAdapter<TI, TO> : IRepository<TI>
        where TO : class
        where TI : class
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TO> _repository;

        public RepositoryAdapter(IRepository<TO> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<TI> GetAll()
        {
            return _repository.GetAll().Select(x => _mapper.Map<TO, TI>(x));
        }

        public TI Get(params object[] keyValues)
        {
            return _mapper.Map<TO, TI>(_repository.Get(keyValues));
        }

        public IEnumerable<TI> Find(Expression<Func<TI, bool>> predicate)
        {
            return _repository.Find(_mapper.Map<Expression<Func<TI, bool>>, Expression<Func<TO, bool>>>(predicate)).Select(x => _mapper.Map<TO, TI>(x));
        }

        public void Create(TI item)
        {
            _repository.Create(_mapper.Map<TI, TO>(item));
        }

        public void CreateMany(IEnumerable<TI> items)
        {
            _repository.CreateMany(items.Select(x => _mapper.Map<TI, TO>(x)).ToList());
        }

        public void Update(TI item)
        {
            _repository.Update(_mapper.Map<TI, TO>(item));
        }

        public void Delete(TI item)
        {
            _repository.Delete(_mapper.Map<TI, TO>(item));
        }

        public IEnumerable<TI> GetWithInclude(params Expression<Func<TI, object>>[] includeProperties)
        {
            return _repository.GetWithInclude(includeProperties.Select(x => _mapper.Map<Expression<Func<TI, object>>, Expression<Func<TO, object>>>(x)).ToArray()).Select(x => _mapper.Map<TO, TI>(x));
        }

        public IEnumerable<TI> GetWithInclude(Expression<Func<TI, bool>> predicate, params Expression<Func<TI, object>>[] includeProperties)
        {

            return _repository.GetWithInclude(_mapper.Map<Expression<Func<TI, bool>>, Expression<Func<TO, bool>>>(predicate), includeProperties.Select(x => _mapper.Map<Expression<Func<TI, object>>, Expression<Func<TO, object>>>(x)).ToArray()).Select(x => _mapper.Map<TO, TI>(x));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using OnlineMarket.Contract.Interfaces;

namespace OnlineMarket.DataAccess.RepositoryAdapter
{
    public class RepositoryAdapter<TI, TO> : IRepository<TI>
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
            return _repository.GetAll().Select(x=> _mapper.Map<TO, TI>(x));
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
            _repository.Create(_mapper.Map<TI,TO>(item));
        }

        public void Update(TI item)
        {
            _repository.Update(_mapper.Map<TI, TO>(item));
        }

        public void Delete(TI item)
        {
            _repository.Delete(_mapper.Map<TI, TO>(item));
        }
    }
}

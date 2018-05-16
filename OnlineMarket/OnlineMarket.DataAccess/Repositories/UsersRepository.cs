using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Contract.Interfaces;
using AutoMapper;
using OnlineMarket.DataAccess.Entities;

namespace OnlineMarket.DataAccess.Repositories
{
    public class UsersRepository : IRepositoryBase<UserContractModel>
    {
        private readonly OnlineMarketContext _context;
        private readonly IMapper _mapper;

        public UsersRepository(OnlineMarketContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<UserContractModel> GetAll()
        {
            return _context.Users.Select(x => _mapper.Map<UserContractModel>(x));
        }

        public UserContractModel Get(Guid id)
        {
            return _mapper.Map<UserContractModel>(_context.Users.Find(id));
        }

        public void Create(UserContractModel user)
        {
            _context.Users.Add(_mapper.Map<UserDataModel>(user));
        }

        public void Update(UserContractModel user)
        {
            _context.Entry(_mapper.Map<UserDataModel>(user)).State = EntityState.Modified;
        }

        //public IEnumerable<UserContractModel> Find(Func<UserContractModel, bool> predicate)
        //{
        //    return _context.Users.Where(predicate).ToList();
        //}

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
                _context.Users.Remove(user);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OnlineMarket.Contract.ContractModels;

namespace OnlineMarket.Contract.Interfaces
{
    public interface IUserService
    {
        UserContractModel Get(params object[] keyValues);
        List<UserContractModel> GetAll();
        IEnumerable<UserContractModel> Find(Expression<Func<UserContractModel, bool>> predecate);
    }
}

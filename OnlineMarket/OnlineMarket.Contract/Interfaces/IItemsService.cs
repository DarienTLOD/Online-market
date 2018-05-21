using System.Collections.Generic;
using OnlineMarket.Contract.ContractModels;

namespace OnlineMarket.Contract.Interfaces
{
    public interface IItemsService
    {
        List<ItemTypeContractModel> GetItems();
    }
}

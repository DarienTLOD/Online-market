using System.Collections.Generic;
using System.Linq;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Contract.Interfaces;

namespace OnlineMarket.BusinessLogic.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IItemsUnitOfWork<ItemTypeContractModel> _itemsUnitOfWork;
        public ItemsService(IItemsUnitOfWork<ItemTypeContractModel> itemsUnitOfWork)
        {
            _itemsUnitOfWork = itemsUnitOfWork;
        }

        public List<ItemTypeContractModel> GetItems()
        {
            return _itemsUnitOfWork.ItemRepository.GetAll().ToList();
        }
    }
}

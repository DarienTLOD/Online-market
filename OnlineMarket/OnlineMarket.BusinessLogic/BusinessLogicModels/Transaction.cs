using System.Collections.Generic;
using System.Linq;
using OnlineMarket.Contract.ContractModels;

namespace OnlineMarket.BusinessLogic.BusinessLogicModels
{
    public class Transaction
    {
        public OperationContent MakeBuyTransaction(OperationContent operationContent, OperationContractModel operation)
        {
            TakeAmountIntoAccount(operationContent);
            operationContent.ToStorages = AddItems(operationContent.ToStorages, operation.Items).ToList();
            operationContent.FromStorages = DeductItems(operationContent.FromStorages, operation.Items).ToList();
            return operationContent;
        }

        public OperationContent MakeSellTransaction(OperationContent operationContent, OperationContractModel operation)
        {
            TakeAmountIntoAccount(operationContent);
            operationContent.ToStorages = AddItems(operationContent.FromStorages, operation.Items).ToList();
            operationContent.FromStorages = DeductItems(operationContent.ToStorages, operation.Items).ToList();
            return operationContent;
        }

        private IEnumerable<StorageContactModel> DeductItems(List<StorageContactModel> storages, List<OperationItemContactModel> items)
        {
            return storages.Join(items, x => x.ItemTypeId, y => y.ItemTypeId,
                 (storage, item) =>
                 {
                     storage.Quantity -= item.Quantity;
                     storage.StorageAmount -= item.ItemAmount;
                     return storage;
                 });
        }

        private IEnumerable<StorageContactModel> AddItems(List<StorageContactModel> storages, List<OperationItemContactModel> items)
        {
            return storages.Join(items, x => x.ItemTypeId, y => y.ItemTypeId,
                 (storage, item) =>
                 {
                     storage.Quantity -= item.Quantity;
                     storage.StorageAmount -= item.ItemAmount;
                     return storage;
                 });
        }

        private void TakeAmountIntoAccount(OperationContent operationContent)
        {
            operationContent.FromAccount.AvailableBalance += operationContent.OperationAmount;
            operationContent.ToAccount.AvailableBalance -= operationContent.OperationAmount;
        }
    }
}

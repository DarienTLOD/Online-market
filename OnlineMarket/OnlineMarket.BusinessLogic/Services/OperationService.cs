using System;
using System.Collections.Generic;
using System.Linq;
using OnlineMarket.BusinessLogic.BusinessLogicModels;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Contract.Interfaces;

namespace OnlineMarket.BusinessLogic.Services
{
    public class OperationService : IOperationService
    {
        private readonly
            IOperationUnitOfWork<AccountContractModel, CurrentRateContractModel, StorageContactModel,
                OperationArchiveContractModel> _operationUnitOfWork;

        public OperationService(IOperationUnitOfWork<AccountContractModel, CurrentRateContractModel, StorageContactModel, OperationArchiveContractModel> operationUnitOfWork)
        {
            _operationUnitOfWork = operationUnitOfWork;
        }

        public void BuyItems(OperationContractModel operation)
        {
            var operationContent = new OperationContent
            {
                Rates = GetCurrentRates(operation.Items),
                UserAccount = GetAccountInfoByAccoundId(operation.UserAccountId),
                UserStorages = GetStoragesByAccountNumber(operation.UserAccountId),
                StoreAccount = GetAccountInfoByAccoundId(operation.StoreAccountId),
                StoreStorages = GetStoragesByAccountNumber(operation.StoreAccountId)
            };

            CalculateAmount(operationContent.Rates, operation.Items);

            operationContent.OperationAmount = operation.Items.Sum(x => x.ItemAmount);

            if (operationContent.UserAccount.AvailableBalance < operationContent.OperationAmount) throw new Exception("You don't have enough money for operation");

            MakeTransaction(operation, operationContent);
        }

        private List<CurrentRateContractModel> GetCurrentRates(IReadOnlyCollection<OperationItemContactModel> operationItems)
        {
            return _operationUnitOfWork.RateRepository.Find(x => operationItems.Any(y => y.ItemTypeId == x.ItemTypeId)).ToList();
        }

        private List<StorageContactModel> GetStoragesByAccountNumber(Guid operationUserAccountId)
        {
            return _operationUnitOfWork.StorageRepository.Find(x => x.AccountId == operationUserAccountId).ToList();
        }

        private AccountContractModel GetAccountInfoByAccoundId(Guid operationUserAccountId)
        {
            return _operationUnitOfWork.AccountRepository.Get(operationUserAccountId);
        }

        private void CalculateAmount(List<CurrentRateContractModel> rates, List<OperationItemContactModel> operationItems)
        {
             operationItems.Join(rates, x => x.ItemTypeId, y => y.ItemTypeId, (x, y) =>
            {
                x.ItemAmount = x.Quantity * y.Rate;
                return x;
            });
        }

        private void MakeTransaction(OperationContractModel operation, OperationContent operationContent)
        {
            TakeAmountIntoAccount(operationContent);
            operationContent.UserStorages.Join(operation.Items, x => x.ItemTypeId, y=>y.ItemTypeId,
                (storage, item) =>
                {
                    storage.Quantity -= item.Quantity;
                    return storage;
                });
        }

        private void TakeAmountIntoAccount(OperationContent operationContent)
        {
            operationContent.StoreAccount.AvailableBalance += operationContent.OperationAmount;
            operationContent.UserAccount.AvailableBalance -= operationContent.OperationAmount;
        }
    }
}

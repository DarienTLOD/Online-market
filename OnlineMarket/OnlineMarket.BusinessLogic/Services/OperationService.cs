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

        private OperationContent InitializeOperationContent(OperationContractModel operation)
        {
            var operationContent = new OperationContent
            {
                Rates = GetCurrentRates(operation.Items),
                ToAccount = GetAccountInfoByAccoundId(operation.AccountOwnerToAccountId),
                ToStorages = GetStoragesByAccountNumber(operation.AccountOwnerToAccountId),
                FromAccount = GetAccountInfoByAccoundId(operation.AccountOwnerFromAccountId),
                FromStorages = GetStoragesByAccountNumber(operation.AccountOwnerFromAccountId),
            };

            return operationContent;
        }

        private OperationContent PrepareOperation(OperationContractModel operation)
        {
            var operationContent = InitializeOperationContent(operation);

            CalculateAmount(operationContent.Rates, operation.Items);
            operationContent.OperationAmount = operation.Items.Sum(x => x.ItemAmount);
            return operationContent;
        }

        public void SellItems(OperationContractModel operation)
        {
            var operationContent = PrepareOperation(operation);

            if (operationContent.ToAccount.AvailableBalance < operationContent.OperationAmount) throw new Exception("You don't have enough money for operation");

            new Transaction().MakeSellTransaction(operationContent, operation);
            SaveOperation(operationContent, operation);
        }

        public void BuyItems(OperationContractModel operation)
        {
            var operationContent = PrepareOperation(operation);

            if (operationContent.ToAccount.AvailableBalance < operationContent.OperationAmount) throw new Exception("You don't have enough money for operation");

            new Transaction().MakeBuyTransaction(operationContent, operation);
            SaveOperation(operationContent, operation);
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

        private void SaveOperation(OperationContent operationContent, OperationContractModel operation)
        {
            _operationUnitOfWork.AccountRepository.Update(operationContent.ToAccount);
            _operationUnitOfWork.AccountRepository.Update(operationContent.FromAccount);
            operationContent.ToStorages.ForEach(x => { _operationUnitOfWork.StorageRepository.Update(x); }); 
            operationContent.FromStorages.ForEach(x => { _operationUnitOfWork.StorageRepository.Update(x); }); 
            SaveInOperationArchive(operationContent.FromAccount, operationContent.ToAccount, operation);
        }

        private void SaveInOperationArchive(AccountContractModel accountFrom, AccountContractModel accountTo, OperationContractModel operation)
        {
           _operationUnitOfWork.OperationArchiveRepository.CreateMany(operation.Items.Select(x => new OperationArchiveContractModel
            {
                ItemTypeId = x.ItemTypeId,
                AccountFromId = accountFrom.Id,
                AccountToId = accountTo.Id,
                OperationAmount = x.ItemAmount,
                Quantity = x.Quantity
            }));
        }
    }
}

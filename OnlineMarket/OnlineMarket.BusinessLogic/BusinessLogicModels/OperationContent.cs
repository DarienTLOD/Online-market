using System.Collections.Generic;
using OnlineMarket.Contract.ContractModels;

namespace OnlineMarket.BusinessLogic.BusinessLogicModels
{
    public class OperationContent
    {
        public List<CurrentRateContractModel> Rates { get; set; }
        public AccountContractModel UserAccount { get; set; }
        public List<StorageContactModel> UserStorages { get; set; }
        public AccountContractModel StoreAccount { get; set; }
        public List<StorageContactModel> StoreStorages { get; set; }
        public decimal OperationAmount { get; set; }
    }
}

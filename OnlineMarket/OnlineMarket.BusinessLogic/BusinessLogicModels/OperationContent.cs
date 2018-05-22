using System.Collections.Generic;
using OnlineMarket.Contract.ContractModels;

namespace OnlineMarket.BusinessLogic.BusinessLogicModels
{
    public class OperationContent
    {
        public List<CurrentRateContractModel> Rates { get; set; }
        public AccountContractModel ToAccount { get; set; }
        public List<StorageContactModel> ToStorages { get; set; }
        public AccountContractModel FromAccount { get; set; }
        public List<StorageContactModel> FromStorages { get; set; }
        public decimal OperationAmount { get; set; }
    }
}

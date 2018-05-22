using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarket.Contract.ContractModels
{
    public class AccountContractModel
    {
        public Guid Id { get; set; }
        public Guid AccountOwnerId { get; set; }
        public List<StorageContactModel> Storages { get; set; }
        public decimal AvailableBalance { get; set; }
    }
}

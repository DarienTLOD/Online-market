using System;
using System.Collections.Generic;

namespace OnlineMarket.Contract.ContractModels
{
    public class OperationContractModel
    {
        public Guid AccountOwnerToId { get; set; }
        public Guid AccountOwnerToAccountId { get; set; }
        public Guid AccountOwnerFromId { get; set; }
        public Guid AccountOwnerFromAccountId { get; set; }
        public List<OperationItemContactModel> Items { get; set; }
    }
}

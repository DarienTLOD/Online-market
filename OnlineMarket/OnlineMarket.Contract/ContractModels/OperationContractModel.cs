using System;
using System.Collections.Generic;

namespace OnlineMarket.Contract.ContractModels
{
    public class OperationContractModel
    {
        public Guid UserId { get; set; }
        public Guid UserAccountId { get; set; }
        public Guid StoreId { get; set; }
        public Guid StoreAccountId { get; set; }
        public List<OperationItemContactModel> Items { get; set; }
    }
}

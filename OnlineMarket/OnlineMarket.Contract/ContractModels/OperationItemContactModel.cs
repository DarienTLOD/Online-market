using System;

namespace OnlineMarket.Contract.ContractModels
{
    public class OperationItemContactModel
    {
        public Guid ItemTypeId { get; set; }
        public decimal ItemAmount { get; set; }
        public int Quantity { get; set; }
    }
}

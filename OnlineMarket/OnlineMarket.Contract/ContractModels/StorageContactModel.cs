using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarket.Contract.ContractModels
{
    public class StorageContactModel
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid ItemTypeId { get; set; }
        public int Quantity { get; set; }
        public decimal StorageAmount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarket.Contract.ContractModels
{
    public class OperationArchiveContractModel
    {
        public Guid Id { get; set; }
        public Guid AccountFromId { get; set; }
        public Guid AccountToId { get; set; }
        public Guid ItemTypeId { get; set; }
        public ItemTypeContractModel ItemType { get; set; }
        public int Quantity { get; set; }
        public decimal OperationAmount { get; set; }
        public DateTime OperationDate { get; set; }
    }
}

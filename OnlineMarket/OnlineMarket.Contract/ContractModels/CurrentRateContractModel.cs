using System;

namespace OnlineMarket.Contract.ContractModels
{
    public class CurrentRateContractModel
    {
        public Guid Id { get; set; }
        public Guid ItemTypeId { get; set; }
        public ItemTypeContractModel ItemType { get; set; }
        public decimal Rate { get; set; }
    }
}

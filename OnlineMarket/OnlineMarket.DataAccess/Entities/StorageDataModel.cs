using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMarket.DataAccess.Entities
{
    [Table("Storage")]
    public class StorageDataModel
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public AccountDataModel Account { get; set; }
        public Guid ItemTypeId { get; set; }
        public ItemTypeDataModel ItemType { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "money")]
        public decimal StorageAmount { get; set; }
    }
}

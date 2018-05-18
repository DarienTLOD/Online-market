using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMarket.DataAccess.Entities
{
    [Table("OperationArchive")]
    public class OperationArchiveDataModel
    {
        public Guid Id { get; set; }
        public Guid AccountFromId { get; set; }
        public Guid AccountToId { get; set; }
        public Guid ItemTypeId { get; set; }
        public ItemTypeDataModel ItemType { get; set; }
        public int Quantity { get; set; }
        public decimal OperationAmount { get; set; }
        public DateTime OperationDate { get; set; }
    }
}

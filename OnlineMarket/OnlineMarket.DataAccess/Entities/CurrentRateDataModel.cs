using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMarket.DataAccess.Entities
{
    [Table("CurrentRate")]
    public class CurrentRateDataModel
    {
        public Guid Id { get; set; }
        public Guid ItemTypeId { get; set; }
        public ItemTypeDataModel ItemType { get; set; }
        [Column(TypeName = "money")]
        public decimal Rate { get; set; }
    }
}

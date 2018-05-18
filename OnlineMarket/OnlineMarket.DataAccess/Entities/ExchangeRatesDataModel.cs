using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMarket.DataAccess.Entities
{
    [Table("ExchangeRates")]
    public class ExchangeRatesDataModel 
    {
        public Guid Id { get; set; }
        public Guid ItemTypeId { get; set; }
        public ItemTypeDataModel ItemType { get; set; }
        [Column(TypeName = "money")]
        public decimal Rate { get; set; }
        public DateTime СhangeDate { get; set; }
    }
}

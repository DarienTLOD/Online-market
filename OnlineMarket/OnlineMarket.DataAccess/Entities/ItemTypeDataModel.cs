using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMarket.DataAccess.Entities
{
    [Table("ItemType")]
    public class ItemTypeDataModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

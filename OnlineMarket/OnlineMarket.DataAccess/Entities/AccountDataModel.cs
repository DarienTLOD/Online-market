using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMarket.DataAccess.Entities
{
    [Table("Account")]
    public class AccountDataModel
    {
        public Guid Id { get; set; }
        public Guid AccountOwnerId { get; set; }
        public AccountOwnerDataModel AccountOwner { get; set; }
        [Column(TypeName = "money")]
        public decimal AvailableBalance { get; set; }
    }
}

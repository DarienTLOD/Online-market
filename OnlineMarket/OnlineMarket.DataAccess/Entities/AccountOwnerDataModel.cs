using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMarket.DataAccess.Entities
{
    [Table("AccountOwners")]
    public class AccountOwnerDataModel
    {
        public Guid Id { get; set; }
    }
}

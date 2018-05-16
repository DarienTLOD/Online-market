using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMarket.DataAccess.Entities
{
    [Table("Users")]
    public class UserDataModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
    }
}

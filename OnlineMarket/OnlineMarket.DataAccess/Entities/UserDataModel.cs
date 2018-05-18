using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMarket.DataAccess.Entities
{
    [Table("Users")]
    public class UserDataModel : AccountOwnerDataModel
    {
        public string Email { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Web.Models
{
    public class UserLockoutModel
    {
        [Required]
        public string UserId { get; set; }
        public bool IsLockout { get; set; }
    }
}

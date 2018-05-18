using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMarket.DataAccess.Entities
{
    [Table("Store")]
    public class StoreDataModel : AccountOwnerDataModel
    {
        public string Name { get; set; }
    }
}

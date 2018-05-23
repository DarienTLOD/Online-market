using System.ComponentModel.DataAnnotations.Schema;
using OnlineMarket.Contract.ContractModels;

namespace OnlineMarket.DataAccess.Entities
{
    [Table("Store")]
    public class StoreDataModel : IAccountOwnerBase
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
}

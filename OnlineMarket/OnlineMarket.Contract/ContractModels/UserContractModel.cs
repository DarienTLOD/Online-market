using Microsoft.AspNetCore.Identity;

namespace OnlineMarket.Contract.ContractModels 
{
    public class UserContractModel : IdentityUser, IAccountOwnerBase
    {
    }
}

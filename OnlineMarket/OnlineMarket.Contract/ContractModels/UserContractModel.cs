using System;

namespace OnlineMarket.Contract.ContractModels
{
    public class UserContractModel
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}

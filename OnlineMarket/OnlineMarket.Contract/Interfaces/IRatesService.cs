using System.Collections.Generic;
using OnlineMarket.Contract.ContractModels;

namespace OnlineMarket.Contract.Interfaces
{
    public interface IRatesService
    {
        List<CurrentRateContractModel> GetCurrentRates();
        void ChangeRates(List<CurrentRateContractModel> rates);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineMarket.Contract.ContractModels;

namespace OnlineMarket.Contract.Interfaces
{
    public interface IRatesService
    {
        Task<List<CurrentRateContractModel>> GetCurrentRatesAsync();
        Task<int> ChangeRatesAsync(List<CurrentRateContractModel> rates);
        List<CurrentRateContractModel> GetCurrentRates();
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Contract.Interfaces;

namespace OnlineMarket.BusinessLogic.Services
{
    public class RatesService : IRatesService
    {
        private readonly IRatesUnitOfWork<CurrentRateContractModel, ExchangeRatesContractModel> _ratesUnitOfWork;

        public RatesService(IRatesUnitOfWork<CurrentRateContractModel, ExchangeRatesContractModel> ratesUnitOfWork)
        {
            _ratesUnitOfWork = ratesUnitOfWork;
        }

        public async Task<List<CurrentRateContractModel>> GetCurrentRatesAsync()
        {
            var data = await _ratesUnitOfWork.CurrentRateRepository.GetAllAsync();
            return data.ToList();
        }

        public async Task<int> ChangeRatesAsync(List<CurrentRateContractModel> rates)
        {
            rates.ForEach(x => { _ratesUnitOfWork.CurrentRateRepository.Update(x); });

            await _ratesUnitOfWork.ExchangeRatesRepository.CreateManyAsync(rates.Select(x => new ExchangeRatesContractModel
            {
                Rate = x.Rate,
                ItemTypeId = x.ItemTypeId
            }));

            return await _ratesUnitOfWork.SaveAsync();
        }

        public List<CurrentRateContractModel> GetCurrentRates()
        {
            return _ratesUnitOfWork.CurrentRateRepository.GetAll().ToList();
        }
    }
}

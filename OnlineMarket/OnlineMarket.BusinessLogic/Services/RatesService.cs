using System.Collections.Generic;
using System.Linq;
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

        public List<CurrentRateContractModel> GetCurrentRates()
        {
            return _ratesUnitOfWork.CurrentRateRepository.GetAll().ToList();
        }

        public void ChangeRates(List<CurrentRateContractModel> rates)
        {
            rates.ForEach(x => { _ratesUnitOfWork.CurrentRateRepository.Update(x); });

            _ratesUnitOfWork.ExchangeRatesRepository.CreateMany(rates.Select(x => new ExchangeRatesContractModel
            {
                ItemType = x.ItemType,
                Rate = x.Rate,
                ItemTypeId = x.ItemTypeId
            }));

            _ratesUnitOfWork.Save();
        }
    }
}

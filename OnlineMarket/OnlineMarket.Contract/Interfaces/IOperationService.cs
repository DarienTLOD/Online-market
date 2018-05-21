using OnlineMarket.Contract.ContractModels;

namespace OnlineMarket.Contract.Interfaces
{
    public interface IOperationService
    {
        void BuyItems(OperationContractModel operation);
    }
}

using AutoMapper;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.DataAccess.Entities;

namespace OnlineMarket.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AutoMapper.Mapper.Initialize(cfg => { cfg.CreateMap<CurrentRateContractModel, CurrentRateDataModel>(); });
            AutoMapper.Mapper.Initialize(cfg => { cfg.CreateMap<ExchangeRatesDataModel, ExchangeRatesDataModel>(); });
            AutoMapper.Mapper.Initialize(cfg => { cfg.CreateMap<StorageContactModel, StorageDataModel>(); });
            AutoMapper.Mapper.Initialize(cfg => { cfg.CreateMap<OperationArchiveContractModel, OperationArchiveDataModel>(); });
            AutoMapper.Mapper.Initialize(cfg => { cfg.CreateMap<AccountContractModel, AccountDataModel>(); });
            AutoMapper.Mapper.Initialize(cfg => { cfg.CreateMap<ItemTypeContractModel, ItemTypeDataModel>(); });
            AutoMapper.Mapper.Initialize(cfg => { cfg.CreateMap<StoreContractModel, StoreDataModel>(); });
        }
    }
}

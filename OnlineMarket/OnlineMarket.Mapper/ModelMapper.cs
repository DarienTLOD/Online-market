using AutoMapper;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.DataAccess.Entities;

namespace OnlineMarket.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AutoMapper.Mapper.Initialize(cfg => { cfg.CreateMap<UserContractModel, UserDataModel>(); });
        }
    }
}

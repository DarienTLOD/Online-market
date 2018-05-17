using Autofac;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Contract.Interfaces;
using OnlineMarket.DataAccess;
using OnlineMarket.DataAccess.Entities;
using OnlineMarket.DataAccess.Repositories;
using OnlineMarket.DataAccess.RepositoryAdapter;

namespace OnlineMarket.DependencyResolver.Modules
{
    public class DataAccesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(OnlineMarketUnitOfWork<>)).As(typeof(IOnlineMarketUnitOfWork<>));
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType(typeof(RepositoryAdapter<UserContractModel, UserDataModel>)).As(typeof(IRepository<UserContractModel>));
            builder.RegisterType<Context>().As<IContext>();
        }
    }
}

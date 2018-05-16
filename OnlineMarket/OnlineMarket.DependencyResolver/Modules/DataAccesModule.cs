using Autofac;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Contract.Interfaces;
using OnlineMarket.DataAccess;
using OnlineMarket.DataAccess.Repositories;

namespace OnlineMarket.DependencyResolver.Modules
{
    public class DataAccesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OnlineMarketUnitOfWork>().As<IOnlineMarketUnitOfWork>();
            builder.RegisterType<UsersRepository>().As<IRepositoryBase<UserContractModel>>();
            builder.RegisterType<Context>().As<IContext>();
        }
    }
}

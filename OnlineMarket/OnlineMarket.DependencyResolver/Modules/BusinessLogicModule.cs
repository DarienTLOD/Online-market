using Autofac;
using OnlineMarket.BusinessLogic.Services;
using OnlineMarket.Contract.Interfaces;

namespace OnlineMarket.DependencyResolver.Modules
{
    public class BusinessLogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<OperationService>().As<IOperationService>();
            builder.RegisterType<RatesService>().As<IRatesService>();
            builder.RegisterType<ItemsService>().As<IItemsService>();
            builder.RegisterType<AccountService>().As<IAccountService>();
        }
    }
}

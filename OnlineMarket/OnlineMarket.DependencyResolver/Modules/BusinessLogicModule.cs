using Autofac;
using OnlineMarket.BusinessLogic.Services;
using OnlineMarket.Contract.Interfaces;

namespace OnlineMarket.DependencyResolver.Modules
{
    public class BusinessLogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(AccountOwnerService<>)).As(typeof(IAccountOwnerService<>));
            builder.RegisterType<OperationService>().As<IOperationService>();
            builder.RegisterType<RatesService>().As<IRatesService>();
            builder.RegisterType<ItemsService>().As<IItemsService>();
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<EmailSender>().As<IEmailSender>();
        }
    }
}

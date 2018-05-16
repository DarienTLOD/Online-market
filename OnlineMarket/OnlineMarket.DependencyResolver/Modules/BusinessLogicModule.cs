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
        }
    }
}

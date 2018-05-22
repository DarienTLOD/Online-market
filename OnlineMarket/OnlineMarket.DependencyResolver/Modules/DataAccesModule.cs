using Autofac;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Contract.Interfaces;
using OnlineMarket.DataAccess;
using OnlineMarket.DataAccess.Entities;
using OnlineMarket.DataAccess.Repositories;
using OnlineMarket.DataAccess.RepositoryAdapter;
using OnlineMarket.DataAccess.UnitsOfWork;

namespace OnlineMarket.DependencyResolver.Modules
{
    public class DataAccesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(OnlineMarketUnitOfWork<>)).As(typeof(IOnlineMarketUnitOfWork<>));
            builder.RegisterGeneric(typeof(OperationUnitOfWork<,,,>)).As(typeof(IOperationUnitOfWork<,,,>));
            builder.RegisterGeneric(typeof(ItemssUnitOfWork<>)).As(typeof(IItemsUnitOfWork<>));
            builder.RegisterGeneric(typeof(RatesUnitOfWork<,>)).As(typeof(IRatesUnitOfWork<,>));
            builder.RegisterGeneric(typeof(AccountUnitOfWork<>)).As(typeof(IAccountUnitOfWork<>));
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType(typeof(RepositoryAdapter<UserContractModel, UserDataModel>)).As(typeof(IRepository<UserContractModel>));
            builder.RegisterType(typeof(RepositoryAdapter<AccountContractModel, AccountDataModel>)).As(typeof(IRepository<AccountContractModel>));
            builder.RegisterType(typeof(RepositoryAdapter<CurrentRateContractModel, CurrentRateDataModel>)).As(typeof(IRepository<CurrentRateContractModel>));
            builder.RegisterType(typeof(RepositoryAdapter<OperationArchiveContractModel, OperationArchiveDataModel>)).As(typeof(IRepository<OperationArchiveContractModel>));
            builder.RegisterType(typeof(RepositoryAdapter<ExchangeRatesContractModel, ExchangeRatesDataModel>)).As(typeof(IRepository<ExchangeRatesContractModel>));
            builder.RegisterType(typeof(RepositoryAdapter<StorageContactModel, StorageDataModel>)).As(typeof(IRepository<StorageContactModel>));
            builder.RegisterType(typeof(RepositoryAdapter<ItemTypeContractModel, ItemTypeDataModel>)).As(typeof(IRepository<ItemTypeContractModel>));
            builder.RegisterType(typeof(RepositoryAdapter<StoreContractModel, StoreDataModel>)).As(typeof(IRepository<StoreContractModel>));
            builder.RegisterType<Context>().As<IContext>();
        }
    }
}

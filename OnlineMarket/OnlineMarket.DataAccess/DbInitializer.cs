using OnlineMarket.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using OnlineMarket.Contract.ContractModels;

namespace OnlineMarket.DataAccess
{
    public static class DbInitializer
    {
        public static void Initialize(OnlineMarketContext context)
        {
            context.Database.EnsureCreated();

            if (context.ItemTypes.Any())
            {
                return;
            }

            var user = new UserContractModel { Email = "test@test.com" };
            var store = new StoreDataModel { Name = "testStore" };

            context.Users.Add(user);
            context.Store.Add(store);

            context.SaveChanges();

            var accounts = new List<AccountDataModel>()
            {
                new AccountDataModel { AccountOwnerId = user.Id, AvailableBalance = 10000 },
                new AccountDataModel { AccountOwnerId = store.Id, AvailableBalance = 1000000 }
            };

            context.Accounts.AddRange(accounts);
            context.SaveChanges();

            var itemTypes = new List<ItemTypeDataModel>
                {
                    new ItemTypeDataModel {Name = "Oil"},
                    new ItemTypeDataModel {Name = "Iron"},
                    new ItemTypeDataModel {Name = "Wood"}
                };

            context.ItemTypes.AddRange(itemTypes);
            context.SaveChanges();

            var storage = new List<StorageDataModel>();
            var exchangeRates = new List<ExchangeRatesDataModel>();

            itemTypes.ForEach(x =>
            {
                exchangeRates.Add(new ExchangeRatesDataModel { Rate = 15, ItemType = x, ItemTypeId = x.Id });
                storage.Add(new StorageDataModel { ItemTypeId = x.Id, ItemType = x, Account = accounts.First(), AccountId = accounts.First().Id, Quantity = 0, StorageAmount = 0 });
                storage.Add(new StorageDataModel { ItemTypeId = x.Id, ItemType = x, Account = accounts.Last(), AccountId = accounts.Last().Id, Quantity = 1000, StorageAmount = 15 * 1000 });
            });

            context.Storages.AddRange(storage);
            context.CurrentRates.AddRange(exchangeRates.Select(x => new CurrentRateDataModel
            {
                ItemType = x.ItemType,
                Rate = x.Rate,
                ItemTypeId = x.ItemTypeId
            }));

            context.ExchangeRates.AddRange(exchangeRates);

            context.SaveChanges();
        }
    }
}

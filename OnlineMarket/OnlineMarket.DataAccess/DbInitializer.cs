using OnlineMarket.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

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

            var user = new UserDataModel { Email = "test@test.com" };

            context.Users.Add(user);

            context.SaveChanges();

            var account = new AccountDataModel { AccountOwner = user, AccountOwnerId = user.Id, AvailableBalance = 10000 };

            context.Accounts.Add(account);
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
                storage.Add(new StorageDataModel { ItemTypeId = x.Id, ItemType = x, Account = account, AccountId = account.Id, Quantity = 0, StorageAmount = 0 });
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

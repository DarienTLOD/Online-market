using OnlineMarket.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OnlineMarket.Contract.ContractModels;

namespace OnlineMarket.DataAccess
{
    public class DbInitializer
    {
        public void Initialize(OnlineMarketContext context, RoleManager<IdentityRole> roleManager, UserManager<UserContractModel> userManager, IOptions<UserSettingsOptions> userSettings, IOptions<DefaultUserRolesOptions> roles)
        {
            context.Database.EnsureCreated();

            if (context.ItemTypes.Any())
            {
                return;
            }

            //Trying staff until it works
            foreach (var x in roles.Value.Roles)
            {
                var roleExist =  roleManager.RoleExistsAsync(x).Result;
                if (roleExist) continue;


                var unused = roleManager.CreateAsync(new IdentityRole(x)).Result;
            }

            var user = new UserContractModel
            {
                UserName = userSettings.Value.UserName,
                Email = userSettings.Value.UserEmail,
                EmailConfirmed = true
            };

            var createAdminUser = userManager.CreateAsync(user, userSettings.Value.UserPassword).Result;
            if (createAdminUser.Succeeded)
            {
                var unused = userManager.AddToRoleAsync(user, userSettings.Value.UserRole).Result;
            }

            var store = new StoreDataModel { Name = "testStore" };

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

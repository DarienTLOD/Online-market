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

            var itemTypes = new List<ItemTypeDataModel>
                {
                    new ItemTypeDataModel {Name = "Oil"},
                    new ItemTypeDataModel {Name = "Iron"},
                    new ItemTypeDataModel {Name = "Wood"}
                };

            context.ItemTypes.AddRange(itemTypes);
            context.SaveChanges();

            var exchangeRates = new List<ExchangeRatesDataModel>();

            itemTypes.ForEach(x =>
            {
                exchangeRates.Add(new ExchangeRatesDataModel { Rate = 15, ItemType = x, ItemTypeId = x.Id});
            });

            context.CurrentRates.AddRange(exchangeRates.Select(x=> new CurrentRateDataModel
            {
                ItemType = x.ItemType,
                BuyRate = x.Rate,
                ItemTypeId = x.ItemTypeId
            }));


            context.ExchangeRates.AddRange(exchangeRates);
        
            context.SaveChanges();
        }
    }
}

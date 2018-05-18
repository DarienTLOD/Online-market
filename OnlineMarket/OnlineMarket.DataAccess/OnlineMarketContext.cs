using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataAccess.Entities;

[assembly:InternalsVisibleTo("OnlineMarket.DependencyResolver")]
namespace OnlineMarket.DataAccess
{
    public sealed class OnlineMarketContext : DbContext
    {
        internal DbSet<UserDataModel> Users { get; set; }
        internal DbSet<AccountDataModel> Accounts { get; set; }
        internal DbSet<CurrentRateDataModel> CurrentRates { get; set; }
        internal DbSet<ExchangeRatesDataModel> ExchangeRates { get; set; }
        internal DbSet<ItemTypeDataModel> ItemTypes { get; set; }
        internal DbSet<OperationArchiveDataModel> OperationArchives { get; set; }
        internal DbSet<StorageDataModel> Storages { get; set; }
        internal DbSet<StoreDataModel> Store { get; set; }

        public OnlineMarketContext(DbContextOptions options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CurrentRateDataModel>().HasIndex(u => u.ItemTypeId).IsUnique();
            builder.Entity<ExchangeRatesDataModel>().Property(b => b.СhangeDate).HasDefaultValueSql("getdate()");
            builder.Entity<ExchangeRatesDataModel>().HasIndex(u => u.СhangeDate);
        }
    }
}

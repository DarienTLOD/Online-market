using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataAccess.Entities;

[assembly:InternalsVisibleTo("OnlineMarket.DependencyResolver")]
namespace OnlineMarket.DataAccess
{
    public sealed class OnlineMarketContext : DbContext
    {
        internal DbSet<UserDataModel> Users { get; set; }

        public OnlineMarketContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

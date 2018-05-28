using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.DataAccess;

namespace OnlineMarket.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<OnlineMarketContext>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = services.GetRequiredService<UserManager<UserContractModel>>();
                var userSettings = services.GetRequiredService<IOptions<UserSettingsOptions>>();
                var roles = services.GetRequiredService<IOptions<DefaultUserRolesOptions>>();
                new DbInitializer().Initialize(context, roleManager, userManager, userSettings, roles);
            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services.AddAutofac())
                .UseStartup<Startup>()
                .Build();
    }
}

using System;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.DataAccess;
using OnlineMarket.DependencyResolver.Modules;
using OnlineMarket.Web.Infrastructure;
using OnlineMarket.Web.WebSocket;

namespace OnlineMarket.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var settings = new JwtSettings();

            services.AddMvc();
            services.AddDbContext<OnlineMarketContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OnlineMarketDatabase")));
            services.AddOptions();
            services.Configure<AuthMessageSenderOptions>(Configuration.GetSection("SendGrid"));
            services.Configure<UserSettingsOptions>(Configuration.GetSection("UserSettings"));
            services.Configure<DefaultUserRolesOptions>(Configuration.GetSection("DefaultUserRoles"));
            services.Configure<DefaultNewUserRoleOptions>(Configuration.GetSection("DefaultNewUserRole"));
            services.Configure<EmailCredentials>(Configuration.GetSection("GmailAccount"));
            services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));
            services.AddWebSocketManager();

            Configuration.GetSection("JwtSettings").Bind(settings);
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            services.AddIdentity<UserContractModel, IdentityRole>(options =>
            {
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 2;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<OnlineMarketContext>().AddDefaultTokenProviders();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = settings.Issuer,
                        ValidAudience = settings.Audience,
                        IssuerSigningKey = JwtSecurityKey.Create(settings.SecretKey)
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAutoMapper();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            var builder = new ConfigurationBuilder();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                builder.AddUserSecrets<Startup>();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    ReactHotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseWebSockets(new WebSocketOptions());
            app.MapWebSocketManager("/rates", serviceProvider.GetService<RatesWebSocketHandler>());
            app.UseAuthentication();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new BusinessLogicModule());
            builder.RegisterModule(new DataAccesModule());
        }
    }
}


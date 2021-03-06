﻿using System;

using CryptoMarket.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using CryptoMarket.ViewModels;
using CryptoMarket.Services;

using CryptoMarket.Entities;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CryptoMarket
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public static IConfigurationRoot Configuration;
        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            //var builder = new ConfigurationBuilder()
            //    //Get base directory of the application,defined as the path to the directory containing the project.json file.
            //    .SetBasePath(appEnv.c)
            //    //Add the JSON Configuraiton provider at path to configuration builder
            //    .AddJsonFile("config.json")
            //    //Read configuration vaibles from PC environment e.g. api key set on one pc only for security reasons.
            //    .AddEnvironmentVariables();

            //Configuration = builder.Build();
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               //Add the JSON Configuraiton provider at path to configuration builder
               .AddJsonFile("config.json")
               //Read configuration vaibles from PC environment e.g. api key set on one pc only for security reasons.
               .AddEnvironmentVariables();
               

            //if (env.IsDevelopment())
            //{
            //    // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
            //    builder.AddUserSecrets();
            //}

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(38);
                options.CookieName = ".CryptoMarket";
            });

            services.AddMemoryCache();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminstratorOnlyRole", policy => policy.RequireRole("adminstrator", "vendor", "customer"));
                options.AddPolicy("VendorRole", policy => policy.RequireRole("vendor"));
                options.AddPolicy("CustomerRole", policy => policy.RequireRole("customer"));
            });

            services.AddAuthentication();



            //PriceService - A CryptoMarket custom service that leverages an exernal API            
            services.AddScoped<PriceService>();
            services.AddTransient<IPriceService, PriceService>();
            

            services.AddMvc(config => 
            {
                var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
#if !DEBUG
                config.Filters.Add(new RequireHttpsAttribute()); //Authentication
#endif
            })                
            .AddJsonOptions(opt =>
            { /*Results of api, property names are  camelcase,can be consumed by javascript 
            they would have the Entity property names with a first capital letter  .*/
                opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddIdentity<User, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 8;
                /*The redirect when users are not authenticated.*/                
                config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";
                config.Cookies.ApplicationCookie.LogoutPath = "/Auth/Logout";                
            })
            .AddEntityFrameworkStores<CryptoMarketContext>();
                                  

            services.AddDbContext<CryptoMarketContext>(options =>
                 options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));


            // services.AddScoped<IPriceService>();


            //Register the seeder here.
            services.AddScoped<CryptoMarketSeedData>();            
            services.AddScoped<ICryptoMarketRepository, CryptoMarketRepository>();

            services.AddLogging();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app,CryptoMarketSeedData seeder, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            //loggerFactory.AddDebug(LogLevel.Warning);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            else
            {
                app.UseExceptionHandler("/App/Error");
            }

            app.UseCookieAuthentication();
            //app.UseCookieAuthentication(options =>
            //{
            //    options.AuthenticationScheme = "Cookie";
            //    options.LoginPath = new PathString("/Account/Unauthorized/");
            //    options.AccessDeniedPath = new PathString("/Account/Forbidden/");
            //    options.AutomaticAuthenticate = true;
            //    options.AutomaticChallenge = true;
            //});



            app.UseStaticFiles(); //1. First check for static files

            app.UseIdentity(); //Second use identity before the MVC to ensure cookies,401 errors are processed.

            /*this allows us to specify all the configuration between the different types */
            Mapper.Initialize(config =>
           {
               config.CreateMap<PriceServicesResult, PriceBannerViewModel>().ReverseMap();
               config.CreateMap<Offer, OfferViewModel>().ReverseMap();
               config.CreateMap<Wallet,WalletViewModel>().ReverseMap();
               config.CreateMap<Client, ClientViewModel>().ReverseMap();
               config.CreateMap<Wallet, WalletViewModel>().ReverseMap();
               config.CreateMap<Currency, CurrencyViewModel>().ReverseMap();
               config.CreateMap<Currency, CurrencyCreateViewModel>().ReverseMap();

               config.CreateMap<PriceServicesResult, CurrencyData>()               
                .ForMember(dest => dest.Volume, opt => opt.MapFrom(src => src.Volume))
               .ForMember(dest => dest.CryptoCode, opt => opt.MapFrom(src => src.CryptoCode))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Volume, opt => opt.MapFrom(src => src.Volume))
                .ForMember(dest => dest.OneHourChange, opt => opt.MapFrom(src => src.OneHourChange));

           });

            // IMPORTANT: This session call MUST go before UseMvc()
            app.UseSession();
            
            //listen and expect requests in the style of Mvc
            app.UseMvc(routes =>
          {
              routes.MapRoute(
                  name: "Default",
                  template: "{controller}/{action}/{id?}",
                  defaults: new { controller = "App", action = "Index" ,startIndex = 0, pageSize = 0}
                  );
          });

            //Configure/Add  the seeding service here.
            
            seeder.EnsureClientSeedData();
            seeder.EnsureCurrencySeedData();
            seeder.EnsureWalletSeedData();
            seeder.EnsureImageSeedData();
            seeder.EnsureCurrencyDataSeedData();
            seeder.EnsureOfferSeedData();
            seeder.EnsureFiatCurrencySeedData();

            seeder.EnsureRolesSeedData();
            await seeder.EnsureUserSeedData();
            seeder.EnsureUserRolesSeedData();
            //await seeder.EnsureUserManagerSeedData();
        }

        // Entry point for the application.
        // public static void Main(string[] args) => WebApplication.Run<Startup>(args);
        //public static void Main(string[] args)
        //{
        //    var host = new Microsoft.AspNetCore.Hosting.WebHostBuilder()
        //        .UseContentRoot(Directory.GetCurrentDirectory())
        //        .UseIISIntegration()
        //        .UseStartup<Startup>()
        //        .Build();

        //    host.Run();
        //}
    }
}

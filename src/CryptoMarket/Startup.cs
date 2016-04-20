using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;

using CryptoMarket.Models;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CryptoMarket
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public static IConfigurationRoot Configuration;
        public Startup(IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
                //Get base directory of the application,defined as the path to the directory containing the project.json file.
                .SetBasePath(appEnv.ApplicationBasePath)
                //Add the JSON Configuraiton provider at path to configuration builder
                .AddJsonFile("config.json")
                //Read configuration vaibles from PC environment e.g. api key set on one pc only for security reasons.
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<CryptoMarketContext>();

            //Register the seeder here.
            services.AddScoped<CryptoMarketSeedData>();
            services.AddScoped<ICryptoMarketRepository, CryptoMarketRepository>();
            services.AddLogging();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,CryptoMarketSeedData seeder,ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug(LogLevel.Warning);

            app.UseStaticFiles();

            //listen and expect requests in the style of Mvc
            app.UseMvc(routes =>
          {
              routes.MapRoute(
                  name: "Default",
                  template: "{controller}/{action}/{id?}",
                  defaults: new { controller = "App", action = "Index" }
                  );
          });

            //Configure/Add  the seeding service here.
            seeder.EnsureClientSeedData();
            seeder.EnsureCurrencySeedData();
            seeder.EnsureWalletSeedData();
            seeder.EnsureImageSeedData();
        }

                // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}

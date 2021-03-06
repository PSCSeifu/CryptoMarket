

using CryptoMarket.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CryptoMarket.Models
{

    public class CryptoMarketContext : IdentityDbContext<User>
    {
        public CryptoMarketContext()
        {
            Database.EnsureCreated();
        }
        

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Client> Clients { get; set; }
        //public DbSet<Vendor> Vendors { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<FiatAccount> FiatAccounts { get; set; }        
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<CurrencyData> CurrencyData { get; set; }
        public DbSet<FiatCurrency> FiatCurrency { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuration["Data:CryptoMarketContextConnection"];

            optionsBuilder.UseSqlServer(connString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}

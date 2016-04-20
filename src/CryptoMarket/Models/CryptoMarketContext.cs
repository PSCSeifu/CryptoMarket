using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace CryptoMarket.Models
{
    
    public class CryptoMarketContext : DbContext
    {
        public CryptoMarketContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
       
      
        public DbSet<Relationship> Relationships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuration["Data:CryptoMarketContextConnection"];

            optionsBuilder.UseSqlServer(connString);

            base.OnConfiguring(optionsBuilder); 
        }
    }
}

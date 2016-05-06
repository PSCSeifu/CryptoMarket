using CryptoMarket.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class CryptoMarketSeedData
    {
        private CryptoMarketContext _context;
        private UserManager<User> _userManager;

        public CryptoMarketSeedData(CryptoMarketContext context,UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureUserManagerSeedData()
        {
            if (await _userManager.FindByEmailAsync("customer1@gmail.com") == null)
            {
                //Add the user.
                var newUser = new User()
                {
                    UserName = "xUser234",
                    Email = "customer1@gmail.com"
                };
                await _userManager.CreateAsync(newUser, "password1");
            }
        }

        public void EnsureClientSeedData()
        {
            if (!_context.Clients.Any())
            {
                var user1 = new Client()
                {
                    ClientType = "Customer",
                    Email = "customer1@gmail.com",
                    UserName = "xUser234",
                    Password = "P@ssw0rd123",
                    PasswordHash = "jdgf87st",
                    DateCreated =  DateTime.UtcNow,
                    DateModified= DateTime.UtcNow
            };

                var vendor1 = new Client()
                {
                    ClientType = "Vendor",
                    Email = "bittradingllc@bittrader.com",
                    UserName = "BitTraders",
                    Password = "trading345rft6y",
                    PasswordHash = "99jjjuu8",
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                _context.Clients.Add(user1);
                _context.Clients.Add(vendor1);
                _context.SaveChanges();
            }
        }

        public void EnsureCurrencySeedData()
        {
            if (!_context.Currencies.Any())
            {
                //Add New Currecy record.
                _context.Currencies.Add(new Currency()
                {
                    AvailableSupply = 15450225,
                    BirthDate = new DateTime(2010, 01, 01),
                    CurrencyCode = "BTC",
                    DayChange = 0.0183,
                    DayVolume = 41297.4,
                    Description = "The first and maket leader Crypto-currency. Based on Proof of work. Created by an unkown inventor by the alias Satoshi",
                    ImageId = 1,
                    ImageUrl = @"~/img/icon/btc.jpg",
                    LinkId = 0,
                    MarketCap = 6620684066,
                    Name = "BitCoin",/*Price = 438.52,*/
                    TypeId = 0,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                });

                _context.Currencies.Add(new Currency()
                {
                    AvailableSupply = 79226489,
                    BirthDate = new DateTime( 2014,01,01),
                    CurrencyCode = "ETH",
                    DayChange = -0.0455,
                    DayVolume = 11132.5,
                    Description = "The leading Crypto-currency with built in smart contract capabilites. Based on Proof of work as of early 2016.",
                    ImageId = 2,
                    ImageUrl = @"~/img/icon/eth.png",
                    LinkId = 0,
                    MarketCap = 726788951,
                    Name = "Ethereum",
                    //Price = 9.17,
                    TypeId = 0,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                });

                _context.Currencies.Add(new Currency()
                {
                    AvailableSupply = 34868679462,
                    BirthDate = new DateTime(2013,01, 01),
                    CurrencyCode = "XRP",
                    DayChange = 0.0009,
                    DayVolume = 631567,
                    Description = "Private block chain",
                    ImageId = 3,
                    ImageUrl= "~/~/img/icon/ripple.png",
                    LinkId = 0,
                    MarketCap = 245540010,
                    Name = "Ripple",
                    //Price = 0.007042,
                    TypeId = 0,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                });

                _context.Currencies.Add(new Currency()
                {
                    AvailableSupply = 45433751,
                    BirthDate = new DateTime( 2013,01,01),
                    CurrencyCode = "LTC",
                    DayChange = -0.0079,
                    DayVolume = 898997,
                    Description = "The second oldest and popular crypto currency.",
                    ImageId = 4,
                    ImageUrl= "~/img/icon/litecoin.png",
                    LinkId = 0,
                    MarketCap = 148703304,
                    Name = "LiteCoin",
                    //Price = 3.27,
                    TypeId = 0,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                });

                _context.Currencies.Add(new Currency()
                {
                    AvailableSupply = 6416736,
                    BirthDate = new DateTime(2013,01, 01),
                    CurrencyCode = "DASH",
                    DayChange = 0.0221,
                    DayVolume = 252145,
                    Description = "The popular crypto currency based on proof of stake and delegated moderation.",
                    ImageId = 5,
                    ImageUrl= "~/img/icon/dash.png",
                    LinkId = 0,
                    MarketCap = 40995327,
                    Name = "Dash",
                    //Price = 6.42,
                    TypeId = 0,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                });

                _context.Currencies.Add(new Currency()
                {
                    AvailableSupply = 452552412,
                    BirthDate = new DateTime(2014, 05, 01),
                    CurrencyCode = "MAID",
                    DayChange = 0.0221,
                    DayVolume = 252145,
                    Description = "",
                    ImageId = 6,
                    ImageUrl= "~/img/icon/maidsafe.png",
                    LinkId = 0,
                    MarketCap = 288220438,
                    Name = "MaiSafecoin",
                    //Price = 6.42,
                    TypeId = 0,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                });

                _context.Currencies.Add(new Currency()
                {
                    AvailableSupply = 104172336817,
                    BirthDate = new DateTime(2014, 05, 01),
                    CurrencyCode = "DOGE",
                    DayChange = 0.0221,
                    DayVolume = 252145,
                    Description = "",
                    ImageId = 7,
                    ImageUrl= "~/img/icon/dodge.png",
                    LinkId = 0,
                    MarketCap = 235528051,
                    Name = "DogeCoin",
                    //Price = 6.42,
                    TypeId = 0,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                });


                _context.SaveChanges();
            }
        }

        public  void EnsureCurrencyDataSeedData()
        {
            //Add new Base Currency data
            if (!_context.CurrencyData.Any())
            {
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "BTC", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "USD", FiatCode = "usd", Price = 0, FiatDescription = "United States of America Dollars", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "BTC", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "GBP", FiatCode = "gbp", Price = 0, FiatDescription = "United Kingdom Pound Sterling", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "BTC", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "EUR", FiatCode = "eur", Price = 0, FiatDescription = "European Union Euro", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });

                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "ETH", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "USD", FiatCode = "usd", Price = 0, FiatDescription = "United States of America Dollars", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "ETH", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "GBP", FiatCode = "gbp", Price = 0, FiatDescription = "United Kingdom Pound Sterling", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "ETH", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "EUR", FiatCode = "eur", Price = 0, FiatDescription = "European Union Euro", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });

                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "DASH", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "USD", FiatCode = "usd", Price = 0, FiatDescription = "United States of America Dollars", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "DASH", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "GBP", FiatCode = "gbp", Price = 0, FiatDescription = "United Kingdom Pound Sterling", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "DASH", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "EUR", FiatCode = "eur", Price = 0, FiatDescription = "European Union Euro", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });


                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "XRP", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "USD", FiatCode = "usd", Price = 0, FiatDescription = "United States of America Dollars", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "XRP", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "GBP", FiatCode = "gbp", Price = 0, FiatDescription = "United Kingdom Pound Sterling", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "XRP", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "EUR", FiatCode = "eur", Price = 0, FiatDescription = "European Union Euro", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });

                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "LTC", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "USD", FiatCode = "usd", Price = 0, FiatDescription = "United States of America Dollars", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });

                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "MAID", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "USD", FiatCode = "usd", Price = 0, FiatDescription = "United States of America Dollars", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "MAID", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "GBP", FiatCode = "gbp", Price = 0, FiatDescription = "United Kingdom Pound Sterling", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });

                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "DOGE", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "USD", FiatCode = "usd", Price = 0, FiatDescription = "United States of America Dollars", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "DOGE", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "GBP", FiatCode = "gbp", Price = 0, FiatDescription = "United Kingdom Pound Sterling", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "DOGE", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "EUR", FiatCode = "eur", Price = 0, FiatDescription = "European Union Euro", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });


                _context.SaveChanges();
            }
        }

        public void EnsureWalletSeedData()
        {
            //Add new wallet data
            if (!_context.Wallets.Any())
            {
                var bitwallet = new Wallet() {
                    Balance = 1.96,
                    ClientId = 1,
                    CurrencyId = 1,
                    Description = "My default Bitcoin wallet",
                    FiatAccountId = 1,
                    Name = "BitCoinMain",
                    PublicKey = "044322e2d4493111d73244c9c0ba8868cb17d64dcc22185ad30a6756d0fa201573668f8ac79ecc7 ",
                    Password = "",
                    TypeId=0   ,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                var bitwallet2 = new Wallet()
                {
                    Balance = 3.96,
                    ClientId = 1,
                    CurrencyId = 1,
                    Description = "My second Bitcoin wallet",
                    FiatAccountId = 1,
                    Name = "BitLong",
                    PublicKey = "03111d73244c9c0ba844322e2d449868cb17d64dcc22185ad30a6756d0fa201573668f8ac79ecc7 ",
                    Password = "",
                    TypeId = 0,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                var ethereum = new Wallet()
                {
                    Balance = 3.96,
                    ClientId = 1,
                    CurrencyId = 1,
                    Description = "My Eth wallet",
                    FiatAccountId = 1,
                    Name = "ETH_Main",
                    PublicKey = "02e2111d73244d4493c9c0ba844328683c9c0ba84cb17d64dcc22185ad30a6756d0fa201573668f8ac79ecc7 ",
                    Password = "",
                    TypeId = 0
                };

                var bitwallet3 = new Wallet()
                {
                    Balance = 3.96,
                    ClientId = 2,
                    CurrencyId = 1,
                    Description = "Company wallet One - BitCoin",
                    FiatAccountId = 1,
                    Name = "Trading-1-BitCoin",
                    PublicKey = "03c9c0ba844322e2111d73244d449868cb17d64dcc22185ad30a6756d0fa201573668f8ac79ecc7 ",
                    Password = "",
                    TypeId = 0,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                var ethereum2 = new Wallet()
                {
                    Balance = 3.96,
                    ClientId = 2,
                    CurrencyId = 1,
                    Description = "Company wallet One - Ethereum",
                    FiatAccountId = 1,
                    Name = "Trading-1-Ethereum",                    
                    PublicKey = "03c9c0ba844322e2111d73244d4498683c9c0ba84cb17d64dcc22185ad30a6756d0fa201573668f8ac79ecc7 ",
                    Password = "",
                    TypeId = 0,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                _context.Wallets.Add(bitwallet);
                _context.Wallets.Add(bitwallet2);
                _context.Wallets.Add(bitwallet3);
                _context.Wallets.Add(ethereum);
                _context.Wallets.Add(ethereum2);

                _context.SaveChanges();
                    

            }
        }

        public void EnsureImageSeedData()
        {
            if (!_context.Images.Any())
            {
                var image1 = new Image()
                {
                    Url = "",
                    TypeId = 1,
                    Description = "Icon",
                    DateCreated = DateTime.UtcNow,
                    DateModified=DateTime.UtcNow
                };
            }
        }
    }
}


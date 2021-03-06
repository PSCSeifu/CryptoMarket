using CryptoMarket.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public void EnsureUserRolesSeedData()
        {
            if (_context.Users.Any())
            {
                //Assign custom roles to the three seeded users.
                List<User> existingUsers = _context.Users.ToList();
                string defaultRole = "";
                var admin = existingUsers.Where(u => u.UserName == "admin").Select(u => u).FirstOrDefault();
                var customer = existingUsers.Where(u => u.UserName == "cust1").Select(u => u).FirstOrDefault();
                var vendor = existingUsers.Where(u => u.UserName == "vendor1").Select(u => u).FirstOrDefault();

                if (_context.Roles.Any())
                {
                    //Get Role Id (Primary keys)
                    List<IdentityRole> existingIdentityRoles = _context.Roles.ToList();
                    string adminRoleId = existingIdentityRoles.Where(r => r.Name == "adminstrator").Select(r => r.Id).FirstOrDefault() ?? defaultRole;
                    string customerRoleId = existingIdentityRoles.Where(r => r.Name == "customer").Select(r => r.Id).FirstOrDefault() ?? defaultRole;
                    string vendorRoleId = existingIdentityRoles.Where(r => r.Name == "vendor").Select(r => r.Id).FirstOrDefault() ?? defaultRole;

                    if (!_context.UserRoles.Any())
                    {
                        //Add admin Role                      
                        if (admin != null)
                        {
                            _context.UserRoles.Add(new IdentityUserRole<string> { UserId = admin.Id, RoleId = adminRoleId });                           
                        }

                        //Add cusotmer Role                    
                        if (admin != null)
                        {
                            _context.UserRoles.Add(new IdentityUserRole<string> { UserId = customer.Id, RoleId = customerRoleId });
                        }

                        //Add vendor Role                      
                        if (admin != null)
                        {
                            _context.UserRoles.Add(new IdentityUserRole<string> { UserId = vendor.Id, RoleId = vendorRoleId });
                        }
                    }
                    _context.SaveChanges();
                }
            }                
        }
        
        public void EnsureRolesSeedData()
        {
            if (!_context.Roles.Any())
            {   
                _context.Roles.Add(new IdentityRole() { Name = "adminstrator", NormalizedName = "adminstrator" });
                _context.Roles.Add(new IdentityRole() { Name = "customer", NormalizedName = "customer" });
                _context.Roles.Add(new IdentityRole() { Name = "vendor", NormalizedName = "vendor" });

                _context.SaveChanges();
            }
        }

        public async Task  EnsureUserSeedData()
        {
            if (! _context.Users.Any())
            {
                var admin = new User(){ UserName = "admin", Email = "admin@foo.com" };
                //await _userManager.AddToRoleAsync(admin, "Adminstrator");
                //await _userManager.AddToRoleAsync(admin, "customer");
                //await _userManager.AddToRoleAsync(admin, "vendor");
                await _userManager.CreateAsync(admin, "foobarNone1!");                

                var cust1 = new User() { UserName = "cust1", Email = "cust1@foo.com" };
                
                await _userManager.CreateAsync(cust1, "custNone1!");

                var vendor1 = new User() { UserName = "vendor1", Email = "vendor@foo.com" };               
                await _userManager.CreateAsync(vendor1, "vendorNone1!");

                _context.Users.Add(admin);
                _context.Users.Add(cust1);
                _context.Users.Add(vendor1);
                _context.SaveChanges();
            }
        }
        
        public void EnsureClientSeedData()
        {
            if (!_context.Clients.Any())
            {   
                _context.Clients.Add(new Client()
                {
                    UserId = "",
                    NickName = "Cust123",
                    ClientType = Enums.Enums.ClientType.customer,
                    PublicRating = 8.5,
                    AdminRating = 9.2,
                    Address1 = "101 Newmarrket Road",
                    Address2 = "Cambridge",
                    Address3 =  "CambridgeShire",
                    MailCode = "CB1 1AB",
                    Title= "Mr",
                    FirstName = "Thomas",
                    LastName ="Anderson",
                    CustomerTypeId = 4
                });

                _context.Clients.Add(new Client()
                {
                    UserId = "",
                    NickName = "pp34",
                    ClientType = Enums.Enums.ClientType.customer,
                    PublicRating = 4.5,
                    AdminRating = 6.2,
                    Address1 = "102 Random Road",
                    Address2 = "Bristol",
                    Address3 = "Bristol",
                    MailCode = "BR4 1AB",
                    Title = "Mr",
                    FirstName = "James",
                    LastName = "Simon",
                    CustomerTypeId = 2
                });

                _context.Clients.Add(new Client()
                {
                    UserId = "",
                    NickName = "Vend123",
                    ClientType = Enums.Enums.ClientType.vendor,
                    PublicRating = 9.5,
                    AdminRating = 9.8,
                    Address1 = "101 Ocean Road",
                    Address2 = "London",
                    Address3 = "Middlesex",
                    MailCode = "TW1 1AB",
                    VendorName = "Bit Trading LLC",
                    VendorTypeId= 2
                });

                _context.Clients.Add(new Client()
                {
                    UserId = "",
                    NickName = "Own23",
                    ClientType = Enums.Enums.ClientType.vendor,
                    PublicRating = 8.5,
                    AdminRating = 7.8,
                    Address1 = "101 Teaxs Close",
                    Address2 = "London",
                    Address3 = "Middlesex",
                    MailCode = "SW11 1AB",
                    VendorName = "TheCryptpCompany",
                    VendorTypeId = 1
                });
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
                    ImageUrl= "~/img/icon/ripple.png",
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
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "BTC", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "USD", FiatCode = "usd", FiatCodeSymbol = WebUtility.HtmlEncode("$"), Price = 0, FiatDescription = "United States of America Dollars", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "BTC", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "GBP", FiatCode = "gbp", FiatCodeSymbol = WebUtility.HtmlEncode("�"), Price = 0, FiatDescription = "United Kingdom Pound Sterling", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "BTC", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "EUR", FiatCode = "eur", FiatCodeSymbol = WebUtility.HtmlEncode("�"),Price = 0, FiatDescription = "European Union Euro", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });

                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "ETH", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "USD", FiatCode = "usd", FiatCodeSymbol = WebUtility.HtmlEncode("$"), Price = 0, FiatDescription = "United States of America Dollars", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "ETH", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "GBP", FiatCode = "gbp", FiatCodeSymbol = WebUtility.HtmlEncode("�"), Price = 0, FiatDescription = "United Kingdom Pound Sterling", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "ETH", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "EUR", FiatCode = "eur", FiatCodeSymbol = WebUtility.HtmlEncode("�"), Price = 0, FiatDescription = "European Union Euro", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });

                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "DASH", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "USD", FiatCode = "usd", FiatCodeSymbol = WebUtility.HtmlEncode("$"), Price = 0, FiatDescription = "United States of America Dollars", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "DASH", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "GBP", FiatCode = "gbp", FiatCodeSymbol = WebUtility.HtmlEncode("�"), Price = 0, FiatDescription = "United Kingdom Pound Sterling", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "DASH", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "EUR", FiatCode = "eur", FiatCodeSymbol = WebUtility.HtmlEncode("�"), Price = 0, FiatDescription = "European Union Euro", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });


                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "XRP", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "USD", FiatCode = "usd", FiatCodeSymbol = WebUtility.HtmlEncode("$"), Price = 0, FiatDescription = "United States of America Dollars", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "XRP", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "GBP", FiatCode = "gbp", FiatCodeSymbol = WebUtility.HtmlEncode("�"), Price = 0, FiatDescription = "United Kingdom Pound Sterling", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "XRP", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "EUR", FiatCode = "eur", FiatCodeSymbol = WebUtility.HtmlEncode("�"), Price = 0, FiatDescription = "European Union Euro", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });

                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "LTC", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "USD", FiatCode = "usd", FiatCodeSymbol = WebUtility.HtmlEncode("$"), Price = 0, FiatDescription = "United States of America Dollars", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });

                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "MAID", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "USD", FiatCode = "usd", FiatCodeSymbol = WebUtility.HtmlEncode("$"), Price = 0, FiatDescription = "United States of America Dollars", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "MAID", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "GBP", FiatCode = "gbp", FiatCodeSymbol = WebUtility.HtmlEncode("�"), Price = 0, FiatDescription = "United Kingdom Pound Sterling", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });

                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "DOGE", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "USD", FiatCode = "usd", FiatCodeSymbol = WebUtility.HtmlEncode("$"), Price = 0, FiatDescription = "United States of America Dollars", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "DOGE", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "GBP", FiatCode = "gbp", FiatCodeSymbol = WebUtility.HtmlEncode("�"), Price = 0, FiatDescription = "United Kingdom Pound Sterling", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });
                _context.CurrencyData.Add(new CurrencyData() { CryptoCode = "DOGE", DayChange = 0, Volume = 0, OneHourChange = 0, FiatPublicCode = "EUR", FiatCode = "eur", FiatCodeSymbol = WebUtility.HtmlEncode("�"), Price = 0, FiatDescription = "European Union Euro", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow });


                _context.SaveChanges();
            }
        }

        public void EnsureOfferSeedData()
        {
            if (!_context.Offers.Any())
            {
                _context.Offers.Add(new Offer() { ClientId=3,TypeId =1,Status= 2,FirstCurrency="BTC",SecondCurrency="ETH",MarketRate=2.3,MiningSpeed=12,Fee=2,Rate=2.3,Amount=0,MinLimit=0.3,MaxLimit=2.5,ParentId=0,TtlSeconds=3600 });
                _context.Offers.Add(new Offer() { ClientId = 3, TypeId = 1, Status = 3, FirstCurrency = "BTC", SecondCurrency = "ETH", MarketRate = 2.3, MiningSpeed = 12, Fee = 2, Rate = 2.3, Amount = 0, MinLimit = 0.3, MaxLimit = 2.5, ParentId = 0, TtlSeconds = 3600 });
                _context.Offers.Add(new Offer() { ClientId = 3, TypeId = 1, Status = 2, FirstCurrency = "DASH", SecondCurrency = "ETH", MarketRate = 2.3, MiningSpeed = 12, Fee = 2, Rate = 15.3, Amount = 0, MinLimit = 260, MaxLimit =10000, ParentId = 0, TtlSeconds = 3600 });
                _context.Offers.Add(new Offer() { ClientId = 4, TypeId = 1, Status = 1, FirstCurrency = "XRP", SecondCurrency = "DODGE", MarketRate = 2.3, MiningSpeed = 12, Fee = 8, Rate = 8.3, Amount = 0, MinLimit = 500, MaxLimit = 1500, ParentId = 0, TtlSeconds = 3600 });
                _context.Offers.Add(new Offer() { ClientId = 4, TypeId = 1, Status = 1, FirstCurrency = "BTC", SecondCurrency = "MAID", MarketRate = 2.3, MiningSpeed = 12, Fee = 7, Rate = 2.3, Amount = 0, MinLimit = 0.3, MaxLimit = 2.5, ParentId = 0, TtlSeconds = 3600 });
                _context.Offers.Add(new Offer() { ClientId = 3, TypeId = 1, Status = 5, FirstCurrency = "BTC", SecondCurrency = "DASH", MarketRate = 2.3, MiningSpeed = 12, Fee = 3, Rate = 0.3, Amount = 0, MinLimit = 0.3, MaxLimit = 2.5, ParentId = 0, TtlSeconds = 3600 });
                _context.Offers.Add(new Offer() { ClientId = 4, TypeId = 1, Status = 4, FirstCurrency = "ETH", SecondCurrency = "BTC", MarketRate = 2.3, MiningSpeed = 12, Fee = 2, Rate = 253, Amount = 0, MinLimit = 50, MaxLimit = 250, ParentId = 0, TtlSeconds = 3600 });

                _context.SaveChanges();
            }
        }

        public void EnsureWalletSeedData()
        {
            //Add new wallet data
            if (!_context.Wallets.Any())
            {
                var bitwallet = new Wallet()
                {
                    Balance = 1.96, ClientId = 1,CurrencyId = 1, Description = "My default Bitcoin wallet",
                    FiatAccountId = 1,  Name = "BitCoinMain",
                    PublicKey = "044322e2d4493111d73244c9c0ba8868cb17d64dcc22185ad30a6756d0fa201573668f8ac79ecc7 ",
                    Password = "", TypeId = 0
                };

                var bitwallet2 = new Wallet()
                {
                    Balance = 3.96,  ClientId = 1, CurrencyId = 1,
                    Description = "My second Bitcoin wallet", FiatAccountId = 1, Name = "BitLong",
                    PublicKey = "03111d73244c9c0ba844322e2d449868cb17d64dcc22185ad30a6756d0fa201573668f8ac79ecc7 ",
                    Password = "", TypeId = 0,
                    
                };

                var ethereum = new Wallet()
                {
                    Balance = 3.96,ClientId = 1,CurrencyId = 1,  Description = "My Eth wallet",
                    FiatAccountId = 1, Name = "ETH_Main",
                    PublicKey = "02e2111d73244d4493c9c0ba844328683c9c0ba84cb17d64dcc22185ad30a6756d0fa201573668f8ac79ecc7 ",
                    Password = "",TypeId = 0
                };

                var bitwallet3 = new Wallet()
                {
                    Balance = 3.96, ClientId = 2,CurrencyId = 1, Description = "Company wallet One - BitCoin",
                    FiatAccountId = 1, Name = "Trading-1-BitCoin",
                    PublicKey = "03c9c0ba844322e2111d73244d449868cb17d64dcc22185ad30a6756d0fa201573668f8ac79ecc7 ",
                    Password = "",TypeId = 0,                   
                };

                var ethereum2 = new Wallet()
                {
                    Balance = 3.96,ClientId = 2, CurrencyId = 1,   Description = "Company wallet One - Ethereum",  FiatAccountId = 1,Name = "Trading-1-Ethereum",
                    PublicKey = "03c9c0ba844322e2111d73244d4498683c9c0ba84cb17d64dcc22185ad30a6756d0fa201573668f8ac79ecc7 ",
                    Password = "",TypeId = 0,
                };

                var dash1 = new Wallet()
                {
                    Balance = 3.96,  ClientId = 3, CurrencyId = 5, Description = "CC One - Dash",FiatAccountId = 1, Name = "Main-Dash-v1.0",
                    PublicKey = "03c9c0b111d73244d449868cba844322e217d64dcc22185ad30a6756d0fa201573668f8ac79ecc7 ",
                    Password = "", TypeId = 0,
                };

                var dodge1 = new Wallet()
                {
                    Balance = 3.96,  ClientId = 4,  CurrencyId = 7, Description = "Much Dodge", FiatAccountId = 1,
                    Name = "SuchWallet",  PublicKey = "244c9c0ba844221803111d735ad30a6756d0fa201573668f8322e2d449868cb17d64dccac79ecc7 ",
                    Password = "",TypeId = 0,
                };
                _context.Wallets.Add(bitwallet);
                _context.Wallets.Add(bitwallet2);
                _context.Wallets.Add(bitwallet3);
                _context.Wallets.Add(ethereum);
                _context.Wallets.Add(ethereum2);
                _context.Wallets.Add(dash1);
                _context.Wallets.Add(dodge1);

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

        public void EnsureFiatCurrencySeedData()
        {
            if (!_context.FiatCurrency.Any())
            {
                _context.FiatCurrency.Add(new FiatCurrency() { Code = "usd", PublicCode ="USD",  ImageUrl = "~/img/icon/usd.png", Description = "United States of America Fedral Notes"});
                _context.FiatCurrency.Add(new FiatCurrency() { Code = "gbp", PublicCode = "GBP", ImageUrl = "~/img/icon/gbp.png", Description = "United Kingdom Sterling Pound" });
                _context.FiatCurrency.Add(new FiatCurrency() { Code = "eur", PublicCode = "EUR", ImageUrl = "~/img/icon/eur.png", Description = "European Union Euro" });
                _context.FiatCurrency.Add(new FiatCurrency() { Code = "aud", PublicCode = "AUD", ImageUrl = "~/img/icon/aud.png", Description = "Australian Dollar" });                
                _context.FiatCurrency.Add(new FiatCurrency() { Code = "rur", PublicCode = "RUR", ImageUrl = "~/img/icon/rur.png", Description = "Russian Federation Ruble" });
                _context.FiatCurrency.Add(new FiatCurrency() { Code = "cny", PublicCode = "CNY", ImageUrl = "~/img/icon/cny.png", Description = "People's Republic oF China Yuan" });
            }
        }
    }
}


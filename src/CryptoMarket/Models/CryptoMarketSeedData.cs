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

        public CryptoMarketSeedData(CryptoMarketContext context)
        {
            _context = context;
        }

        public void EnsureCurrencySeedData()
        {
            if (!_context.Currencies.Any())
            {
                //Add New Currecy record.
                var bitCoin = new Currency()
                {
                    AvailableSupply = 15450225,
                    BirthDate = new DateTime (01,01,2010),
                    CurrencyCode ="BTC",
                    DayChange = 0.0019,
                    DayVolume = 41297.4,
                    Description = "The first and maket leader Crypto-currency. Based on Proof of work. Created by an unkown inventor by the alias Satoshi",
                    LinkId = 0,
                    MarketCap = 6620684066,
                    Name = "BitCoin",
                    Price = 438.52,
                    TypeId = 0
                };

                var ethereum = new Currency()
                {
                    AvailableSupply = 79226489,
                    BirthDate = new DateTime(01, 01, 2014),
                    CurrencyCode = "ETH",
                    DayChange = 0.0077,
                    DayVolume = 11132.5,
                    Description = "The leading Crypto-currency with built in smart contract capabilites. Based on Proof of work as of early 2016.",
                    LinkId = 0,
                    MarketCap = 726788951,
                    Name = "Ethereum",
                    Price = 9.17,
                    TypeId = 0
                };
            }
        }

        public void EnsurewalletSeedData()
        {
            //Add new wallet data
            if (!_context.Wallets.Any())
            {
                var bitwallet = new Wallet() {
                    Balance = 1.96,
                    ClientId = 1,
                    CurrencyId = 1,
                    Description = "My default Bitcoin wallet",
                    FiatAccountId= 1,
                    Name = "BitCoinMain",
                    PublicKey= "044322e2d4493111d73244c9c0ba8868cb17d64dcc22185ad30a6756d0fa201573668f8ac79ecc7 ",
                    TypeId=0                    
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
                    TypeId = 0
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
                    TypeId = 0
                };

                var bitwallet3 = new Wallet()
                {
                    Balance = 3.96,
                    ClientId = 2,
                    CurrencyId = 1,
                    Description = "Company wallet One - BitCin",
                    FiatAccountId = 1,
                    Name = "Trading-1-BitCoin",
                    PublicKey = "03c9c0ba844322e2111d73244d449868cb17d64dcc22185ad30a6756d0fa201573668f8ac79ecc7 ",
                    TypeId = 0
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
                    TypeId = 0
                };

               
            }
        }
    }
}

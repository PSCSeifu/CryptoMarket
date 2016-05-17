using CryptoMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Services
{
    public class BasketService : IBasketService
    {
        private IBasketService _basketService;

        public BasketService(IBasketService basketService)
        {
            _basketService = basketService;
        }
              

        public List<Currency> GetTopCurrencies()
        {
            var data = new[]
            {
               new Currency
               {
                   Name = "SolarCoin",
                   CurrencyCode="SLR"
               },
                new Currency
               {
                   Name = "LightCoin",
                   CurrencyCode="LLT"
               }
           };

            return data.ToList();
        }
    }
}

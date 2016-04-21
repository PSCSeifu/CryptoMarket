using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Services
{
    public class PriceService
    {
        private ILogger<PriceService> _logger;

        public PriceService(ILogger<PriceService> logger)
        {
            _logger = logger;
        }

        public PriceServicesResult Lookup(string currency, string baseCurrency = null)
        {
            if (baseCurrency == null)
            {
                baseCurrency = Startup.Configuration["PriceService:DefaultBaseCurrency"];
            }

            var result = new PriceServicesResult() {
                Success = false,
                Error = "Unknown Error while looking for Price Service."
            };

            //Lookup prices
            var encodedCurrency = WebUtility.UrlEncode(currency);
            var encodedBaseCurrency = WebUtility.UrlEncode(baseCurrency);
            var url = $"https://www.cryptonator.com/api/ticker/{encodedCurrency}-{encodedBaseCurrency}";

            return result;
        }

    }
}

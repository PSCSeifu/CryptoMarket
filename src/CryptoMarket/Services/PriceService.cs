using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using CryptoMarket.Models;

namespace CryptoMarket.Services
{
    public class PriceService
    {
        private ILogger<PriceService> _logger;

        public PriceService(ILogger<PriceService> logger)
        {
            _logger = logger;
        }

        public async Task<PriceServicesResult> Lookup(string currency, string baseCurrency = null)
        {
            if (baseCurrency == null)
            {
                baseCurrency = Startup.Configuration["PriceService:DefaultBaseCurrency"];
            }

            var priceServiceRresult = new PriceServicesResult();
            

            //Lookup prices
            var encodedCurrency = WebUtility.UrlEncode(currency);
            var encodedBaseCurrency = WebUtility.UrlEncode(baseCurrency);
            var url = $"https://www.cryptonator.com/api/ticker/{encodedCurrency}-{encodedBaseCurrency}";

            var client = new HttpClient();
            var json = await client.GetStringAsync(url);
            var results = JObject.Parse(json);


            if (results == null || !(bool)results["success"])
            {
                priceServiceRresult.Success = (bool)results["success"];
                priceServiceRresult.Error = "Unknown Error while looking for Price Service.";
                return priceServiceRresult;
            }
            else
            {
                if ((bool)results["success"])
                {
                    priceServiceRresult.TimeStamp = (int)results["timestamp"];
                    priceServiceRresult.Success = (bool)results["success"];
                    var inner = JsonConvert.SerializeObject(results["ticker"]);
                    var innerResult = JObject.Parse(inner);

                    priceServiceRresult.FiatCode = (string)innerResult["target"]; ;
                    priceServiceRresult.CryptoCode = (string)innerResult["base"];
                    priceServiceRresult.Price = (double)innerResult["price"];
                    priceServiceRresult.Volume = (double)innerResult["volume"];
                }

                return priceServiceRresult;
            }
        }

        
    }
}

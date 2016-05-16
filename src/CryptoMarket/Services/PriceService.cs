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
using CryptoMarket.ViewComponents;

namespace CryptoMarket.Services
{
    public class PriceService : IPriceService
    {
        private ILogger<PriceService> _logger;
        private ICryptoMarketRepository _repository;

        public PriceService(ILogger<PriceService> logger,ICryptoMarketRepository repository)
        {
            _logger = logger;
            _repository = repository;
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

        public PriceServicesResult LookupSync(string currency, string baseCurrency = null)
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

            var results = GetJsonSync(url);


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

                    priceServiceRresult.FiatCode = (string)innerResult["target"]; 
                    priceServiceRresult.CryptoCode = (string)innerResult["base"];

                    priceServiceRresult.Price =String.IsNullOrWhiteSpace((string)innerResult["price"]) ? 0 :
                        (double)innerResult["price"];                    

                    priceServiceRresult.Volume = String.IsNullOrWhiteSpace ((string)innerResult["volume"]) ? 0:
                        (double)innerResult["volume"] ;

                    priceServiceRresult.OneHourChange = String.IsNullOrWhiteSpace((string)innerResult["change"]) ? 0 :
                        (double)innerResult["change"];
                }

                return priceServiceRresult;
            }
        }


        public IEnumerable<PriceServicesResult> GetBanner()
        {
            List<PriceServicesResult> model = new List<PriceServicesResult>();
            try
            {
                //List<Tuple<string, string>> CryptoFiatPairs = _repository.GetCryptoFiatPairs();
                List<Tuple<string, string>> CryptoFiatPairs = _repository.GetRandomCryptoAndFiatPair();

                foreach (var tuple in CryptoFiatPairs)
                {
                    var serviceResult = LookupSync(tuple.Item1, tuple.Item2);

                    // model.Add(await AutoMapper.Mapper.Map<PriceBannerViewComponent,PriceServicesResult>(serviceResult));
                    model.Add(serviceResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not construct price service result for fiat and Crypto pairs", ex);
                return null;
            }

            return model;
        }


        public async Task<IEnumerable<PriceServicesResult>> GetBannerAsync()
        {
            List<PriceServicesResult> model = new List<PriceServicesResult>();
            try
            {
                //List<Tuple<string, string>> CryptoFiatPairs = _repository.GetCryptoFiatPairs();
                List<Tuple<string, string>> CryptoFiatPairs = _repository.GetRandomCryptoAndFiatPair();

                foreach (var tuple in CryptoFiatPairs)
                {
                    var serviceResult = await Lookup(tuple.Item1, tuple.Item2);

                    // model.Add(await AutoMapper.Mapper.Map<PriceBannerViewComponent,PriceServicesResult>(serviceResult));
                    model.Add(serviceResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not construct price service result for fiat and Crypto pairs", ex);
                return null;
            }

            return model;
        }

        //private async Task<JObject> GetJsonAsync(string url)
        //{
        //    var client = new HttpClient();
        //    string json = await client.GetStringAsync(url);
        //    var results = JObject.Parse(json);

        //    return results;
        //}

        private  JObject GetJsonSync(string url)
        {
            var client = new HttpClient();
            var task =  client.GetStringAsync(url);
            task.Wait();             
            return  JObject.Parse(task.Result);            
        }
    }
}

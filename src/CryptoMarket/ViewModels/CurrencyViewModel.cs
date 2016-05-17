using CryptoMarket.Common;
using CryptoMarket.Models;
using CryptoMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.ViewModels
{
    public class CurrencyViewModel
    {
        private IPriceService _priceService;

        public Currency Currency { get; set; }
        public IEnumerable<CurrencyData> CurrencyData { get; set; } 

        public CurrencyViewModel(IPriceService priceService)
        {
            _priceService = priceService;
        }


        public IEnumerable<CurrencyData> GetLiveCurrencyData()
        {
            foreach (var data in this.CurrencyData)
            {
                PriceServicesResult result =  _priceService.LookupSync(this.Currency.CurrencyCode.ToLower(),
                    data.FiatCode.ToLower());

                data.Price = result.Price;
                data.Volume = result.Volume * result.Price;
                data.OneHourChange = result.OneHourChange;
                data.CryptoCode = result.CryptoCode;
                data.FiatCode = result.FiatCode;
                data.OneHourChange = result.OneHourChange;
                data.UnixTimeStamp = Util.UnixTimestampToDateTime( result.TimeStamp).ToLocalTime();
                data.FiatCodeSymbol = System.Net.WebUtility.HtmlEncode(data.FiatCodeSymbol);
            }

            return this.CurrencyData;
        }

      


        //public async Task<IEnumerable<CurrencyData>> GetLiveCurrencyData()
        //{
        //    //_priceservice = priceservice;

        //    foreach (var data in this.CurrencyData)
        //    {
        //        PriceServicesResult result = await  _priceService.Lookup(this.Currency.CurrencyCode.ToLower(),
        //            data.FiatCode.ToLower());

        //        data.Price = result.Price;
        //        data.Volume = result.Volume;
        //        data.OneHourChange = result.OneHourChange;
        //        data.CryptoCode = result.CryptoCode;
        //        data.FiatCode = result.FiatCode;
        //    }

        //    return this.CurrencyData;
        //}

    }
}

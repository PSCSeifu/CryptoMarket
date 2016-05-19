using CryptoMarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Services
{
    public interface IPriceService
    {
         //Task<PriceServicesResult> Lookup(string currency, string baseCurrency);
         PriceServicesResult LookupSync(string currency, string baseCurrency);
        //IEnumerable<PriceBannerViewModel> GetBanner();
        IEnumerable<PriceServicesResult> GetBanner();
        Task<IEnumerable<PriceServicesResult>> GetBannerAsync();
    }
}

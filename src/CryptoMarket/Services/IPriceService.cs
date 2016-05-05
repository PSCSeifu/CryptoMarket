using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Services
{
    public interface IPriceService
    {
         Task<PriceServicesResult> Lookup(string currency, string baseCurrency);
    }
}
using CryptoMarket.Models;
using System.Collections.Generic;

namespace CryptoMarket.Services
{
    public interface IBasketService
    {      
        List<Currency> GetTopCurrencies();
    }
}

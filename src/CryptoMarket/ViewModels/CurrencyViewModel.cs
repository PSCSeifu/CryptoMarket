using CryptoMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.ViewModels
{
    public class CurrencyViewModel
    {
       public Currency Currency { get; set; }
       public IEnumerable<CurrencyData> CurrencyData { get; set; }
    }
}

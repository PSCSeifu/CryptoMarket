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
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public double HourChange { get; set; }


        public IEnumerable<CurrencyData> CurrencyData { get; set; }
    }
}

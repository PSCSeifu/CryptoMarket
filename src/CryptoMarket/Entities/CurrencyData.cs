using CryptoMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class CurrencyData
    {
        public int Id { get; set; } = 0;

        public string CryptoCode { get; set; } = "";
        public string FiatCode { get; set; } = "";
        public double Price { get; set; } = 0;
        public double Volume { get; set; } = 0;
        public double OneHourChange { get; set; } = 0;

        public double DayChange { get; set; } = 0;
        public string FiatPublicCode { get; set; } = "";
        public string FiatDescription { get; set; } = "";

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; } = DateTime.UtcNow;

        public CurrencyData()
        {
        }
        
    }
}

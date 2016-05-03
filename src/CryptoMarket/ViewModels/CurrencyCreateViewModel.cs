using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.ViewModels
{
    public class CurrencyCreateViewModel
    {
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public string Description { get; set; }
        public double DayVolume { get; set; }
        public double DayChange { get; set; }
        
        public double AvailableSupply { get; set; }       
        public double MarketCap { get; set; }
        //public DateTime BirthDate { get; set; }

        //public int TypeId { get; set; }
        //public int LinkId { get; set; }
        //public int ImageId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.ViewModels
{
    public class PriceBannerViewModel
    {
        //up=1, none=0, down = -1
        public int ChangeDirection { get; set; }
        public string CryptoCode { get; set; }
        public string FiatCode { get; set; }
        public double CurrentPrice { get; set; }
    }
}

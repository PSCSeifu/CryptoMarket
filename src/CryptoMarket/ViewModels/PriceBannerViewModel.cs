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
        public string FiatCode { get; set; }
        public string CryptoCode { get; set; }
        public double Price { get; set; }
        public double Volume { get; set; }
        public double OneHourChange { get; set; }

        public string FiatCryptoCombo { get; set; }
        public string DisplayPrice { get; set; }

        public IEnumerable<PriceBannerViewModel> ToBannerDisplay(IEnumerable<PriceBannerViewModel> priceBannerViewModelCollection)
        {
            if(priceBannerViewModelCollection == null || priceBannerViewModelCollection.Count() < 1)
            {
                return priceBannerViewModelCollection;
            }

            foreach (var vm in priceBannerViewModelCollection)
            {
                if (vm.OneHourChange > 0) { vm.ChangeDirection = 1; }else if (vm.OneHourChange > 0) { vm.ChangeDirection = -1; } else { vm.ChangeDirection = 0; }
                if(vm.Price  < 1)
                {
                    vm.FiatCryptoCombo = String.Concat(vm.FiatCode, '/', vm.CryptoCode).ToUpper(); ;
                    //To 2 decimal places for currencies with fractional values per one unit of fiat.
                    vm.DisplayPrice = vm.Price.ToString("N9");
                }
                else
                {
                    vm.FiatCryptoCombo = String.Concat(vm.CryptoCode, '/', vm.FiatCode).ToUpper(); ;
                    //To 2 decimal places for currencies with above 1 fiat values per one unit of fiat.
                    vm.DisplayPrice = vm.Price.ToString("N2");
                }
            }

            return priceBannerViewModelCollection;
        }
    }
}

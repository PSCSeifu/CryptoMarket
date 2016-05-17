using CryptoMarket.Models;
using CryptoMarket.Services;
using CryptoMarket.ViewModels;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.ViewComponents
{
    [ViewComponent(Name = "PriceBanner")]
    public class PriceBannerViewComponent : ViewComponent
    {
        private  PriceService _priceService;
        private  ICryptoMarketRepository _repository;

        public PriceBannerViewComponent(PriceService priceService,ICryptoMarketRepository repository)
        {
            _priceService = priceService;
            _repository = repository;
          
        }

        //public async Task <IViewComponentResult> InvokeAsync()
        //{
        //    List<PriceServicesResult> model = new List<PriceServicesResult> ();
        //    try
        //    {
        //        List<Tuple<string, string>> CryptoFiatPairs = _repository.GetCryptoFiatPairs();

        //        foreach (var tuple in CryptoFiatPairs)
        //        {
        //            var serviceResult = await _priceService.Lookup(tuple.Item1, tuple.Item2);

        //            // model.Add(await AutoMapper.Mapper.Map<PriceBannerViewComponent,PriceServicesResult>(serviceResult));
        //            model.Add(serviceResult);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Could not construct price service result for fiat and Crypto pairs",ex);
        //        return null;
        //    }

        //    //return View("Default", model);
        //    return View("PriceBanner", model);
        //}

        //public IViewComponentResult Invoke()
        //{
        //    List<PriceServicesResult> model = new List<PriceServicesResult>();
        //    try
        //    {
        //        List<Tuple<string, string>> CryptoFiatPairs = _repository.GetCryptoFiatPairs();

        //        foreach (var tuple in CryptoFiatPairs)
        //        {
        //            var serviceResult =  _priceService.LookupSync(tuple.Item1, tuple.Item2);

        //            // model.Add(await AutoMapper.Mapper.Map<PriceBannerViewComponent,PriceServicesResult>(serviceResult));
        //            model.Add(serviceResult);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Could not construct price service result for fiat and Crypto pairs", ex);
        //        return null;
        //    }

        //    //return View("Default", model);
        //    return View("PriceBanner", model);
        //}

        public IViewComponentResult Invoke()
        {
            var model = _priceService.GetBanner();
            try
            {
                var vm = AutoMapper.Mapper.Map<IEnumerable<PriceBannerViewModel>>(model);
                PriceBannerViewModel vmi = new PriceBannerViewModel();
                vmi.ToBannerDisplay(vm);
                return View("PriceBanner", vm);
            }
            catch (Exception)
            {
                //_logger.LogError("Could not Invoke PriceBannerViewComponent (Sync).", ex);               
                return null;
            }
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _priceService.GetBannerAsync();

            try
            {
                var vm = AutoMapper.Mapper.Map<IEnumerable<PriceBannerViewModel>>(model);
                PriceBannerViewModel vmi = new PriceBannerViewModel();
                vmi.ToBannerDisplay(vm);
                return View("PriceBanner", vm);
            }
            catch (Exception)
            {
               // _logger.LogError("Could not InvokeAsync PriceBannerViewComponent.", ex);
                return null;
            }            
        }
    }
}

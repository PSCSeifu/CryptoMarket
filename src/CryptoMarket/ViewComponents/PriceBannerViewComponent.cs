using CryptoMarket.Models;
using CryptoMarket.Services;
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
        //private  ILogger _logger;
        private  PriceService _priceService;
        private  ICryptoMarketRepository _repository;

        public PriceBannerViewComponent(PriceService priceService,ICryptoMarketRepository repository)
        {
            _priceService = priceService;
            _repository = repository;
            //_logger = logger;
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
            return View("PriceBanner",model);
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _priceService.GetBannerAsync();
            return View("PriceBanner", model);
        }
    }
}

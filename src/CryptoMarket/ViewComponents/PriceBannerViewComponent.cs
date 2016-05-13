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
        private readonly ILogger _logger;
        private readonly IPriceService _priceService;
        private readonly ICryptoMarketRepository _repository;

        public PriceBannerViewComponent(IPriceService priceService,ICryptoMarketRepository repository,ILogger logger)
        {
            _priceService = priceService;
            _repository = repository;
            _logger = logger;
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {
            List<PriceServicesResult> model = new List<PriceServicesResult> ();
            try
            {
                List<Tuple<string, string>> CryptoFiatPairs = _repository.GetCryptoFiatPairs();

                foreach (var tuple in CryptoFiatPairs)
                {
                    var serviceResult = await _priceService.Lookup(tuple.Item1, tuple.Item2);

                    // model.Add(await AutoMapper.Mapper.Map<PriceBannerViewComponent,PriceServicesResult>(serviceResult));
                    model.Add(serviceResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not construct price service result for fiat and Crypto pairs",ex);
                return null;
            }

            return View("Default", model);
        }
    }
}

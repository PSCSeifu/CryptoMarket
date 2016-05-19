using CryptoMarket.Models;
using CryptoMarket.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.ViewComponents
{
    [ViewComponent (Name ="Test")]
    public class TestViewComponent :ViewComponent
    {
        private readonly ICryptoMarketRepository _repository;

        public TestViewComponent(ICryptoMarketRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            var result = _repository.GetAllCurrencies();

            //List<Tuple<string, string>> result = _repository.GetCryptoFiatPairs();

            return View("Test", result);
        }
    }
}

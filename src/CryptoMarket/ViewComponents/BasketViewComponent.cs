using CryptoMarket.Models;
using CryptoMarket.Services;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.ViewComponents
{
    [ViewComponent(Name ="Basket")]
    public class BasketViewComponent :ViewComponent
    {
        private CryptoMarketRepository _repository;

        public BasketViewComponent(CryptoMarketRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke(int id)
        {
            IEnumerable<Currency> model = _repository.GetAllCurrencies();            
            return View(model);
        }            
    }
}

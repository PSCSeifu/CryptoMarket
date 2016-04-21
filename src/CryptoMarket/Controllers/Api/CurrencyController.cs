using CryptoMarket.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Controllers.Api
{
    public class CurrencyController : Controller
    {
        private ICryptoMarketRepository _repository;

        public CurrencyController(ICryptoMarketRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("api/Currencies")]
        public JsonResult Get()
        {
            var results = _repository.GetAllCurrencies();
            return Json(results);
        }
    }
}

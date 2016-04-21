using CryptoMarket.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Controllers.Api
{
    public class WalletController : Controller
    {
        private ICryptoMarketRepository _repository;

        public WalletController(ICryptoMarketRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("api/wallets")]
        public JsonResult Get()
        {
            var results = _repository.GetAllWallets();
            return Json(results);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CryptoMarket.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoMarket.Controllers.Web
{
    public class AppController : Controller
    {
        private ICryptoMarketRepository _repository;

        public AppController(ICryptoMarketRepository repository)
        {
            _repository = repository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var wallets = _repository.GetAllWallets();
            return View(wallets);
        }

        // GET: /<controller>/
        public IActionResult About()
        {
            return View();
        }

        // GET: /<controller>/
        public IActionResult Contact()
        {
            return View();
        }

        // GET: /<controller>/
        public IActionResult Register()
        {
            return View();
        }

        // GET: /<controller>/
        public IActionResult Currency()
        {
            var currencyList = _repository.GetAllCurrencies();
            return View(currencyList);
        }

        // GET: /<controller>/
        public IActionResult UserProfile()
        {
            return View();
        }
    }
}

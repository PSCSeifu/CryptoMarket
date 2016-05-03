using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CryptoMarket.Models;
using Microsoft.AspNet.Authorization;
using CryptoMarket.ViewModels;
using AutoMapper;

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
            
            return View();
        }

        // GET: /<controller>/
        public IActionResult About()
        {
            return View();
        }

        // GET: /<controller>/
        public IActionResult Register()
        {
            return View();
        }

        // GET: /<controller>/
        public IActionResult Contact()
        {
            return View();
        }

        // GET: /<controller>/
        [Authorize]
        public IActionResult Client()
        {
            var wallets = _repository.GetAllClientsWithWallets();
            return View(wallets);            
        }



        // GET: /<controller>/

        public IActionResult Currency(string sortOrder,string searchString)
        {
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "Name" : "";
            ViewBag.DateSortParam = sortOrder == "Date" ? "BirthDate" : "Date";

            var currencyList = from c in _repository.GetAllCurrencies() select c;


            if (!string.IsNullOrEmpty(searchString))
            {
                currencyList = currencyList.Where(c => c.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Name":
                    currencyList = currencyList.OrderByDescending(c => c.Name);
                    break;
                case "Date":
                    currencyList = currencyList.OrderByDescending(c => c.BirthDate);
                    break;
                case "Code":
                    currencyList = currencyList.OrderByDescending(c => c.CurrencyCode);
                    break;
                case "Volume":
                    currencyList = currencyList.OrderByDescending(c => c.DayVolume);
                    break;
                case "Price":
                    currencyList = currencyList.OrderByDescending(c => c.CurrencyDataCollection.Max( d => d.Price));
                    break;
                default:
                    currencyList = currencyList.OrderByDescending(c => c.Name);                    
                    break;
            }

            return View(currencyList.ToList());
        }

        public IActionResult CurrencyDetail(int id)
        {
            var model = new CurrencyViewModel();
            model.Currency = _repository.GetCurrency(id);
            model.CurrencyData = _repository.GetCurrencyDataList(id);
            if( model.Currency == null)
            {
                return RedirectToAction("Currency", "App");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult CurrencyCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CurrencyCreate(CurrencyCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<CurrencyCreateViewModel, Currency>(vm);
                if (model == null)
                {
                    return RedirectToAction("CurrencyCreate", "App");
                }
                _repository.AddCurrency(model);
                return View(model);
            }
            return   RedirectToAction("CurrencyCreate", "App");
            //var model = new CurrencyCreateViewModel();
            //return View(model);
        }

        // GET: /<controller>/
        public IActionResult UserProfile()
        {
            return View();
        }
    }
}

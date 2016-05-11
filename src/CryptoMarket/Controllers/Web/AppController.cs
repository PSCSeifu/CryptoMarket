using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CryptoMarket.Models;
using Microsoft.AspNet.Authorization;
using CryptoMarket.ViewModels;
using AutoMapper;
using PagedList;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoMarket.Controllers.Web
{
    [Authorize]
    public class AppController : Controller
    {
        private ICryptoMarketRepository _repository;

        public AppController(ICryptoMarketRepository repository)
        {
            _repository = repository;
        }
        // GET: /<controller>/
        [AllowAnonymous]
        public IActionResult Index()
        {
            
            return View();
        }

        // GET: /<controller>/
        [AllowAnonymous]
        public IActionResult About()
        {
            return View();
        }

        // GET: /<controller>/
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        // GET: /<controller>/
        [AllowAnonymous]
        public IActionResult Contact()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Transaction()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Offer()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Realtion()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Wallet()
        {
            var wallet = _repository.GetAllWallets();
            return View(wallet);
        }

        [AllowAnonymous]
        public IActionResult FiatAccount()
        {
            return View();
        }


        #region " CLIENT "
        // GET: /<controller>/
        [Authorize]
        public IActionResult Client()
        {
            var allClients = _repository.GetAllClients();
            return View(allClients);            
        }

        [Authorize]
        public IActionResult ClientDetail(int id)
        {
            var model = new Client();
            model = _repository.GetClientById(id);
            if(model == null)
            {
                return RedirectToAction("Client", "App");
            }
            return View(model);
        }


        [Authorize]
        [HttpGet]
        public IActionResult ClientCreate()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult ClientCreate(ClientViewModel vm)
        {
            if (ModelState.IsValid && ModelState != null)
            {
                var model = Mapper.Map<ClientViewModel, Client>(vm);
                _repository.AddClient(model);

                //Implementing the post-redirect-get pattern
                return RedirectToAction("ClientDetail", "App", new  { id = model.Id });
            }
            return RedirectToAction("ClientCreate", "App");
        }

        #endregion

        #region " CURRENCY "
        // GET: /<controller>/

        public IActionResult Currency(string sortOrder,string searchString, int? page, int? pageSize )
        {
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.DateSortParam = sortOrder == "Date" ? "BirthDate_desc" : "BirthDate";
            ViewBag.CodeSortParam = sortOrder == "Code" ? "Code_desc" : "Code";
            ViewBag.VolumeSortParam = sortOrder == "Volume_desc" ? "Volume_desc" : "Volume";
            ViewBag.PriceSortParam = sortOrder == "Price" ? "Price_desc" : "Price";

            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentSearch = searchString;

            var currencyList = from c in _repository.GetAllCurrencies() select c;


            if (!string.IsNullOrEmpty(searchString))
            {
                currencyList = currencyList.Where(c => c.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Name":
                    currencyList = currencyList.OrderBy(c => c.Name).ThenBy( c => c.Name);
                    break;
                case "Name_desc":
                    currencyList = currencyList.OrderByDescending(c => c.Name).ThenBy(c => c.Name);
                    break;
                case "Date":
                    currencyList = currencyList.OrderBy(c => c.BirthDate).ThenBy(c => c.Name); ;
                    break;
                case "Date_desc":
                    currencyList = currencyList.OrderByDescending(c => c.BirthDate).ThenBy(c => c.Name); ;
                    break;
                case "Code":
                    currencyList = currencyList.OrderBy(c => c.CurrencyCode).ThenBy(c => c.Name); ;
                    break;
                case "Code_desc":
                    currencyList = currencyList.OrderByDescending(c => c.CurrencyCode).ThenBy(c => c.Name); ;
                    break;
                case "Volume":
                    currencyList = currencyList.OrderBy(c => c.DayVolume).ThenBy(c => c.Name); ;
                    break;
                case "Volume_desc":
                    currencyList = currencyList.OrderByDescending(c => c.DayVolume).ThenBy(c => c.Name); ;
                    break;
                case "Price":
                    currencyList = currencyList.OrderBy(c => c.CurrencyDataCollection.Max( d => d.Price)).ThenBy(c => c.Name); ;
                    break;
                case "Price_desc":
                    currencyList = currencyList.OrderByDescending(c => c.CurrencyDataCollection.Max(d => d.Price)).ThenBy(c => c.Name); ;
                    break;
                default:
                    currencyList = currencyList.OrderByDescending(c => c.Name).ThenBy(c => c.Name); ;                    
                    break;
            }

            //Alternative paginiation uses linq .Take & .Skip methods.
            

            int itemsPerPage = (pageSize < 1 ? 3: (int)pageSize) ;
            int pageNumber = page ?? 1;

            currencyList = currencyList.Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage);
            var paginatedCurrencies = new PagedList<Currency>(currencyList, pageNumber, itemsPerPage);

            //return View(currencyList.ToPagedList(pageNumber, itemsPerPage));

            return View(paginatedCurrencies);
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

        [Authorize]
        [HttpGet]
        public IActionResult CurrencyEdit(int id)
        {
            var model  = _repository.GetCurrency(id);
            var vm = Mapper.Map<Currency, CurrencyCreateViewModel>(model);
           
            if (vm == null)
            {
                return RedirectToAction("Currency", "App");
            }
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CurrencyEdit(int id, CurrencyCreateViewModel vm)
        {
            var currency = _repository.GetCurrency(id);
                        
            if (currency != null && ModelState.IsValid)
            {
                var model = Mapper.Map<CurrencyCreateViewModel, Currency>(vm);
                currency.Update(model);
                if (currency == null)
                {
                    return RedirectToAction("CurrencyCreate", "App");
                }
                _repository.Commit();

                //Implementing the POST-REDIRECT-GET Pattern.
                return RedirectToAction("CurrencyDetail", "App", new { id = currency.Id });
            }

            return View(vm);
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

                //Implementing the POST-REDIRECT-GET Pattern.
                return RedirectToAction("CurrencyDetail", "App", new { id = model.Id });
               
            }
            //return   RedirectToAction("CurrencyCreate","App");
            return View();
        }
         
    
        public IActionResult CurrencyDelete(CurrencyCreateViewModel vm)
        {
            int id = 0;
            var currency = _repository.GetCurrency(id);

            if (currency == null)
            {
                //A way to notify the use the record doesn't exist, in con-currency cases.
                return RedirectToAction("Currency", "App");
            }

            _repository.DeleteCurrency(id);
            return   RedirectToAction("Currency", "App");
        }
        #endregion " CURRENCY "

        
    }
}

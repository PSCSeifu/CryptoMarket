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
        private CryptoMarketContext _context;

        public AppController(CryptoMarketContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var wallets = _context.Wallets.ToList();
            return View();
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
        public IActionResult UserProfile()
        {
            return View();
        }
    }
}

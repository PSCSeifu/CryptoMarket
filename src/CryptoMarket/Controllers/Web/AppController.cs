using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoMarket.Controllers.Web
{
    public class AppController : Controller
    {
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

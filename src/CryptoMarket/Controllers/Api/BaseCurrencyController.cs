using CryptoMarket.Models;

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;

namespace CryptoMarket.Controllers.Api
{
    [Route("")]
    public class BaseCurrencyController : Controller
    {
       // private ILogger<ClientController> _logger;
        private ICryptoMarketRepository _repository;

        public BaseCurrencyController(ICryptoMarketRepository repository)
        {
            _repository = repository;
            //_logger = logger;
        }

        
    }
}

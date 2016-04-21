using CryptoMarket.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Controllers.Api
{
    [Route("")]
    public class BaseCurrencyController : Controller
    {
        private ILogger<ClientController> _logger;
        private ICryptoMarketRepository _repository;

        public BaseCurrencyController(ICryptoMarketRepository repository, ILogger<ClientController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        
    }
}

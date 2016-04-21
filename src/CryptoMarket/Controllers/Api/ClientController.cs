using CryptoMarket.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Controllers.Api
{
    [Route("api/clients")]
    public class ClientController : Controller
    {
        private ICryptoMarketRepository _repository;
        
        public ClientController(ICryptoMarketRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            var results = _repository.GetAllClients();
            return Json(results);
        }              

        [HttpPost("")]
        public JsonResult Post([FromBody]Client newClient)
        {
            return Json(true);
        }

        [HttpGet("api/Client/{id?}")]
        public JsonResult GetClient(string name)
        {
            var results = _repository.GetClient();
            return Json(results);
        }
    }
}

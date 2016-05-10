using AutoMapper;
using CryptoMarket.Models;
using CryptoMarket.ViewModels;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Controllers.Api
{
    [Route("api/clients")]
    public class ClientController : Controller
    {
        private ICryptoMarketRepository _repository;
        private ILogger<ClientController> _logger;

        public ClientController(ICryptoMarketRepository repository,ILogger<ClientController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            try
            {
                var results = Mapper.Map<IEnumerable<ClientViewModel>>(_repository.GetAllClientsWithWallets());
                if(results == null)
                {
                    return Json(null);
                }

                //simulate delay
                System.Threading.Thread.Sleep(3000);
                return Json(Mapper.Map<IEnumerable<ClientViewModel>>(results.OrderBy(c => c.NickName)));
              
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logger.LogError("Failed to get Clients from database.", ex);
                return Json("Error occured finding Clients");
            }            
        }              

        [HttpPost("")]
        public JsonResult Post([FromBody]ClientViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newClient = Mapper.Map<Client>(vm);

                    //Save to the data base 
                    _logger.LogInformation("Attempting to save a new Client");
                    _repository.AddClient(newClient);

                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<ClientViewModel>(newClient));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new Client", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message});
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }

        [HttpGet("api/Client/{id?}")]
        public JsonResult GetClient(string name)
        {
            var results = _repository.GetClient();
            return Json(results);
        }
    }
}

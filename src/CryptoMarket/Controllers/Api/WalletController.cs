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
    [Route("api/clients/{clientId}/wallets")]
    public class WalletController : Controller
    {
        private ILogger<WalletViewModel> _logger;
        private ICryptoMarketRepository _repository;

        public WalletController(ICryptoMarketRepository repository,ILogger<WalletViewModel> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get(int clientId)
        {
            try
            {
                var results = _repository.GetClientById(clientId);
                if(results == null)
                {
                    return Json(null);
                }
                
                return Json(Mapper.Map<IEnumerable<WalletViewModel>>(results.Wallets.OrderBy( w => w.DateCreated)));
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //$ C#6 interploation feature
                _logger.LogError($"Failed to get wallets for for ClientId{clientId}", ex);
                return Json("Error occured finding client Id");
            }           
        }

        public JsonResult Post(int clientId, [FromBody] WalletViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Map to the Entity
                    var newWallet = Mapper.Map<Wallet>(vm);

                    //Save data
                    _repository.AddWallet(clientId,newWallet);

                    //Save repositroy.
                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<WalletViewModel>(newWallet));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new Wallet", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }
        
    }
}

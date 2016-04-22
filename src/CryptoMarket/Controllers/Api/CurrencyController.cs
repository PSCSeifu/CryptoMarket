using AutoMapper;
using CryptoMarket.Models;
using CryptoMarket.Services;
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
    [Route("api/currencies")]
    public class CurrencyController : Controller
    {
        private ILogger<CurrencyController> _logger;
        private PriceService _priceService;
        private ICryptoMarketRepository _repository;

        public CurrencyController(ICryptoMarketRepository repository, ILogger<CurrencyController> logger, PriceService priceService)
        {
            _repository = repository;
            _logger = logger;
            _priceService = priceService;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            try
            {
                var results = _repository.GetAllCurrencies();
                if (results == null)
                {
                    return Json(null);
                }

                //return Json(Mapper.Map<IEnumerable<CurrencyViewModel>>(results.OrderBy (c => c.BaseCurrencies)));
                //return Json(Mapper.Map<IEnumerable<CurrencyViewModel>>
                //            (results.OrderBy(c => c.BaseCurrencies
                //                                .Select(b => b.ApiCode == Startup.Configuration["PriceService:DefaultBaseCurrency"])
                //                               )                                        
                //            ));
                return Json(Mapper.Map<IEnumerable<CurrencyViewModel>>(results));
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logger.LogError($"Failed to get Currecies from database.", ex);
                return Json("Error occured finding currency");
            }
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]CurrencyViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Map to Entity
                    var newCurrency = Mapper.Map<Currency>(vm);

                    //Add the base currency to the repository
                    //foreach (var baseCurr in Enum.GetValues(typeof(Enums.Enums.BaseCurrency)))
                    //{
                    //    //Looking up PriceService
                    //    var serviceResult = await _priceService.Lookup(newCurrency.CurrencyCode, baseCurr.ToString());

                    //    if (!serviceResult.Success)
                    //    {
                    //        Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //        Json(serviceResult.Error);
                    //    }

                    //    //Add new base currency to database,get its unique id.
                    //    var newCurrencyData = Mapper.Map<CurrencyData>(serviceResult);
                    //    _repository.AddCurrencyData(newCurrencyData);

                    //    int addedCurrencydDataID = _repository.CurrencyData(newCurrencyData);

                    //    if (addedCurrencydDataID != 0)
                    //    {
                    //        newCurrencyData.Id = addedCurrencydDataID;
                    //        //Add the base currency to the new Currency
                    //        newCurrency.CurrencyDataCollection.Add(newCurrencyData);
                    //    }
                    //}


                    //Save the currency to DataBase
                    _repository.AddCurrency(newCurrency);
                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<CurrencyViewModel>(newCurrency));
                    }
                }
            }
            catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logger.LogError("Failed to new Currency", ex);
                return Json(null);
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;           
            return Json(new { Message = "Failed", ModelState = ModelState});
        }
    }
}

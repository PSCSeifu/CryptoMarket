﻿using CryptoMarket.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.ViewComponents
{
    public class CurrencyTicker : ViewComponent
    {
        private PriceService _priceService;

        public CurrencyTicker(PriceService priceService)
        {
            _priceService = priceService;
        }

        public IViewComponentResult Invoke(string currency)
        {
            var model = _priceService.LookupSync(currency);
            return View("Default",model);
        }
    }
}

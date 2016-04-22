using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace CryptoMarket.Models
{
    public class CryptoMarketUser : IdentityUser
    {
        public DateTime FirstWallet { get; set; }
    }
}
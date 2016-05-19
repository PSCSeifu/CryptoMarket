
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace CryptoMarket.Models
{
    public class CryptoMarketUser : IdentityUser
    {
        public DateTime FirstWallet { get; set; }
    }
}
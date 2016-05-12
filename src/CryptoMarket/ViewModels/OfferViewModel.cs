using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.ViewModels
{
    public class OfferViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }

        
        public int TypeId { get; set; }
        public int Status { get; set; }
        [Required]
        public string FirstCurrency { get; set; }
        [Required]
        public string SecondCurrency { get; set; }
        [Required]
        public double MarketRate { get; set; }
        [Required]
        public int MiningSpeed { get; set; }
        [Required]
        public int Fee { get; set; }

        public double Rate { get; set; }
        public double Amount { get; set; }
        public double MinLimit { get; set; }
        public double MaxLimit { get; set; }
        [Required]
        public int TtlSeconds { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}

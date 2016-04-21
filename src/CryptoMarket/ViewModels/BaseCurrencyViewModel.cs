using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.ViewModels
{
    public class BaseCurrencyViewModel
    {
        public string PublicCode { get; set; }
        [Required]
        public string ApiCode { get; set; }
        public double Price { get; set; }
        [StringLength(256)]
        public string Description { get; set; }
    }
}

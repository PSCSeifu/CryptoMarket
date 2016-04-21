using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.ViewModels
{
    public class WalletViewModel
    {
        [Required]
        public int ClientId { get; set; }
        [StringLength(256, MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; } = DateTime.UtcNow;
    }
}

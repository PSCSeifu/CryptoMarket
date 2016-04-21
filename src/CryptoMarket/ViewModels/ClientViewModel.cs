using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255,MinimumLength = 5)]
        public string UserName { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public IEnumerable<WalletViewModel> Wallets { get; set; }
    }
}

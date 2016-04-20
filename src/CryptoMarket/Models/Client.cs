using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ClientType { get; set; }

        public ICollection<Offer> Offers { get; set; }
        public ICollection<Wallet> Wallets { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Relationship> Relationship { get; set; }
    }
}

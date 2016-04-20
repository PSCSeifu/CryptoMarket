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
        public string Password { get; set; }
        public string PasswordHash { get; set; }        
        public string Email { get; set; }
        public string ClientType { get; set; }
        public int ImageId { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Relationship> Relationship { get; set; }
    }
}

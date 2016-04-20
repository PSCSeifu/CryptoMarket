using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class Wallet
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        public int CurrencyId { get; set; }
        public int ImageId { get; set; }
        public int TypeId { get; set; }//Main,Fee,Charity,Buy,Sell,Normal
        public string Name { get; set; }
        public string Description { get; set; }
        public string PublicKey { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }
        public int FiatAccountId { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        

        public Wallet()
        {

        }   
    }
}

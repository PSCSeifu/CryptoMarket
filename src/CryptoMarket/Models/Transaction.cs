using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        public string OrderId { get; set; }        
        public int VendorWalletId { get; set; }
        public int CustomerId { get; set; }
        public int CustomerWalletId { get; set; }
        public int OfferId { get; set; }       
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public double Marigin { get; set; }
        public double Fee { get; set; }
        public double MarketRate { get; set; }

        public Transaction()
        {

        }
    }
}

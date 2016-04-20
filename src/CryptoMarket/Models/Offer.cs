using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        public int TypeId { get; set; }
        public int Status { get; set; }
        public string FirstCurrency { get; set; }
        public string SecondCurrency { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public double MinLimit { get; set; }
        public double MaxLimit { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public Offer()
        {

        }
    }
}

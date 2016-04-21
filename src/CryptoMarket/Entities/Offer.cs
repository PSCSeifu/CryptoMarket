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
        
        public int TypeId { get; set; }
        public int Status { get; set; }
        public string FirstCurrency { get; set; }
        public string SecondCurrency { get; set; }
        public double MarketRate { get; set; }
        /// <summary>
        /// Fast,Medium,Normal,Basic
        /// </summary>
        public int MiningSpeed { get; set; }
        /// <summary>
        /// System sets the Fee basedon Mining speed + its own Profit requirements
        /// </summary>
        public int Fee { get; set; }

        public double Rate { get; set; }
        public double Amount { get; set; }
        public double MinLimit { get; set; }
        public double MaxLimit { get; set; }
        /// <summary>
        /// Number of counter offers a customer can make on this offer.
        /// </summary>
        public int CounterOfferLimit { get; set; }


        /// <summary>
        /// If 0, then this is an original offer, not a counter offer
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// Time in seconds from DateCreated, after which a counter offer expires.
        /// </summary>
        public int TtlSeconds { get; set; }


        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public Image Image { get; set; }

        public Offer()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public int TypeId { get; set; }
        public string Description { get; set; }
        public int LinkId { get; set; }
        public double DayVolume { get; set; }
        public double DayChange { get; set; }
        public double Price { get; set; }
        public double  AvailableSupply { get; set; }

        public double MarketCap { get; set; }
        public DateTime BirthDate { get; set; }


        public Currency()
        {

        }
    }
}

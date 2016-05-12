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
        [Required,MaxLength(50)]  
        public string Name { get; set; }
        [Required,MaxLength(6)]
        public string CurrencyCode { get; set; }
        public int TypeId { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public int LinkId { get; set; }
     
        public double DayVolume { get; set; }
       
        public double DayChange { get; set; }

        public double HourChange { get; set; }

       
        public double  AvailableSupply { get; set; }
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }

       
        public double MarketCap { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public ICollection<CurrencyData> CurrencyDataCollection { get; set; }

        public Currency()
        {

        }

        public void Update(Currency input)
        {
            this.Name = input.Name;
            this.CurrencyCode = input.CurrencyCode;
            this.Description = input.Description;
            this.DayVolume = input.DayVolume;
            this.DayChange = input.DayChange;
            this.AvailableSupply = input.AvailableSupply;
            this.MarketCap = input.MarketCap;
            this.ImageUrl = input.ImageUrl;
        }
    }
}

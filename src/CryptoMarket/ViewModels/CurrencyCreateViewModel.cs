using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.ViewModels
{
    public class CurrencyCreateViewModel
    {
        [HiddenInput(DisplayValue =false)]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        //[Required, RegularExpression("[A-Z)]"), MaxLength(6)]
        public string CurrencyCode { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        //[RegularExpression("[(0-9)]")]
        public double DayVolume { get; set; }
        //[RegularExpression("[(0-9)]")]
        public double DayChange { get; set; }
        //[RegularExpression("[(0-9)]")]
        public double AvailableSupply { get; set; }
        //[RegularExpression("[(0-9)]")]
        public double MarketCap { get; set; }

        public string ImageUrl { get; set; }
        //public DateTime BirthDate { get; set; }

        //public int TypeId { get; set; }
        //public int LinkId { get; set; }
        //public int ImageId { get; set; }
    }
}

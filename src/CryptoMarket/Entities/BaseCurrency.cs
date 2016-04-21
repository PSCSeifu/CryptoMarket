using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class BaseCurrency
    {
        public int Id { get; set; }
        public string PublicCode { get; set; }
        public string ApiCode { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; } = DateTime.UtcNow;

        public BaseCurrency()
        {

        }
    }
}

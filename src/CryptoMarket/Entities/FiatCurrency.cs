using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class FiatCurrency
    {
        public int Id { get; set; }
        public string Code { get; set; } = "";
        public string PublicCode { get; set; } = "";
        public string Description { get; set; } = "";
        public string ImageUrl { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; } = DateTime.UtcNow;
    }
}

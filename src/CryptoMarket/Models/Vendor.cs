using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class Vendor : Client
    {            
        public string Name { get; set; }       
        public int CustomerCount { get; set; }
        public int TransactionCount { get; set; }
        public int PublicRating { get; set; }
        public int VendorTypeId { get; set; }

       
        public Vendor()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class Vendor
    {
        public string Name { get; set; }       
        public int CustomerCount { get; set; }
        public int TransactionCount { get; set; }
        public double PublicRating { get; set; }
        public double Rating { get; set; }//for admin
        public int VendorTypeId { get; set; }
        
        public Vendor()
        {

        }
    }
}

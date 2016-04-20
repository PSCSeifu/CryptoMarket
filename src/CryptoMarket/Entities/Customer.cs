using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class Customer : Client
    {       
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string MailCode { get; set; }
        public string Country { get; set; }
    
        public int CustomerTypeId { get; set; }

        public Customer()
        {

        }
    }
}

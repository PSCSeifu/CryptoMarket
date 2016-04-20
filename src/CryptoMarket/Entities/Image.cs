using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int TypeId  { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public Image()
        {

        }
    }
}

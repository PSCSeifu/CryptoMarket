using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoMarket.Models
{
    public class FiatAccount
    {
        public int Id { get; set; }
        [ForeignKey("ClientID")]
        public int ClientId { get; set; }
        /// <summary>
        /// Paypal,WesternUnion,Debit,Credit
        /// </summary>
        public int AccountTypeId  { get; set; }
        public double AvailableBalance { get; set; }
        public double WithDrawLimit { get; set; }
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public FiatAccount()
        {

        }
    }
}

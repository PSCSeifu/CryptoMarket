using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.ViewModels
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [Required]
        public string OrderId { get; set; }
        public int VendorWalletId { get; set; }
        public int CustomerId { get; set; }
        public int CustomerWalletId { get; set; }
        public int StatusId { get; set; }
        public double StatusLevel { get; set; }

        public int OfferHistoryId { get; set; }
        public double Amount { get; set; }
        public double Marigin { get; set; }
        public double Fee { get; set; }
        public double MarketRate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateModified { get; set; }
    }
}

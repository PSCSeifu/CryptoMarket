using CryptoMarket.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptoMarket.ViewModels
{
    public class ClientViewModel
    {
        public string UserId { get; set; }
        [Required,MaxLength(20),MinLength(2)]
        public string NickName { get; set; } = "";
        public Enums.Enums.ClientType ClientType { get; set; } = Enums.Enums.ClientType.customer;
        [Required]
        public double PublicRating { get; set; } = 0;
        [Required]
        public double AdminRating { get; set; } = 0;//for admin only =0;
        public string Title { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

        public string VendorName { get; set; } = "";
        public int VendorTypeId { get; set; }

        public string Address1 { get; set; } = "";
        public string Address2 { get; set; } = "";
        public string Address3 { get; set; } = "";
        public string MailCode { get; set; } = "";
        public string Country { get; set; } = "";

        public virtual ICollection<Wallet> Wallets { get; set; }
    }
}

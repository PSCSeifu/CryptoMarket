using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }

        public string NickName { get; set; } = "";
        public Enums.Enums.ClientType ClientType { get; set; } = Enums.Enums.ClientType.customer;
        public double PublicRating { get; set; } = 0;
        public double AdminRating { get; set; } = 0;//for admin only =0;
        public int ImageId { get; set; }
        public string Address1 { get; set; } = "";
        public string Address2 { get; set; } = "";
        public string Address3 { get; set; } = "";
        public string MailCode { get; set; } = "";
        public string Country { get; set; } = "";
        public int EmailId { get; set; } //Main/trading,forum etc        

        #region Customer
        public string Title { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int CustomerTypeId { get; set; }
        #endregion

        #region Vedor
        public string VendorName { get; set; } = "";
        public int VendorTypeId { get; set; }
        #endregion 

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Relationship> Relationship { get; set; }
    }
}

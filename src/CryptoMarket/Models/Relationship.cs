using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Models
{
    public class Relationship
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        public int TypeId { get; set; }
        public int FriendId { get; set; }
        public double TrustLevel { get; set; }
        
        public Relationship()
        {

        }
    }
}
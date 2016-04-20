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
        public int TypeId { get; set; }
        public int RelationshipId { get; set; }
        public double TrustLevel { get; set; }
        /// <summary>
        /// Favourite,Business,Prospective
        /// </summary>
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public Relationship()
        {

        }
    }
}
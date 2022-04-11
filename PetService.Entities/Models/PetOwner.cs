using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace PetService.Entities.Models
{
    public class PetOwner
    {
        [Key]
        public int PetOwnerId { get; set; }
        [Required]
        public string OwnerName { get; set; }
        [Required]
        public string OwnerCity { get; set; }
        
        public ICollection<Pet> Pets { get; set; }
    }
}

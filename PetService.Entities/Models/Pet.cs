using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace PetService.Entities.Models
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }
        [Required]
        public string PetName { get; set; }
        [Required]
        public int PetAge{ get; set; }
        public int PetOwnerId { get; set; }
        [JsonIgnore]
        public PetOwner PetOwner { get; set; }
    }
}

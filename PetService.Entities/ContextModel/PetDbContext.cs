using Microsoft.EntityFrameworkCore;
using PetService.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetService.Entities.ContextModel
{
   public class PetDbContext: DbContext
    {
        public PetDbContext(DbContextOptions<PetDbContext> options) : base(options)
        { 
        }

       public DbSet<Pet> Pets { get; set; }
       public DbSet<PetOwner>  PetOwners { get; set; }
    }
}

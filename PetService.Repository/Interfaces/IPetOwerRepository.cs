using PetService.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetService.Repository.Interfaces
{
   public interface IPetOwerRepository
    {
        Task<IEnumerable<PetOwner>> GetAllPetOwners();
        Task<PetOwner> GetPetOwnerById(int petPetOwnerId);
        Task<PetOwner> CreatePetOwner(PetOwner  petOwner);
        Task<PetOwner> UpdatePetOwner( PetOwner petOwner);
        Task<bool> DeletePetOwnerById(int petPetOwnerId);

    }
}

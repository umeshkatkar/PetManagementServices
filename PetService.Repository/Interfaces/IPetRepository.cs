using PetService.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetService.Repository.Interfaces
{
   public interface IPetRepository
    {
        Task<IEnumerable<Pet>> GetAllPets();
        Task<Pet> GetPetById(int petId);
        Task<Pet> CreatePet(Pet school);
        Task<Pet> UpdatePet(Pet school);
        Task<bool> DeletePetById(int petId);

  }
}

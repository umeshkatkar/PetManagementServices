using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetService.Entities.ContextModel;
using PetService.Entities.Models;
using PetService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetService.Repository
{
    public class PetRepository : IPetRepository
    {
        private PetDbContext _petDbContext;
        private readonly ILogger<PetRepository> _logger;

        public PetRepository(PetDbContext petDbContext, ILogger<PetRepository> logger)
        {
            _petDbContext = petDbContext;
            _logger = logger;
        }

        public async Task<Pet> CreatePet(Pet pet)
        {
            try
            {
                await _petDbContext.AddAsync(pet);
                var recordsAffected = await _petDbContext.SaveChangesAsync();
                if (recordsAffected > 0)
                {
                    return await _petDbContext.Pets.FirstOrDefaultAsync(x => x.PetId == pet.PetId);

                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Exception occured in PetRepository.CreatePet", ex);
                throw;
            }
            return null;
        }

        public  async Task<bool> DeletePetById(int petId)
        {
            try
            {
                int recordsAffected = 0;
                var response = await _petDbContext.Pets.FindAsync(petId);
                if (response != null)
                {
                    _petDbContext?.Pets?.Remove(response);
                    recordsAffected = await _petDbContext?.SaveChangesAsync();
                }
                return recordsAffected > 0 ? true : false;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Exception occured in PetRepository.DeletePet", ex);
                throw;
            }
        }

        public async Task<IEnumerable<Pet>> GetAllPets()
        {
            try
            {
                return await _petDbContext.Pets.ToListAsync();

            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Exception occured in PetRepository.GetAllPets", ex);
                throw;
            }
        }
        public async Task<Pet> GetPetById(int petId)
        {
            try
            {
                return await _petDbContext.Pets.FirstOrDefaultAsync(x=>x.PetId==petId);

            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Exception occured in PetRepository.GetPetById", ex);
                throw;
            }
        }

        public async Task<Pet> UpdatePet(Pet pet)
        {
            try
            {
                _petDbContext.Pets.Update(pet);
                int affectedCount = await _petDbContext.SaveChangesAsync();
                return affectedCount > 0 ? pet : null;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Exception occured PetRepository.UpdatePet", ex);
                throw;
            }
        }
    }
}

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
    public class PetOwerRepository : IPetOwerRepository
    {
        private PetDbContext _petDbContext;
        private readonly ILogger<PetOwerRepository> _logger;

        public PetOwerRepository(PetDbContext petDbContext, ILogger<PetOwerRepository> logger)
        {
            _petDbContext = petDbContext;
            _logger = logger;
        }

        public async Task<PetOwner> CreatePetOwner(PetOwner petOwner)
        {
            try
            {
                await _petDbContext.AddAsync(petOwner);
                var recordsAffected = await _petDbContext.SaveChangesAsync();
                if (recordsAffected > 0)
                {
                    return await _petDbContext.PetOwners.FirstOrDefaultAsync(x => x.PetOwnerId == petOwner.PetOwnerId);

                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Exception occured in PetOwnerRepository.CreatePetOwner", ex);
                throw;
            }
            return null;
        }

        public async Task<bool> DeletePetOwnerById(int petPetOwnerId)
        {
            try
            {
                int recordsAffected = 0;
                var response = await _petDbContext.PetOwners.FindAsync(petPetOwnerId);
                if (response != null)
                {
                    _petDbContext?.PetOwners?.Remove(response);
                    recordsAffected = await _petDbContext?.SaveChangesAsync();
                }
                return recordsAffected > 0 ? true : false;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Exception occured in PetOwerRepository.DeletePetOwner", ex);
                throw;
            }
        }

        public async Task<IEnumerable<PetOwner>> GetAllPetOwners()
        {
            try
            {
                return await _petDbContext.PetOwners?.Include(x=>x.Pets)?.ToListAsync();

            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Exception occured in PetOwerRepository.GetAllPetOwners", ex);
                throw;
            }
        }
        public async Task<PetOwner> GetPetOwnerById(int petPetOwnerId)
        {
            try
            {
                return await _petDbContext.PetOwners?.FirstOrDefaultAsync(x => x.PetOwnerId == petPetOwnerId);

            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Exception occured in PetOwerRepository.GetPetById", ex);
                throw;
            }
        }

        public async Task<PetOwner> UpdatePetOwner( PetOwner petOwner)
        {
            try
            {
                _petDbContext.PetOwners.Update(petOwner);
                int affectedCount = await _petDbContext.SaveChangesAsync();
                return affectedCount > 0 ? petOwner : null;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Exception occured in PetOwerRepository.UpdatePetOwners", ex);
                throw;
            }
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetService.Entities.Models;
using PetService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetWebServices.Controllers
{
    [ApiController]
    public class PetOwnerController : ControllerBase
    {
        private readonly IPetOwerRepository _petOwnerRepository;
        private readonly ILogger<PetOwnerController> _logger;
        public PetOwnerController(IPetOwerRepository petOwnerRepository, ILogger<PetOwnerController> logger)
        {
            _petOwnerRepository = petOwnerRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("/api/GetAllPetOwners")]
        public async Task<ActionResult> GetAllPetOwners()
        {
            try
            {
                var response = await _petOwnerRepository.GetAllPetOwners();
                if (response != null)
                    return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Exception occured in PetOwnerController.GetAllPetOwners", ex);
                throw;
            }
            return NotFound();
        }

        [HttpPost]
        [Route("/api/CreatePetOwner")]
        public async Task<ActionResult> CreatePetOwner(PetOwner petOwner)
        {
            try
            {
                if (petOwner == null)
                    return BadRequest();

                var response = await _petOwnerRepository.CreatePetOwner(petOwner);
                if (response != null)
                    return Created("/CreatePetOwner", response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Exception occured in PetOwnerController.CreatePetOwner", ex);
                throw;
            }
            return null;
        }

        [HttpPut("/api/UpdatePetOwner/{petPetOwnerId}")]
        public async Task<ActionResult> UpdatePetOwner(int petPetOwnerId, PetOwner petOwner)
        {
            try
            {
                if (petPetOwnerId != petOwner.PetOwnerId)
                    return new BadRequestResult();
                var res = await _petOwnerRepository.UpdatePetOwner(petOwner);
                if (res != null) return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Exception occured in PetOwnerController.UpdatePetOwner", ex);
                throw;
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("/api/DeletePetOwnerById/{petPetOwnerId}")]
        public async Task<IActionResult> DeletePetOwnerById(int petPetOwnerId)
        {
            try
            {
                if (petPetOwnerId <= 0)
                    return BadRequest();
                else
                {
                    var res = await _petOwnerRepository.DeletePetOwnerById(petPetOwnerId);
                    if (res)
                        return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Exception occured in PetOwnerController.DeletePetOwnerById", ex);
                throw;
            }
            return NotFound();
        }

        [HttpGet]
        [Route("/api/GetPetOwnerById/{petPetOwnerId}")]
        public async Task<IActionResult> GetPetById(int petPetOwnerId)
        {
            try
            {
                if (petPetOwnerId <= 0)
                    return BadRequest();
                else
                {
                    var res = await _petOwnerRepository.GetPetOwnerById(petPetOwnerId);
                    if (res != null)
                        return Ok(res);
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Exception occured in PetOwnerController.GetPetOwnerById", ex);
                throw;
            }
            return NotFound();
        }
    }
}

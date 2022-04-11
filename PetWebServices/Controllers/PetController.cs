using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetService.Entities.Models;
using PetService.Repository;
using PetService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetWebServices.Controllers
{
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;
        private readonly ILogger<PetController> _logger;
        public PetController(IPetRepository petRepository, ILogger<PetController> logger)
        {
            _petRepository = petRepository;
            _logger = logger;

        }

        [HttpGet]
        [Route("/api/GetAllPets")]
        public async Task<ActionResult> GetAllPets()
        {
            try
            {
                var response = await _petRepository.GetAllPets();
                if (response != null)
                    return new  OkObjectResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Exception occured in PetController.GetAllPets", ex);
                throw;
            }
            return NotFound();
        }

        [HttpPost]
        [Route("/api/CreatePet")]
        public async Task<ActionResult> CreatePet(Pet pet)
        {
            try
            {
                if (pet == null)
                    return BadRequest();

                var response = await _petRepository.CreatePet(pet);
                if (response != null)
                    return Created("/CreatePet", response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Exception occured in PetController.CreatePet", ex);
                throw;
            }           
            return null;
        }

        [HttpPut("api/UpdatePet/{petId}")]
        public async Task<ActionResult> UpdatePet(int petId,Pet pet)
        {
            try
            {
                if (petId != pet.PetId)
                    return BadRequest();
                var res = await _petRepository.UpdatePet(pet);
                if (res != null) return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Exception occured in PetController.UpdatePet", ex);

                throw;
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("/api/DeletePetById/{petId}")]
        public async Task<IActionResult> DeletePetById(int petId)
        {
            try
            {
                if (petId <= 0)
                    return BadRequest();
                else
                {
                    var res = await _petRepository.DeletePetById(petId);
                    if(res)
                    return Ok();
                }                 
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Exception occured in PetController.DeletePetById", ex);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("/api/GetPetById/{petId}")]
        public async Task<IActionResult> GetPetById(int petId)
        {
            try
            {
                if (petId <= 0)
                    return BadRequest();
                else
                {
                    var res = await _petRepository.GetPetById(petId);
                    if(res!=null)
                    return Ok(res);
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Exception occured in PetController.GetPetById", ex);
                throw;
            }
            return NotFound();
        }
    }
}

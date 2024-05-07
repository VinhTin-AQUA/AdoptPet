
using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.Location;
using AdoptPet.Application.DTOs.Pet;
using AdoptPet.Application.Interfaces;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdoptPet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly PetService _petService;

        public PetsController(PetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        [Route("get-all-pets")]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            try
            {
                var results = await _petService.GetAllAsync(pageNumber, pageSize);
                return Ok(new Success<List<Pet>> { Status = true, Messages = [], Data = results.Items.ToList() });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet]
        [Route("search-by-breed/{breed}")]
        public async Task<IActionResult> SearchByBreed(int breedId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than 0.");
            }

            var results = await _petService.SearchPetsByBreedAsync(breedId, pageNumber, pageSize);
            return Ok(results);
        }
        [HttpGet]
        [Route("search-by-criteria")]
        public async Task<IActionResult> SearchByCriteria([FromQuery] SearchCriteria searchCriteria, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _petService.SearchPetsByCriteria(searchCriteria, pageNumber, pageSize);
                return Ok(new Success<List<Pet>> { Status = true, Messages = [], Data = result.Items.ToList() });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-pet-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var pet = await _petService.GetByIdAsync(id);
                return Ok(pet);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("add-pet")]
        public async Task<IActionResult> Add([FromBody] Pet pet)
        {
            var r = await _petService.AddAsync(pet);
            return Ok();
        }

        [HttpPut]
        [Route("update-pet/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Pet pet)
        {
            if (id != pet.Id)
            {
                return BadRequest("Id in the URL and body don't match");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _petService.UpdateAsync(pet);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("soft-delete-pet/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _petService.SoftDelete(id);
            return NoContent();
        }
    }
}
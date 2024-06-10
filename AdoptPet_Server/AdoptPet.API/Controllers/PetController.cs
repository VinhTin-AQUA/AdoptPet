
using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.Location;
using AdoptPet.Application.DTOs.Pet;
using AdoptPet.Application.Interfaces;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Application.Interfaces.IService;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace AdoptPet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
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
                return Ok(new Success<List<Pet>> { Status = true, Messages = [], Data = results.Items?.ToList() });
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (SqlNullValueException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //[HttpGet]
        //[Route("search-by-breed/{breed}")]
        //public async Task<IActionResult> SearchByBreed(int breedId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        //{
        //    var results = await _petService.SearchPetsByBreedAsync(breedId, pageNumber, pageSize);
        //    return Ok(results);
        //}
        [HttpGet]
        [Route("search-by-criteria")]
        public async Task<IActionResult> SearchByCriteria([FromQuery] SearchCriteria searchCriteria, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _petService.SearchPetsByCriteria(searchCriteria, pageNumber, pageSize);
                return Ok(new Success<List<Pet>> { Status = true, Messages = [], Data = result.Items.ToList() });
            }
            catch (InvalidDataException ex)
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
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (SqlNullValueException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost]
        [Route("add-pet")]
        public async Task<IActionResult> Add([FromForm] Pet pet, [FromForm] List<IFormFile> Images)
        {
            try
            {
                var generatedId = await _petService.AddAsync(pet);
                return Ok(new Success<int> { Status = true, Title = "", Messages = [], Data = (int)generatedId });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (SqlNullValueException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update-pet/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] Pet pet, List<IFormFile> images)
        {


            try
            {
                await _petService.UpdateAsync(id, pet);
                return Ok();
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (SqlNullValueException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("soft-delete-pet/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _petService.SoftDelete(id);
                return Ok();
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (SqlNullValueException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
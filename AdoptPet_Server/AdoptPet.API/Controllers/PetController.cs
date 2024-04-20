
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
    public class PetController : ControllerBase
    {
        private readonly PetService _petService;

        public PetController(PetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        [Route("search-pet-by-breed/{breedId}")]
        //public async Task<ActionResult<List<Pet>>> GetPetsByBreed(int breedId)
        //{
        //    var pets = await _petService.GetPetsByBreedAsync(breedId);
        //    if (pets == null || pets.Count == 0)
        //    {
        //        return NotFound("No pets found for the specified breed.");
        //    }
        //    return Ok(pets);
        //}
    }
}
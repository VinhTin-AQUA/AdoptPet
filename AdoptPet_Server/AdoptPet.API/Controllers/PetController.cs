using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoptPet.Application.Interfaces;
using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AdoptPet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetSearchService _petService;

        public PetController(IPetSearchService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        [Route("search-pet-by-breed/{breedId}")]
        public async Task<ActionResult<List<Pet>>> GetPetsByBreed(int breedId)
        {
            var pets = await _petService.GetPetsByBreedAsync(breedId);
            if (pets == null || pets.Count == 0)
            {
                return NotFound("No pets found for the specified breed.");
            }
            return Ok(pets);
        }
    }
}
using AdoptPet.Application.DTOs.Breed;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedController : ControllerBase
    {
        private readonly IGenericRepository<Breed> genericRepository;

        public BreedController(IGenericRepository<Breed> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        [HttpGet]
        [Route("get-breed-by-id/{id}")]
        public async Task<IActionResult> GetBreedById(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);
            return Ok(r);
        }

        [HttpGet]
        [Route("get-all-breed")]
        public async Task<IActionResult> GetAllBreeds()
        {
            var breeds = await genericRepository.GetAllAsync();
            return Ok(breeds);
        }

        [HttpPost]
        [Route("add-breed")]
        public async Task<IActionResult> AddBreed(BreedDto model)
        {
            Breed newBreed = new Breed()
            {
                BreedName = model.BreedName,
                Description = model.Description,
                ThumbPath = ""
            };

            var r = await genericRepository.AddAsync(newBreed);
            return Ok(r);
        }
    }
}

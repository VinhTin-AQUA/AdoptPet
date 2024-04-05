using AdoptPet.Application.DTOs;
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

            return Ok(new Success<Breed> { Status = true, Messages = [], Data = r });
        }

        [HttpGet]
        [Route("get-all-breed")]
        public async Task<IActionResult> GetAllBreeds()
        {
            var breeds = await genericRepository.GetAllAsync();
            return Ok(new Success<List<Breed>> { Status = true, Messages = [], Data = breeds.ToList() });
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
            return Ok(new Success<Breed> { Status = true, Messages = [], Data = r });
        }

        [HttpPut]
        [Route("update-breed/{id}")]
        public async Task<IActionResult> UpdateBreed(int id, BreedDto model)
        {
            var oldBreed = await genericRepository.GetByIdAsync(id);

            if(oldBreed == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Breed not found"], Data = null });
            }
            oldBreed.Description = model.Description;
            oldBreed.BreedName = model.BreedName;

            /* cap nhat anhr */

            await genericRepository.UpdateAsync(oldBreed);

            return Ok(new Success<BreedDto> { Status = true, Messages = ["Update successfully"], Data = model });
        }

        [HttpDelete]
        [Route("delete-breed/{id}")] // https://localhost:7245/api/Breed/delete-breed/12
        public async Task<IActionResult> DeleteBreed(int id)
        {
            var breed = await genericRepository.GetByIdAsync(id);

            if(breed == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Breed not found"], Data = null });
            }
            await genericRepository.DeleteAsync(breed);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }
    }
}

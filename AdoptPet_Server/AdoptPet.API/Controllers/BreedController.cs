using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.BreedDto;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Application.Interfaces.IService;
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
        private readonly IImageService imageService;

        public BreedController(IGenericRepository<Breed> genericRepository, IImageService imageService)
        {
            this.genericRepository = genericRepository;
            this.imageService = imageService;
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
        public async Task<IActionResult> AddBreed([FromForm] BreedDto model, IFormFile file)
        {
            Breed newBreed = new Breed()
            {
                BreedName = model.BreedName,
                Description = model.Description,
                ThumbPath = ""
            };
            var r = await genericRepository.AddAsync(newBreed);

            if (file != null)
            {
                await imageService.SaveImage(file, "Breeds", newBreed.Id.ToString());
                newBreed.ThumbPath = file.FileName;
            }

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
        [Route("delete-permanently-breed/{id}")] // https://localhost:7245/api/Breed/delete-breed/12
        public async Task<IActionResult> DeletePermanentlyBreed(int id)
        {
            var breed = await genericRepository.GetByIdAsync(id);

            if(breed == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Breed not found"], Data = null });
            }
            await genericRepository.DeletePermanentlyAsync(breed);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }

        [HttpPut]
        [Route("soft-delete-breed/{id}")] // https://localhost:7245/api/Breed/delete-breed/12
        public async Task<IActionResult> DeleteBreed(int id)
        {
            var breed = await genericRepository.GetByIdAsync(id);

            if (breed == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Breed not found"], Data = null });
            }
            await genericRepository.SoftDelete(breed);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }
    }
}

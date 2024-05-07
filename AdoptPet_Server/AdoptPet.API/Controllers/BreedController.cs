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

            return Ok(new Success<Breed> { Status = true, Title = "", Messages = [], Data = r });
        }

        [HttpGet]
        [Route("get-all-breed")]
        public async Task<IActionResult> GetAllBreeds([FromQuery]int pageNumber, [FromQuery] int pageSize)
        {
            var breeds = await genericRepository.GetAllAsync(pageNumber,pageSize);
            return Ok(new Success<List<Breed>> { Status = true, Title = "", Messages = [], Data = breeds.Items!.ToList() });
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

            return Ok(new Success<Breed> { Status = true, Title = "", Messages = [] });
        }

        [HttpPut]
        [Route("update-breed/{id}")]
        public async Task<IActionResult> UpdateBreed(int id, BreedDto model)
        {
            var oldBreed = await genericRepository.GetByIdAsync(id);

            if(oldBreed == null)
            {
                return BadRequest(new Success<object> { Status = false, Title = "Không tìm thấy thú cưng", Messages = ["Xin vui lòng thử lại."], Data = null });
            }
            oldBreed.Description = model.Description;
            oldBreed.BreedName = model.BreedName;

            /* cap nhat anhr */

            await genericRepository.UpdateAsync(oldBreed);

            return Ok(new Success<BreedDto> { Status = true, Title = "", Messages = ["Update successfully"], Data = model });
        }

        [HttpDelete]
        [Route("delete-permanently-breed/{id}")] // https://localhost:7245/api/Breed/delete-breed/12
        public async Task<IActionResult> DeletePermanentlyBreed(int id)
        {
            var breed = await genericRepository.GetByIdAsync(id);

            if(breed == null)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = ["Xin vui lòng thử lại"], Data = null });
            }
            await genericRepository.DeletePermanentlyAsync(breed);
            return Ok(new Success<object> { Status = true, Title = "", Messages = ["Xóa thành công"], Data = null });
        }

        [HttpPut]
        [Route("soft-delete-breed/{id}")] // https://localhost:7245/api/Breed/delete-breed/12
        public async Task<IActionResult> DeleteBreed(int id)
        {
            var breed = await genericRepository.GetByIdAsync(id);

            if (breed == null)
            {
                return BadRequest(new Success<object> { Status = false, Title = "Không tìm thấy giống", Messages = ["Xin vui lòng thử lại"], Data = null });
            }
            await genericRepository.SoftDelete(id);
            return Ok(new Success<object> { Status = true, Title = "", Messages = ["Delete successfully"], Data = null });
        }
    }
}

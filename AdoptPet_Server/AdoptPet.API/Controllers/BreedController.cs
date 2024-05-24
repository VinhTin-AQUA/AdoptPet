using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.BreedDto;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Application.Interfaces.IService;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedController : ControllerBase
    {
        private readonly IGenericServiceWithImage<Breed> breedService;
        private readonly IImageService imageService;

        public BreedController(IGenericServiceWithImage<Breed> breedService, IImageService imageService)
        {
            this.breedService = breedService;
            this.imageService = imageService;
        }

        [HttpGet]
        [Route("get-breed-by-id/{id}")]
        public async Task<IActionResult> GetBreedById(int id)
        {
            try
            {
                var r = await breedService.GetByIdAsync(id);
                return Ok(new Success<Breed> { Status = true, Title = "", Messages = [], Data = r });
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

        [HttpGet]
        [Route("get-all-breed")]
        public async Task<IActionResult> GetAllBreeds([FromQuery]int pageNumber, [FromQuery] int pageSize)
        {
            try
            {
                var breeds = await breedService.GetAllAsync(pageNumber, pageSize);
                return Ok(new Success<List<Breed>> { Status = true, Title = "", Messages = [], Data = breeds.Items.ToList() });
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Data);
            }
            catch (SqlNullValueException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("add-breed")]
        public async Task<IActionResult> AddBreed([FromForm] Breed model, IFormFile file)
        {
            try
            {
                var generatedId = await breedService.AddAsync(model, file);
                return Ok(new Success<int> { Status = true, Title = "", Messages = [], Data = (int)generatedId });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (SqlNullValueException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update-breed/{id}")]
        public async Task<IActionResult> UpdateBreed(int id, [FromForm]Breed model, IFormFile file)
        {
            try
            {
                await breedService.UpdateAsync(id, model, file);
                return Ok(new Success<BreedDto> { Status = true, Title = "", Messages = ["Update successfully"] });
            }
            catch(InvalidDataException ex)
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

        //[HttpDelete]
        //[Route("delete-permanently-breed/{id}")] // https://localhost:7245/api/Breed/delete-breed/12
        //public async Task<IActionResult> DeletePermanentlyBreed(int id)
        //{
        //    try
        //    {
        //        await breedService.DeletePermanentlyAsync(id);
        //        return Ok(new Success<object> { Status = true, Title = "", Messages = ["Xóa thành công"], Data = null });
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPut]
        [Route("soft-delete-breed/{id}")] // https://localhost:7245/api/Breed/delete-breed/12
        public async Task<IActionResult> SoftDeleteBreed(int id)
        {
            try
            {
                await breedService.SoftDelete(id);
                return Ok(new Success<object> { Status = true, Title = "", Messages = ["Delete successfully"], Data = null });
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

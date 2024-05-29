using AdoptPet.Application.DTOs;
using AdoptPet.Application.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetImageController : ControllerBase
    {
        private readonly IPetImageService _petImageService;

        public PetImageController(IPetImageService petImageService)
        {
            _petImageService = petImageService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] PetImageDTO petImageDto)
        {
            try
            {
                var id = await _petImageService.AddAsync(petImageDto);
                return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> AddManyImagesAsync([FromBody] List<PetImageDTO> petImageDtos)
        {
            try
            {
                var affectedRows = await _petImageService.AddManyImagesAsync(petImageDtos);
                return Ok(new { affectedRows });
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //[HttpDelete("{id:int}")]
        //public async Task<IActionResult> DeletePermanentlyAsync(int id)
        //{
        //    try
        //    {
        //        await _petImageService.DeletePermanentlyAsync(id);
        //        return NoContent();
        //    }
        //    catch (InvalidDataException ex)
        //    {
        //        return BadRequest(new { message = ex.Message });
        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        return NotFound(new { message = ex.Message });
        //    }
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var result = await _petImageService.GetAllAsync(pageNumber, pageSize);
                return Ok(result);
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("byPet/{petId:int}")]
        public async Task<IActionResult> GetAllPetImageByPetId(int petId)
        {
            try
            {
                var result = await _petImageService.GetAllPetImageByPetId(petId);
                return Ok(result);
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _petImageService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("soft/{id:int}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                var affectedRows = await _petImageService.SoftDelete(id);
                return Ok(new { affectedRows });
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] PetImageDTO petImageDto)
        {
            try
            {
                var affectedRows = await _petImageService.UpdateAsync(id, petImageDto);
                return Ok(new { affectedRows });
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut("bulk")]
        public async Task<IActionResult> UpdateManyImagesAsync([FromBody] List<PetImageDTO> petImageDtos)
        {
            try
            {
                var affectedRows = await _petImageService.UpdateManyImagesAsync(petImageDtos);
                return Ok(new { affectedRows });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}

using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.Colour;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourController : ControllerBase
    {
        private readonly IGenericService<Colour> colourService;

        public ColourController(IGenericService<Colour> colourService)
        {
            
            this.colourService = colourService;
        }

        [HttpGet]
        [Route("get-colour-by-id/{id}")]
        public async Task<IActionResult> GetColourById(int id)
        {
            try
            {
                var r = await colourService.GetByIdAsync(id);
                return Ok(new Success<Colour> { Status = true, Title = "", Messages = [], Data = r });
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
        [Route("get-all-colour")]
        public async Task<IActionResult> GetAllColours([FromQuery]int pageNumber, [FromQuery] int pageSize)
        {
            try
            {
                var colours = await colourService.GetAllAsync(pageNumber, pageSize);
                return Ok(colours);
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

        [HttpPost]
        [Route("add-colour")]
        public async Task<IActionResult> AddColour([FromForm]Colour model)
        {
            try
            {
                var r = await colourService.AddAsync(model);
                return Ok();
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
        [Route("update-colour/{id}")]
        public async Task<IActionResult> UpdateColour(int id, Colour model)
        {
            try
            {
                var oldColour = await colourService.UpdateAsync(id, model);
                return Ok(new Success<Colour> { Status = true, Title = "", Messages = ["Update successfully"] });
            }
            catch
            (InvalidDataException ex)
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
        //[Route("delete-permanently-colour/{id}")] 
        //public async Task<IActionResult> DeletePermanentlyColour(int id)
        //{
        //    await colourService.DeletePermanentlyAsync(id);
        //    return Ok(new Success<object> { Status = true, Title = "", Messages = ["Delete successfully"], Data = null });
        //}

        [HttpPut]
        [Route("soft-delete-colour/{id}")] 
        public async Task<IActionResult> SoftDeleteColour(int id)
        {
            try
            {
                await colourService.SoftDelete(id);
                return Ok(new Success<object> { Status = true, Title = "", Messages = ["Delete successfully"], Data = null });
            }
            catch
            (InvalidDataException ex)
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

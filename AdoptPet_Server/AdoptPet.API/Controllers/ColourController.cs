using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.Colour;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourController : ControllerBase
    {
        private readonly IGenericRepository<Colour> genericRepository;
        public ColourController(IGenericRepository<Colour> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        [HttpGet]
        [Route("get-colour-by-id/{id}")]
        public async Task<IActionResult> GetColourById(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);
            return Ok(new Success<Colour> { Status = true, Messages = [], Data = r });
        }

        [HttpGet]
        [Route("get-all-colour")]
        public async Task<IActionResult> GetAllColours()
        {
            var colours = await genericRepository.GetAllAsync();
            return Ok(new Success<List<Colour>> { Status = true, Messages = [], Data = colours.ToList() });
        }

        [HttpPost]
        [Route("add-colour")]
        public async Task<IActionResult> AddColour(ColourDto model)
        {
            Colour newColour = new Colour()
            {
                ColourName = model.ColourName
            };

            var r = await genericRepository.AddAsync(newColour);
            return Ok(new Success<Colour> { Status = true, Messages = [], Data = r });
        }

        [HttpPut]
        [Route("update-colour/{id}")]
        public async Task<IActionResult> UpdateColour(int id, ColourDto model)
        {
            var oldColour = await genericRepository.GetByIdAsync(id);

            if (oldColour == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Colour not found"], Data = null });
            }
            oldColour.ColourName = model.ColourName;

            /* cap nhat anhr */

            await genericRepository.UpdateAsync(oldColour);

            return Ok(new Success<ColourDto> { Status = true, Messages = ["Update successfully"], Data = model });
        }

        [HttpDelete]
        [Route("delete-permanently-colour/{id}")] 
        public async Task<IActionResult> DeletePermanentlyColour(int id)
        {
            var colour = await genericRepository.GetByIdAsync(id);

            if (colour == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Colour not found"], Data = null });
            }
            await genericRepository.DeletePermanentlyAsync(colour);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }

        [HttpPut]
        [Route("soft-delete-colour/{id}")] 
        public async Task<IActionResult> DeleteColour(int id)
        {
            var colour = await genericRepository.GetByIdAsync(id);

            if (colour == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Colour not found"], Data = null });
            }
            await genericRepository.SoftDelete(colour);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }
    }
}

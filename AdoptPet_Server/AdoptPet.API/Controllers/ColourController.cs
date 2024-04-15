using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.Colour;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourController : ControllerBase
    {
        private readonly ColourService colourService;

        public ColourController(ColourService colourService)
        {
            this.colourService = colourService;
        }

        [HttpGet]
        [Route("get-colour-by-id/{id}")]
        public async Task<IActionResult> GetColourById(int id)
        {
            var r = await colourService.GetByIdAsync(id);
            return Ok(new Success<Colour> { Status = true, Messages = [], Data = r });
        }

        [HttpGet]
        [Route("get-all-colour")]
        public async Task<IActionResult> GetAllColours()
        {
            var colours = await colourService.GetAllAsync();
            return Ok(new Success<List<Colour>> { Status = true, Messages = [], Data = colours.ToList() });
        }

        [HttpPost]
        [Route("add-colour")]
        public async Task<IActionResult> AddColour(ColourDto model)
        {
            var r = await colourService.AddAsync(model);
            return Ok(new Success<Colour> { Status = true, Messages = [], Data = r });
        }

        [HttpPut]
        [Route("update-colour/{id}")]
        public async Task<IActionResult> UpdateColour(int id, ColourDto model)
        {
            var oldColour = await colourService.UpdateAsync(id, model);
            return Ok(new Success<Colour> { Status = true, Messages = ["Update successfully"], Data = oldColour });
        }

        [HttpDelete]
        [Route("delete-permanently-colour/{id}")] 
        public async Task<IActionResult> DeletePermanentlyColour(int id)
        {
            await colourService.DeletePermanentlyAsync(id);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }

        [HttpPut]
        [Route("soft-delete-colour/{id}")] 
        public async Task<IActionResult> DeleteColour(int id)
        {
            await colourService.SoftDelete(id);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }
    }
}


using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.BreedDto;
using AdoptPet.Application.DTOs.Location;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationService locationService;
        public LocationController (LocationService locationService)
        {
            this.locationService = locationService;
        }
        [HttpGet]
        [Route("get-location-by-id/{id}")]
        public async Task<IActionResult> GetBreedById(int id)
        {
            var r = await locationService.GetByIdAsync(id);

            return Ok(new Success<Location> { Status = true, Messages = [], Data = r });
        }

        [HttpGet]
        [Route("get-all-location")]
        public async Task<IActionResult> GetAllLocation()
        {
            var locations = await locationService.GetAllAsync();
            return Ok(new Success<List<Location>> { Status = true, Messages = [], Data = locations.ToList() });
        }

        [HttpPost]
        [Route("add-location")]
        public async Task<IActionResult> AddLocation(LocationDto model)
        {
            var r = await locationService.AddAsync(model);
            return Ok(new Success<Location> { Status = true, Messages = [], Data = r });
        }

        [HttpPut]
        [Route("update-location/{id}")]
        public async Task<IActionResult> UpdateLocation(int id, LocationDto model)
        {
            var oldLoction = await locationService.UpdateAsync(id, model);
            return Ok(new Success<Location> { Status = true, Messages = ["Update successfully"], Data = oldLoction });
        }

        [HttpDelete]
        [Route("delete-permanently-location/{id}")] 
        public async Task<IActionResult> DeletePermanentlyLocation(int id)
        {
            await locationService.DeletePermanentlyAsync(id);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }

        [HttpPut]
        [Route("soft-delete-location/{id}")] 
        public async Task<IActionResult> DeleteLoction(int id)
        {
            await locationService.SoftDelete(id);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }
    }
}

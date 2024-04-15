
using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.BreedDto;
using AdoptPet.Application.DTOs.Location;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IGenericRepository<Location> genericRepository;
        public LocationController (IGenericRepository<Location> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        [HttpGet]
        [Route("get-location-by-id/{id}")]
        public async Task<IActionResult> GetBreedById(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);

            return Ok(new Success<Location> { Status = true, Title = "", Messages = [], Data = r });
        }

        [HttpGet]
        [Route("get-all-location")]
        public async Task<IActionResult> GetAllLocation()
        {
            var locations = await genericRepository.GetAllAsync();
            return Ok(new Success<List<Location>> { Status = true, Title = "", Messages = [], Data = locations.ToList() });
        }

        [HttpPost]
        [Route("add-location")]
        public async Task<IActionResult> AddLocation(LocationDto model)
        {
            Location newLocation = new Location()
            {
                Street = model.Street,
                Wards = model.Wards,
                DistrictCity = model.DistrictCity,
                ProvinceCity = model.ProvinceCity,
            };

            var r = await genericRepository.AddAsync(newLocation);
            return Ok(new Success<Location> { Status = true, Title = "", Messages = [], Data = r });
        }

        [HttpPut]
        [Route("update-location/{id}")]
        public async Task<IActionResult> UpdateLocation(int id, LocationDto model)
        {
            var oldLoction = await genericRepository.GetByIdAsync(id);

            if (oldLoction == null)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = ["Location not found"], Data = null });
            }
            oldLoction.Street = model.Street;
            oldLoction.Wards = model.Wards;
            oldLoction.DistrictCity = model.DistrictCity;
            oldLoction.ProvinceCity = model.ProvinceCity;

            /* cap nhat anhr */

            await genericRepository.UpdateAsync(oldLoction);

            return Ok(new Success<LocationDto> { Status = true, Title = "", Messages = ["Update successfully"], Data = model });
        }

        [HttpDelete]
        [Route("delete-permanently-location/{id}")] // 
        public async Task<IActionResult> DeletePermanentlyLocation(int id)
        {
            var location = await genericRepository.GetByIdAsync(id);

            if (location == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Location not found"], Data = null });
            }
            await genericRepository.DeletePermanentlyAsync(location);
            return Ok(new Success<object> { Status = true, Title = "", Messages = ["Delete successfully"], Data = null });
        }

        [HttpPut]
        [Route("soft-delete-location/{id}")] 
        public async Task<IActionResult> DeleteLoction(int id)
        {
            var location = await genericRepository.GetByIdAsync(id);

            if (location == null)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = ["Location not found"], Data = null });
            }
            await genericRepository.SoftDelete(location);
            return Ok(new Success<object> { Status = true, Title = "", Messages = ["Delete successfully"], Data = null });
        }
    }
}

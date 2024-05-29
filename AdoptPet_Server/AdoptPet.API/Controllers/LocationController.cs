
using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.BreedDto;
using AdoptPet.Application.DTOs.Location;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IGenericService<Location> locationService;
        public LocationController (IGenericService<Location> locationService)
        {
            this.locationService = locationService;
        }
        [HttpGet]
        [Route("get-location-by-id/{id}")]
        public async Task<IActionResult> GetBreedById(int id)
        {
            try
            {
                var r = await locationService.GetByIdAsync(id);
                return Ok(new Success<Location> { Status = true, Title = "", Messages = [], Data = r });
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
        [Route("get-all-location")]
        public async Task<IActionResult> GetAllLocation(int pageNumber, int pageSize)
        {
            try
            {
                var locations = await locationService.GetAllAsync(pageNumber, pageSize);
                return Ok(new Success<List<Location>> { Status = true, Messages = [], Data = locations.Items!.ToList() });
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
        [Route("add-location")]
        public async Task<IActionResult> AddLocation(Location model)
        {
            try
            {
                var r = await locationService.AddAsync(model);
                return Ok(new Success<Location> { Status = true, Messages = [] });
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
        [Route("update-location/{id}")]
        public async Task<IActionResult> UpdateLocation(int id, Location model)
        {
            try
            {
                var affectedRows = await locationService.UpdateAsync(id, model);
                return Ok(new Success<Location> { Status = true, Messages = ["Update successfully"] });
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

        //[HttpDelete]
        //[Route("delete-permanently-location/{id}")] 
        //public async Task<IActionResult> DeletePermanentlyLocation(int id)
        //{
        //    await locationService.DeletePermanentlyAsync(id);
        //    return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        //}

        [HttpPut]
        [Route("soft-delete-location/{id}")] 
        public async Task<IActionResult> SoftDeleteLoction(int id)
        {
            try
            {
                await locationService.SoftDelete(id);
                return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
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

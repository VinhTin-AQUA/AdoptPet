using AdoptPet.Application.DTOs;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using AdoptPet.Application.DTOs.Donor;
using AdoptPet.Infrastructure.Services;
using System.Data.SqlTypes;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IGenericService<Donor> donorService;
        public DonorController(IGenericService<Donor> donorService)
        {
            this.donorService = donorService;
        }
        
        [HttpGet]
        [Route("get-donor-by-id/{id}")]
        public async Task<IActionResult> GetDonorById(int id)
        {
            try
            {
                var r = await donorService.GetByIdAsync(id);
                return Ok(new Success<Donor> { Status = true, Messages = [], Data = r });
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
        [Route("get-all-donor")]
        public async Task<IActionResult> GetAllDonor([FromQuery]int pageNumber, [FromQuery] int pageSize)
        {
            try
            {
                var donors = await donorService.GetAllAsync(pageNumber, pageSize);
                return Ok(new Success<List<Donor>> { Status = true, Messages = [], Data = donors.Items.ToList() });
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
        [Route("add-donor")]
        public async Task<IActionResult> AddDonor(Donor model)
        {
            try
            {
                var r = await donorService.AddAsync(model);
                return Ok(new Success<Donor> { Status = true, Messages = [] });
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
        [Route("update-donor/{id}")]
        public async Task<IActionResult> UpdateDonor(int id, Donor model)
        {
            try
            {
                var affectedRows = await donorService.UpdateAsync(id, model);
                return Ok(new Success<Donor> { Status = true, Messages = ["Update successfully"] });
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
        //[Route("delete-permanently-donor/{id}")]
        //public async Task<IActionResult> DeletePermanentlyDonor(int id)
        //{
        //    await donorService.DeletePermanentlyAsync(id);
        //    return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        //}

        [HttpPut]
        [Route("soft-delete-donor/{id}")]
        public async Task<IActionResult> SoftDeleteDonor(int id)
        {
            try
            {
                await donorService.SoftDelete(id);
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

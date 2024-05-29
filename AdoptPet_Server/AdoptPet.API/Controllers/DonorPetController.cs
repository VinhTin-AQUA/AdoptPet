  using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.Donor;
using AdoptPet.Application.DTOs.DonorPet;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using AdoptPet.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorPetController : ControllerBase
    {
        private readonly IGenericService<DonorPet> donorPetService;
        public DonorPetController(IGenericService<DonorPet> donorPetService)
        {
            this.donorPetService = donorPetService;
        }
        [HttpGet]
        [Route("get-donorpet-by-id/{id}")]
        public async Task<IActionResult> GetDonorPetById(int id)
        {
            try
            {
                var r = await donorPetService.GetByIdAsync(id);
                return Ok(new Success<DonorPet> { Status = true, Messages = [], Data = r });
            }
            catch (InvalidDataException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (SqlNullValueException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        [HttpGet]
        [Route("get-all-donorpet")]
        public async Task<IActionResult> GetAllDonorPet(int pageNumber, int pageSize)
        {
            try
            {
                var donorPets = await donorPetService.GetAllAsync(pageNumber, pageSize);
                return Ok(new Success<List<DonorPet>> { Status = true, Messages = [], Data = donorPets.Items!.ToList() });
            }
            catch (InvalidDataException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (SqlNullValueException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("add-donorpet")]
        public async Task<IActionResult> AddDonorPet(DonorPet model)
        {
            try
            {
                var r = await donorPetService.AddAsync(model);
                return Ok(new Success<DonorPet> { Status = true });
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

        [HttpPut]
        [Route("update-donorpet/{id}")]
        public async Task<IActionResult> UpdateDonorPet(int id, DonorPet model)
        {
            try
            {
                var oldDonorPet = await donorPetService.UpdateAsync(id, model);
                return Ok(new Success<DonorPet> { Status = true, Messages = ["Update successfully"], Data = oldDonorPet });
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
        //[Route("delete-permanently-donorpet/{id}")]
        //public async Task<IActionResult> DeletePermanentlyDonorPet(int id)
        //{
        //    await donorPetService.DeletePermanentlyAsync(id);
        //    return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        //}

        [HttpPut]
        [Route("soft-delete-donorpet/{id}")]
        public async Task<IActionResult> SoftDeleteDonorPet(int id)
        {
            try
            {
                await donorPetService.SoftDelete(id);
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

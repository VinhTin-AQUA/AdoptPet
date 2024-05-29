using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.DonorPet;
using AdoptPet.Application.DTOs.DonorPetAudit;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorPetAuditController : ControllerBase
    {
        private readonly IGenericService<DonorPetAudit> donorPetAuditService;
        public DonorPetAuditController(IGenericService<DonorPetAudit> donorPetAuditService)
        {
            this.donorPetAuditService = donorPetAuditService;
        }
        [HttpGet]
        [Route("get-donorpetaudit-by-id/{id}")]
        public async Task<IActionResult> GetDonorPetAuditById(int id)
        {
            try
            {
                var r = await donorPetAuditService.GetByIdAsync(id);
                return Ok(new Success<DonorPetAudit> { Status = true, Messages = [], Data = r });
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
        [Route("get-all-donorpetaudit")]
        public async Task<IActionResult> GetAllDonorPetAudit(int pageNumber, int pageSize)
        {
            try
            {
                var donorPetAudits = await donorPetAuditService.GetAllAsync(pageNumber, pageSize);
                return Ok(new Success<List<DonorPetAudit>> { Status = true, Messages = [], Data = donorPetAudits.Items!.ToList() });
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
        [Route("add-donorpetaudit")]
        public async Task<IActionResult> AddDonorPetAudit(DonorPetAudit model)
        {
            try
            {
                var r = await donorPetAuditService.AddAsync(model);
                return Ok(new Success<DonorPetAudit> { Status = true, Messages = [] });
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
        [Route("update-donorpetaudit/{id}")]
        public async Task<IActionResult> UpdateDonorPetAudit(int id, DonorPetAudit model)
        {
            try
            {
                var affectedRows = await donorPetAuditService.UpdateAsync(id, model);
                return Ok(new Success<DonorPetAudit> { Status = true, Messages = ["Update successfully"] });
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
        //[Route("delete-permanently-donorpetaudit/{id}")]
        //public async Task<IActionResult> DeletePermanentlyDonorPetAudit(int id)
        //{
        //    await donorPetAuditService.DeletePermanentlyAsync(id);
        //    return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        //}

        [HttpPut]
        [Route("soft-delete-donorpetaudit/{id}")]
        public async Task<IActionResult> SoftDeleteDonorPetAudit(int id)
        {
            try
            {
                await donorPetAuditService.SoftDelete(id);
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

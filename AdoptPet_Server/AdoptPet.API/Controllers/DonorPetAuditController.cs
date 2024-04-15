using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.DonorPet;
using AdoptPet.Application.DTOs.DonorPetAudit;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorPetAuditController : ControllerBase
    {
        private readonly DonorPetAuditService donorPetAuditService;
        public DonorPetAuditController(DonorPetAuditService donorPetAuditService)
        {
            this.donorPetAuditService = donorPetAuditService;
        }
        [HttpGet]
        [Route("get-donorpetaudit-by-id/{id}")]
        public async Task<IActionResult> GetDonorPetAuditById(int id)
        {
            var r = await donorPetAuditService.GetByIdAsync(id);
            return Ok(new Success<DonorPetAudit> { Status = true, Messages = [], Data = r });
        }
        [HttpGet]
        [Route("get-all-donorpetaudit")]
        public async Task<IActionResult> GetAllDonorPetAudit()
        {
            var donorPetAudits = await donorPetAuditService.GetAllAsync();
            return Ok(new Success<List<DonorPetAudit>> { Status = true, Messages = [], Data = donorPetAudits.ToList() });
        }

        [HttpPost]
        [Route("add-donorpetaudit")]
        public async Task<IActionResult> AddDonorPetAudit(DonorPetAuditDto model)
        {
            var r = await donorPetAuditService.AddAsync(model);
            return Ok(new Success<DonorPetAudit> { Status = true, Messages = [], Data = r });
        }

        [HttpPut]
        [Route("update-donorpetaudit/{id}")]
        public async Task<IActionResult> UpdateDonorPetAudit(int id, DonorPetAuditDto model)
        {
            var oldDonorPetAudit = await donorPetAuditService.UpdateAsync(id, model);
            return Ok(new Success<DonorPetAudit> { Status = true, Messages = ["Update successfully"], Data = oldDonorPetAudit });
        }

        [HttpDelete]
        [Route("delete-permanently-donorpetaudit/{id}")]
        public async Task<IActionResult> DeletePermanentlyDonorPetAudit(int id)
        {
            await donorPetAuditService.DeletePermanentlyAsync(id);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }

        [HttpPut]
        [Route("soft-delete-donorpetaudit/{id}")]
        public async Task<IActionResult> DeleteDonorPetAudit(int id)
        {
            await donorPetAuditService.SoftDelete(id);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }
    }
}

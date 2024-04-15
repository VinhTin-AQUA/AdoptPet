using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.DonorPet;
using AdoptPet.Application.DTOs.DonorPetAudit;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorPetAuditController : ControllerBase
    {
        private readonly IGenericRepository<DonorPetAudit> genericRepository;
        public DonorPetAuditController(IGenericRepository<DonorPetAudit> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        [HttpGet]
        [Route("get-donorpetaudit-by-id/{id}")]
        public async Task<IActionResult> GetDonorPetAuditById(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);
            return Ok(new Success<DonorPetAudit> { Status = true, Title = "", Messages = [], Data = r });
        }
        [HttpGet]
        [Route("get-all-donorpetaudit")]
        public async Task<IActionResult> GetAllDonorPetAudit()
        {
            var donorPetAudits = await genericRepository.GetAllAsync();
            return Ok(new Success<List<DonorPetAudit>> { Status = true, Title = "", Messages = [], Data = donorPetAudits.ToList() });
        }

        [HttpPost]
        [Route("add-donorpetaudit")]
        public async Task<IActionResult> AddDonorPetAudit(DonorPetAuditDto model)
        {
            DonorPetAudit newDonorPetAudit = new DonorPetAudit()
            {
                LastDonation = model.LastDonation,
                Version = model.Version,
                NewTotalDonation = model.NewTotalDonation,
                OldTotalDonation = model.OldTotalDonation
            };

            var r = await genericRepository.AddAsync(newDonorPetAudit);
            return Ok(new Success<DonorPetAudit> { Status = true, Title = "", Messages = [], Data = r });
        }

        [HttpPut]
        [Route("update-donorpetaudit/{id}")]
        public async Task<IActionResult> UpdateDonorPetAudit(int id, DonorPetAuditDto model)
        {
            var oldDonorPetAudit = await genericRepository.GetByIdAsync(id);

            if (oldDonorPetAudit == null)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = ["DonorPetAudit not found"], Data = null });
            }
            oldDonorPetAudit.LastDonation = model.LastDonation;
            oldDonorPetAudit.Version = model.Version;
            oldDonorPetAudit.NewTotalDonation = model.NewTotalDonation;
            oldDonorPetAudit.OldTotalDonation = model.OldTotalDonation;

            /* cap nhat anhr */

            await genericRepository.UpdateAsync(oldDonorPetAudit);

            return Ok(new Success<DonorPetAuditDto> { Status = true, Title = "", Messages = ["Update successfully"], Data = model });
        }

        [HttpDelete]
        [Route("delete-permanently-donorpetaudit/{id}")]
        public async Task<IActionResult> DeletePermanentlyDonorPetAudit(int id)
        {
            var donorPetAudit = await genericRepository.GetByIdAsync(id);

            if (donorPetAudit == null)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = ["DonorPetAudit not found"], Data = null });
            }
            await genericRepository.DeletePermanentlyAsync(donorPetAudit);
            return Ok(new Success<object> { Status = true, Title = "", Messages = ["Delete successfully"], Data = null });
        }

        [HttpPut]
        [Route("soft-delete-donorpetaudit/{id}")]
        public async Task<IActionResult> DeleteDonorPetAudit(int id)
        {
            var donorPetAudit = await genericRepository.GetByIdAsync(id);

            if (donorPetAudit == null)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = ["DonorPetAudit not found"], Data = null });
            }
            await genericRepository.SoftDelete(donorPetAudit);
            return Ok(new Success<object> { Status = true, Title = "", Messages = ["Delete successfully"], Data = null });
        }
    }
}

using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.Donor;
using AdoptPet.Application.DTOs.DonorPet;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorPetController : ControllerBase
    {
        private readonly IGenericRepository<DonorPet> genericRepository;
        public DonorPetController(IGenericRepository<DonorPet> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        [HttpGet]
        [Route("get-donorpet-by-id/{id}")]
        public async Task<IActionResult> GetDonorPetById(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);
            return Ok(new Success<DonorPet> { Status = true, Messages = [], Data = r });
        }
        [HttpGet]
        [Route("get-all-donorpet")]
        public async Task<IActionResult> GetAllDonorPet()
        {
            var donorPets = await genericRepository.GetAllAsync();
            return Ok(new Success<List<DonorPet>> { Status = true, Messages = [], Data = donorPets.ToList() });
        }

        [HttpPost]
        [Route("add-donorpet")]
        public async Task<IActionResult> AddDonorPet(DonorPetDto model)
        {
            DonorPet newDonorPet = new DonorPet()
            {
                LastDonation = model.LastDonation,
                TotalDonation = model.TotalDonation
            };

            var r = await genericRepository.AddAsync(newDonorPet);
            return Ok(new Success<DonorPet> { Status = true, Messages = [], Data = r });
        }

        [HttpPut]
        [Route("update-donorpet/{id}")]
        public async Task<IActionResult> UpdateDonorPet(int id, DonorPetDto model)
        {
            var oldDonorPet = await genericRepository.GetByIdAsync(id);

            if (oldDonorPet == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["DonorPet not found"], Data = null });
            }
            oldDonorPet.LastDonation = model.LastDonation;
            oldDonorPet.TotalDonation = model.TotalDonation;

            /* cap nhat anhr */

            await genericRepository.UpdateAsync(oldDonorPet);

            return Ok(new Success<DonorPetDto> { Status = true, Messages = ["Update successfully"], Data = model });
        }

        [HttpDelete]
        [Route("delete-permanently-donorpet/{id}")]
        public async Task<IActionResult> DeletePermanentlyDonorPet(int id)
        {
            var donorPet = await genericRepository.GetByIdAsync(id);

            if (donorPet == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["DonorPet not found"], Data = null });
            }
            await genericRepository.DeletePermanentlyAsync(donorPet);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }

        [HttpPut]
        [Route("soft-delete-donorpet/{id}")]
        public async Task<IActionResult> DeleteDonorPet(int id)
        {
            var donorPet = await genericRepository.GetByIdAsync(id);

            if (donorPet == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["DonorPet not found"], Data = null });
            }
            await genericRepository.SoftDelete(donorPet);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }
    }
}

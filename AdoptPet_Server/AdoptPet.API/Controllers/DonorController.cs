using AdoptPet.Application.DTOs;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using AdoptPet.Application.DTOs.Donor;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IGenericRepository<Donor> genericRepository;
        public DonorController(IGenericRepository<Donor> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        
        [HttpGet]
        [Route("get-donor-by-id/{id}")]
        public async Task<IActionResult> GetDonorById(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);
            return Ok(new Success<Donor> { Status = true, Title = "", Messages = [], Data = r });
        }

        [HttpGet]
        [Route("get-all-donor")]
        public async Task<IActionResult> GetAllDonor()
        {
            var donors = await genericRepository.GetAllAsync();
            return Ok(new Success<List<Donor>> { Status = true, Title = "", Messages = [], Data = donors.ToList() });
        }

        [HttpPost]
        [Route("add-donor")]
        public async Task<IActionResult> AddDonor(DonorDto model)
        {
            Donor newDonor = new Donor()
            {
                Name = model.Name,
                TotalDonation = model.TotalDonation
            };

            var r = await genericRepository.AddAsync(newDonor);
            return Ok(new Success<Donor> { Status = true, Title = "", Messages = [], Data = r });
        }

        [HttpPut]
        [Route("update-donor/{id}")]
        public async Task<IActionResult> UpdateDonor(int id, DonorDto model)
        {
            var oldDonor = await genericRepository.GetByIdAsync(id);

            if (oldDonor == null)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = ["Donor not found"], Data = null });
            }
            oldDonor.Name = model.Name;
            oldDonor.TotalDonation = model.TotalDonation;

            /* cap nhat anhr */

            await genericRepository.UpdateAsync(oldDonor);

            return Ok(new Success<DonorDto> { Status = true, Title = "", Messages = ["Update successfully"], Data = model });
        }

        [HttpDelete]
        [Route("delete-permanently-donor/{id}")]
        public async Task<IActionResult> DeletePermanentlyDonor(int id)
        {
            var donor = await genericRepository.GetByIdAsync(id);

            if (donor == null)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = ["Donor not found"], Data = null });
            }
            await genericRepository.DeletePermanentlyAsync(donor);
            return Ok(new Success<object> { Status = true, Title = "", Messages = ["Delete successfully"], Data = null });
        }

        [HttpPut]
        [Route("soft-delete-donor/{id}")]
        public async Task<IActionResult> DeleteDonor(int id)
        {
            var donor = await genericRepository.GetByIdAsync(id);

            if (donor == null)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = ["Donor not found"], Data = null });
            }
            await genericRepository.SoftDelete(donor);
            return Ok(new Success<object> { Status = true, Title = "", Messages = ["Delete successfully"], Data = null });
        }
    }
}

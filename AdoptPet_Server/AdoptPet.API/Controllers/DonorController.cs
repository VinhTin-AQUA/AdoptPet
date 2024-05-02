using AdoptPet.Application.DTOs;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using AdoptPet.Application.DTOs.Donor;
using AdoptPet.Infrastructure.Services;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly DonorService donorService;
        public DonorController(DonorService donorService)
        {
            this.donorService = donorService;
        }
        
        [HttpGet]
        [Route("get-donor-by-id/{id}")]
        public async Task<IActionResult> GetDonorById(int id)
        {
            var r = await donorService.GetByIdAsync(id);
            return Ok(new Success<Donor> { Status = true, Messages = [], Data = r });
        }

        [HttpGet]
        [Route("get-all-donor")]
        public async Task<IActionResult> GetAllDonor(int pageNumber, int pageSize)
        {
            var donors = await donorService.GetAllAsync(pageNumber,pageSize);
            return Ok(new Success<List<Donor>> { Status = true, Messages = [], Data = donors.Items.ToList() });
        }

        [HttpPost]
        [Route("add-donor")]
        public async Task<IActionResult> AddDonor(DonorDto model)
        {
            var r = await donorService.AddAsync(model);
            return Ok(new Success<Donor> { Status = true, Messages = []});
        }

        [HttpPut]
        [Route("update-donor/{id}")]
        public async Task<IActionResult> UpdateDonor(int id, DonorDto model)
        {
            var oldDonor = await donorService.UpdateAsync(id, model);
            return Ok(new Success<Donor> { Status = true, Messages = ["Update successfully"], Data = oldDonor });
        }

        [HttpDelete]
        [Route("delete-permanently-donor/{id}")]
        public async Task<IActionResult> DeletePermanentlyDonor(int id)
        {
            await donorService.DeletePermanentlyAsync(id);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }

        [HttpPut]
        [Route("soft-delete-donor/{id}")]
        public async Task<IActionResult> DeleteDonor(int id)
        {
            await donorService.SoftDelete(id);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }
    }
}

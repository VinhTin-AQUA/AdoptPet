using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.Donor;
using AdoptPet.Application.DTOs.DonorPet;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using AdoptPet.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorPetController : ControllerBase
    {
        private readonly DonorPetService donorPetService;
        public DonorPetController(DonorPetService donorPetService)
        {
            this.donorPetService = donorPetService;
        }
        [HttpGet]
        [Route("get-donorpet-by-id/{id}")]
        public async Task<IActionResult> GetDonorPetById(int id)
        {
            var r = await donorPetService.GetByIdAsync(id);
            return Ok(new Success<DonorPet> { Status = true, Messages = [], Data = r });
        }
        [HttpGet]
        [Route("get-all-donorpet")]
        public async Task<IActionResult> GetAllDonorPet(int pageNumber, int pageSize)
        {
            var donorPets = await donorPetService.GetAllAsync(pageNumber, pageSize);
            return Ok(new Success<List<DonorPet>> { Status = true, Messages = [], Data = donorPets.Items!.ToList() });
        }

        [HttpPost]
        [Route("add-donorpet")]
        public async Task<IActionResult> AddDonorPet(DonorPetDto model)
        {
            var r = await donorPetService.AddAsync(model);
            return Ok(new Success<DonorPet> { Status = true});
        }

        [HttpPut]
        [Route("update-donorpet/{id}")]
        public async Task<IActionResult> UpdateDonorPet(int id, DonorPetDto model)
        {
            var oldDonorPet = await donorPetService.UpdateAsync(id, model);
            return Ok(new Success<DonorPet> { Status = true, Messages = ["Update successfully"], Data = oldDonorPet });
        }

        [HttpDelete]
        [Route("delete-permanently-donorpet/{id}")]
        public async Task<IActionResult> DeletePermanentlyDonorPet(int id)
        {
            await donorPetService.DeletePermanentlyAsync(id);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }

        [HttpPut]
        [Route("soft-delete-donorpet/{id}")]
        public async Task<IActionResult> DeleteDonorPet(int id)
        {
            await donorPetService.SoftDelete(id);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }
    }
}

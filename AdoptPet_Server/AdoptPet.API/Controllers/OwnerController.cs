using AdoptPet.Application.DTOs.Breed;
using AdoptPet.Application.DTOs;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdoptPet.Application.DTOs.Owner;
using AdoptPet.Infrastructure.Services;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly OwnerService ownerService;
        public OwnerController(OwnerService ownerService)
        {
            this.ownerService = ownerService;
        }
        [HttpGet]
        [Route("get-owner-by-id/{id}")]
        public async Task<IActionResult> GetOwnerById(int id)
        {
            var r = await ownerService.GetByIdAsync(id);

            return Ok(new Success<Owner> { Status = true, Messages = [], Data = r });
        }

        [HttpGet]
        [Route("get-all-owner")]
        public async Task<IActionResult> GetAllOwners()
        {
            var owners = await ownerService.GetAllAsync();
            return Ok(new Success<List<Owner>> { Status = true, Messages = [], Data = owners.ToList() });
        }

        [HttpPost]
        [Route("add-owner")]
        public async Task<IActionResult> AddOwner(OwnerDto model)
        {
            var r = await ownerService.AddAsync(model);
            return Ok(new Success<Owner> { Status = true, Messages = [], Data = r });
        }

        [HttpPut]
        [Route("update-owner/{id}")]
        public async Task<IActionResult> UpdateOwner(int id, OwnerDto model)
        {
            var oldOwner = await ownerService.UpdateAsync(id, model);
            return Ok(new Success<Owner> { Status = true, Messages = ["Update successfully"], Data = oldOwner });
        }

        [HttpDelete]
        [Route("delete-permanently-owner/{id}")]
        public async Task<IActionResult> DeletePermanentlyOwner(int id)
        {
            await ownerService.DeletePermanentlyAsync(id);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }

        [HttpPut]
        [Route("soft-delete-owner/{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            await ownerService.SoftDelete(id);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }
    }
}

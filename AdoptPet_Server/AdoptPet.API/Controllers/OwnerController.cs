using AdoptPet.Application.DTOs.BreedDto;
using AdoptPet.Application.DTOs;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdoptPet.Application.DTOs.Owner;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IGenericRepository<Owner> genericRepository;
        public OwnerController(IGenericRepository<Owner> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        [HttpGet]
        [Route("get-owner-by-id/{id}")]
        public async Task<IActionResult> GetOwnerById(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);

            return Ok(new Success<Owner> { Status = true, Messages = [], Data = r });
        }

        [HttpGet]
        [Route("get-all-owner")]
        public async Task<IActionResult> GetAllOwners()
        {
            var owners = await genericRepository.GetAllAsync();
            return Ok(new Success<List<Owner>> { Status = true, Messages = [], Data = owners.ToList() });
        }

        [HttpPost]
        [Route("add-owner")]
        public async Task<IActionResult> AddOwner(OwnerDto model)
        {
            Owner newOwner = new Owner()
            {
                Name = model.Name
            };

            var r = await genericRepository.AddAsync(newOwner);
            return Ok(new Success<Owner> { Status = true, Messages = [], Data = r });
        }

        [HttpPut]
        [Route("update-owner/{id}")]
        public async Task<IActionResult> UpdateOwner(int id, OwnerDto model)
        {
            var oldOwner = await genericRepository.GetByIdAsync(id);

            if (oldOwner == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Owner not found"], Data = null });
            }
            oldOwner.Name = model.Name;

            /* cap nhat anhr */

            await genericRepository.UpdateAsync(oldOwner);

            return Ok(new Success<OwnerDto> { Status = true, Messages = ["Update successfully"], Data = model });
        }

        [HttpDelete]
        [Route("delete-permanently-owner/{id}")]
        public async Task<IActionResult> DeletePermanentlyOwner(int id)
        {
            var owner = await genericRepository.GetByIdAsync(id);

            if (owner == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Owner not found"], Data = null });
            }
            await genericRepository.DeletePermanentlyAsync(owner);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }

        [HttpPut]
        [Route("soft-delete-owner/{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            var owner = await genericRepository.GetByIdAsync(id);

            if (owner == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Owner not found"], Data = null });
            }
            await genericRepository.SoftDelete(owner);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }
    }
}

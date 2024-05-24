using AdoptPet.Application.DTOs.BreedDto;
using AdoptPet.Application.DTOs;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdoptPet.Application.DTOs.Owner;
using AdoptPet.Infrastructure.Services;
using System.Data.SqlTypes;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IGenericService<Owner> ownerService;
        private readonly LocationService locationService;
        private readonly IAccountRepository accountRepository;
        public OwnerController(IGenericService<Owner> ownerService)
        {
            this.ownerService = ownerService;
        }
        [HttpGet]
        [Route("get-owner-by-id/{id}")]
        public async Task<IActionResult> GetOwnerById(int id)
        {
            try
            {
                var r = await ownerService.GetByIdAsync(id);
                return Ok(new Success<Owner> { Status = true, Title = "", Messages = [], Data = r });
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
        [Route("get-all-owner")]
        public async Task<IActionResult> GetAllOwners(int pageNumber, int pageSize)
        {
            try
            {
                var owners = await ownerService.GetAllAsync(pageNumber, pageSize);
                return Ok(new Success<List<Owner>> { Status = true, Messages = [], Data = owners.Items.ToList() });
            }
            catch(InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(SqlNullValueException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("add-owner")]
        public async Task<IActionResult> AddOwner(OwnerDto model)
        {
            var user = await accountRepository.GetUserByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest(new Success<Volunteer> { Status = false, Title = "Email không hợp lệ" });
            }

            var newLocation = await locationService.AddAsync(model.Location);

            if (newLocation == null)
            {
                return BadRequest(new Success<Volunteer> { Status = false, Title = "Có lỗi xảy ra. Vui lòng thử lại" });
            }

            Owner newOwner = new()
            {
                IsDeleted = false,
                LocationId = (int)newLocation,
                UserId = user.Id,
            };
            try
            {
                var r = await ownerService.AddAsync(newOwner);
                return Ok(new Success<Owner> { Status = true, Messages = [] });
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
        [Route("update-owner/{id}")]
        public async Task<IActionResult> UpdateOwner(int id, Owner model)
        {
            try
            {
                var affectedRows = await ownerService.UpdateAsync(id, model);
                return Ok(new Success<Owner> { Status = true, Messages = ["Update successfully"] });
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
        //[Route("delete-permanently-owner/{id}")]
        //public async Task<IActionResult> DeletePermanentlyOwner(int id)
        //{
        //    await ownerService.DeletePermanentlyAsync(id);
        //    return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        //}

        [HttpPut]
        [Route("soft-delete-owner/{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            try
            {
                await ownerService.SoftDelete(id);
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

using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.Volunteer;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using AdoptPet.Infrastructure.Repositories;
using AdoptPet.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        private readonly IGenericService<Volunteer> volunteerService;
        private readonly IGenericService<Location> locationService;
        private readonly IAccountRepository accountRepository;

        public VolunteerController(IGenericService<Volunteer> volunteerService,
            IGenericService<Location> locationService,
            IAccountRepository accountRepository)
        {
            this.volunteerService = volunteerService;
            this.locationService = locationService;
            this.volunteerRoleXVolunteerRepository = volunteerRoleXVolunteerRepository;
            this.accountRepository = accountRepository;
        }

        [HttpGet]
        [Route("get-all-volunteer/pageNumber/{pageNumber}/pageSize/{pageSize}")]
        public async Task<IActionResult> GetAllVolunteers(int pageNumber, int pageSize)
        {
            try
            {
                var r = await volunteerService.GetAllAsync(pageNumber, pageSize);
                return Ok(new Success<List<Volunteer>> { Status = true, Data = r.Items.ToList() });
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(new Success<List<Volunteer>> { Status = false, Title = ex.Message });
            }
            catch (SqlNullValueException ex)
            {
                return BadRequest(new Success<List<Volunteer>> { Status = false, Title = ex.Message });
            }
        }

        [HttpGet]
        [Route("get-volunteer/{id}")]
        public async Task<IActionResult> GetVolunteerById(int id)
        {
            try
            {
                var r = await volunteerService.GetByIdAsync(id);
                return Ok(new Success<Volunteer> { Status = true, Data = r });
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

        [HttpPost]
        [Route("add-volunteer")]
        public async Task<IActionResult> AddVolunteer(VolunteerDto model)
        {
            var user = await accountRepository.GetUserByEmailAsync(model.UserEmail);
            if (user == null)
            {
                return BadRequest(new Success<Volunteer> 
                { 
                    Status = false, 
                    Title = "Email chưa đăng ký người dùng", 
                    Messages = ["Vui lòng nhập Email đã được đăng ký"] 
                });
            }

            var newLocation = await locationService.AddAsync(model.Location);

            if (newLocation == 0)
            {
                return BadRequest(new Success<Volunteer> { Status = false, Title = "Có lỗi xảy ra. Vui lòng thử lại" });
            }

            Volunteer newVolunteer = new()
            {
                DateStart = DateTime.Now,
                IsDeleted = false,
                LocationId = (int)newLocation,
                UserId = user.Id,
            };

            var r = await volunteerService.AddAsync(newVolunteer);
            if (r == null)
            {
                return BadRequest(new Success<Volunteer> { Status = false, Title = "Có lỗi xảy ra. Vui lòng thử lại" });
            }
            return Ok(new Success<int> { Status = true, Data = (int)r });
        }

        [HttpPut]
        [Route("update-volunteer")]
        public async Task<IActionResult> UpdateVolunteer(int Id, Volunteer model)
        {
            try
            {
                await volunteerService.UpdateAsync(Id, model);
                return Ok();
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (SqlNullValueException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        [Route("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await volunteerService.SoftDelete(id);
            return NoContent();
        }
    }
}
